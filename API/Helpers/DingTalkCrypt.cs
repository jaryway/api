using System;
using System.Collections;
using System.Security.Cryptography;
using System.Text;

namespace API.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    public class DingTalkCrypt
    {
        private string m_sEncodingAESKey;
        private string m_sToken;
        private string m_sSuiteKey;
        ///**ask getPaddingBytes key固定长度**/
        private static int AES_ENCODE_KEY_LENGTH = 43;
        ///**加密随机字符串字节长度**/
        private static int RANDOM_LENGTH = 16;

        enum DingTalkCryptErrorCode
        {
            /**成功**/
            SUCCESS = 0,
            /**加密明文文本非法**/
            ENCRYPTION_PLAINTEXT_ILLEGAL = 900001,
            /**加密时间戳参数非法**/
            ENCRYPTION_TIMESTAMP_ILLEGAL = 900002,
            /**加密随机字符串参数非法**/
            ENCRYPTION_NONCE_ILLEGAL = 900003,
            /**不合法的aeskey**/
            AES_KEY_ILLEGAL = 900004,
            /**签名不匹配**/
            SIGNATURE_NOT_MATCH = 900005,
            /**计算签名错误**/
            COMPUTE_SIGNATURE_ERROR = 900006,
            /**计算加密文字错误**/
            COMPUTE_ENCRYPT_TEXT_ERROR = 900007,
            /**计算解密文字错误**/
            COMPUTE_DECRYPT_TEXT_ERROR = 900008,
            /**计算解密文字长度不匹配**/
            COMPUTE_DECRYPT_TEXT_LENGTH_ERROR = 900009,
            /**计算解密文字suiteKey不匹配**/
            COMPUTE_DECRYPT_TEXT_SuiteKey_ERROR = 900010,
        };

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="token">钉钉开放平台上，开发者设置的token</param>
        /// <param name="encodingAesKey">钉钉开放台上，开发者设置的EncodingAESKey</param>
        /// <param name="suiteKey">钉钉开放平台上，开发者设置的suiteKey</param>
        public DingTalkCrypt(string token, string encodingAesKey, string suiteKey)
        {
            m_sToken = token;
            m_sSuiteKey = suiteKey;
            m_sEncodingAESKey = encodingAesKey;
        }

        /// <summary>
        /// 将消息加密,返回加密后字符串
        /// </summary>
        /// <param name="sReplyMsg">传递的消息体明文</param>
        /// <param name="sTimeStamp">时间戳</param>
        /// <param name="sNonce">随机字符串</param>
        /// <param name="sEncryptMsg">加密后的消息信息</param>
        /// <returns>成功0，失败返回对应的错误码</returns>
        public int EncryptMsg(string sReplyMsg, string sTimeStamp, string sNonce, ref string sEncryptMsg, ref string signature)
        {
            if (string.IsNullOrEmpty(sReplyMsg))
                return (int)DingTalkCryptErrorCode.ENCRYPTION_PLAINTEXT_ILLEGAL;
            if (string.IsNullOrEmpty(sTimeStamp))
                return (int)DingTalkCryptErrorCode.ENCRYPTION_TIMESTAMP_ILLEGAL;
            if (string.IsNullOrEmpty(sNonce))
                return (int)DingTalkCryptErrorCode.ENCRYPTION_NONCE_ILLEGAL;

            if (m_sEncodingAESKey.Length != AES_ENCODE_KEY_LENGTH)
                return (int)DingTalkCryptErrorCode.AES_KEY_ILLEGAL;

            string raw = "";
            try
            {
                raw = Cryptography.AES_encrypt(sReplyMsg, m_sEncodingAESKey, m_sSuiteKey);
            }
            catch (Exception)
            {
                return (int)DingTalkCryptErrorCode.AES_KEY_ILLEGAL;
            }

            string msgSigature = "";
            int ret = GenerateSignature(m_sToken, sTimeStamp, sNonce, raw, ref msgSigature);
            sEncryptMsg = raw;
            signature = msgSigature;
            return ret;
        }
        /// <summary>
        /// 密文解密
        /// </summary>
        /// <param name="sMsgSignature">签名串</param>
        /// <param name="sTimeStamp">时间戳</param>
        /// <param name="sNonce">随机串</param>
        /// <param name="sPostData">密文</param>
        /// <param name="sMsg">解密后的原文，当return返回0时有效</param>
        /// <returns>成功0，失败返回对应的错误码</returns>
        public int DecryptMsg(string sMsgSignature, string sTimeStamp, string sNonce, string sPostData, ref string sMsg)
        {
            if (m_sEncodingAESKey.Length != AES_ENCODE_KEY_LENGTH)
                return (int)DingTalkCryptErrorCode.AES_KEY_ILLEGAL;

            string sEncryptMsg = sPostData;

            int ret = VerifySignature(m_sToken, sTimeStamp, sNonce, sEncryptMsg, sMsgSignature);

            string cpid = "";
            try
            {
                sMsg = Cryptography.AES_decrypt(sEncryptMsg, m_sEncodingAESKey, ref cpid);
            }
            catch (FormatException)
            {
                sMsg = "";
                return (int)DingTalkCryptErrorCode.COMPUTE_DECRYPT_TEXT_SuiteKey_ERROR;

            }
            catch (Exception)
            {
                sMsg = "";
                return (int)DingTalkCryptErrorCode.COMPUTE_DECRYPT_TEXT_SuiteKey_ERROR;
            }

            if (cpid != m_sSuiteKey)
                return (int)DingTalkCryptErrorCode.COMPUTE_DECRYPT_TEXT_SuiteKey_ERROR;

            return ret;
        }

        /// <summary>
        /// 生成签名
        /// </summary>
        /// <param name="sToken"></param>
        /// <param name="sTimeStamp"></param>
        /// <param name="sNonce"></param>
        /// <param name="sMsgEncrypt"></param>
        /// <param name="sMsgSignature"></param>
        /// <returns></returns>
        public static int GenerateSignature(string sToken, string sTimeStamp, string sNonce, string sMsgEncrypt, ref string sMsgSignature)
        {
            ArrayList AL = new ArrayList();
            AL.Add(sToken);
            AL.Add(sTimeStamp);
            AL.Add(sNonce);
            AL.Add(sMsgEncrypt);
            AL.Sort(new DictionarySort());
            string raw = "";
            for (int i = 0; i < AL.Count; ++i)
            {
                raw += AL[i];
            }

            SHA1 sha;
            ASCIIEncoding enc;
            string hash = "";
            try
            {
                sha = new SHA1CryptoServiceProvider();
                enc = new ASCIIEncoding();
                byte[] dataToHash = enc.GetBytes(raw);
                byte[] dataHashed = sha.ComputeHash(dataToHash);
                hash = BitConverter.ToString(dataHashed).Replace("-", "");
                hash = hash.ToLower();
            }
            catch (Exception)
            {
                return (int)DingTalkCryptErrorCode.COMPUTE_SIGNATURE_ERROR;
            }
            sMsgSignature = hash;
            return 0;
        }
        /// <summary>
        /// 验证签名
        /// </summary>
        /// <param name="sToken"></param>
        /// <param name="sTimeStamp"></param>
        /// <param name="sNonce"></param>
        /// <param name="sMsgEncrypt"></param>
        /// <param name="sSigture"></param>
        /// <returns></returns>
        private static int VerifySignature(string sToken, string sTimeStamp, string sNonce, string sMsgEncrypt, string sSigture)
        {
            string hash = "";
            int ret = 0;
            ret = GenerateSignature(sToken, sTimeStamp, sNonce, sMsgEncrypt, ref hash);
            if (ret != 0)
                return ret;
            if (hash == sSigture)
                return 0;
            else
            {
                return (int)DingTalkCryptErrorCode.SIGNATURE_NOT_MATCH;
            }
        }

        /// <summary>
        /// 验证URL
        /// </summary>
        /// <param name="sMsgSignature">签名串，对应URL参数的msg_signature</param>
        /// <param name="sTimeStamp">时间戳，对应URL参数的timestamp</param>
        /// <param name="sNonce">随机串，对应URL参数的nonce</param>
        /// <param name="sEchoStr">经过加密的消息体，对应URL参数的encrypt</param>
        /// <param name="sReplyEchoStr"></param>
        /// <returns></returns>
        public int VerifyURL(string sMsgSignature, string sTimeStamp, string sNonce, string sEchoStr, ref string sReplyEchoStr)
        {
            int ret = 0;
            if (m_sEncodingAESKey.Length != 43)
            {
                return (int)DingTalkCryptErrorCode.AES_KEY_ILLEGAL;
            }
            ret = VerifySignature(m_sToken, sTimeStamp, sNonce, sEchoStr, sMsgSignature);
            sReplyEchoStr = "";
            string cpid = "";
            try
            {
                sReplyEchoStr = Cryptography.AES_decrypt(sEchoStr, m_sEncodingAESKey, ref cpid); //m_sCorpID);
            }
            catch (Exception)
            {
                sReplyEchoStr = "";
                return (int)DingTalkCryptErrorCode.COMPUTE_SIGNATURE_ERROR;
            }
            if (cpid != m_sSuiteKey)
            {
                sReplyEchoStr = "";
                return (int)DingTalkCryptErrorCode.COMPUTE_DECRYPT_TEXT_SuiteKey_ERROR;
            }
            return ret;
        }
        /// <summary>
        /// 字典排序
        /// </summary>
        public class DictionarySort : System.Collections.IComparer
        {
            public int Compare(object oLeft, object oRight)
            {
                string sLeft = oLeft as string;
                string sRight = oRight as string;
                int iLeftLength = sLeft.Length;
                int iRightLength = sRight.Length;
                int index = 0;
                while (index < iLeftLength && index < iRightLength)
                {
                    if (sLeft[index] < sRight[index])
                        return -1;
                    else if (sLeft[index] > sRight[index])
                        return 1;
                    else
                        index++;
                }
                return iLeftLength - iRightLength;

            }
        }
    }
}
