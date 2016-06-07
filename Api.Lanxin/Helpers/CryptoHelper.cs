using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Api.Lanxin.Helpers
{
    /// <summary>
    /// 加密/解密辅助类
    /// </summary>
    public class CryptoHelper
    {
        #region Base64编码/解码
        /// <summary>
        /// Base64加密
        /// </summary>
        /// <param name="source">要加密的内容</param>
        /// <param name="encoding">默认是UTF8</param>
        /// <returns></returns>
        public static string Base64Encode(string source, Encoding encoding = null)
        {
            encoding = encoding == null ? Encoding.UTF8 : encoding;
            string encodingStr = source;

            byte[] bytes = encoding.GetBytes(source);
            try
            {
                encodingStr = Convert.ToBase64String(bytes);
            }
            catch
            {
                encodingStr = source;
            }
            return encodingStr;
        }
        /// <summary>
        /// Base64解密
        /// </summary>
        /// <param name="source">要解密的内容</param>
        /// <param name="encoding">默认是UTF8</param>
        /// <returns></returns>
        public static string Base64Decode(string source, Encoding encoding = null)
        {
            encoding = encoding == null ? Encoding.UTF8 : encoding;
            string decodeStr = source;

            byte[] bytes = Convert.FromBase64String(source);
            try
            {
                decodeStr = encoding.GetString(bytes); ;
            }
            catch
            {
                decodeStr = source;
            }
            return decodeStr;
        }
        #endregion

        #region AES加密/解密
        /// <summary>
        /// AES加密 先AES加密，最后转成Base64，iv 取key的前16个字符
        /// </summary>
        /// <param name="source"></param>
        /// <param name="key">32字节(byte)AESKey</param>
        /// <returns></returns>
        public static string AESEncrypt(string source, string key)
        {
            return AESEncrypt(source,key,key.Substring(0,16));
        }

        /// <summary>
        /// AES加密 先AES加密，最后转成Base64
        /// </summary>
        /// <param name="key">32字节(byte)AESKey</param>
        /// <param name="iv">16字节(byte)AESIV</param>
        /// <returns></returns>
        public static string AESEncrypt(string source, string key, string iv)
        {
            byte[] input_buffer = Encoding.UTF8.GetBytes(source);
            byte[] key_buffer = Encoding.UTF8.GetBytes(key);
            byte[] iv_buffer = Encoding.UTF8.GetBytes(iv);

            return AESEncrypt(input_buffer, key_buffer, iv_buffer);
        }

        /// <summary>
        /// AES加密 先AES加密，最后转成Base64编码 Base64_Encode(AES_Encrypt(input))
        /// </summary>
        /// <param name="input"></param>
        /// <param name="key">32字节(byte)AESKey</param>
        /// <param name="iv">16字节(byte)AESIV</param>
        /// <returns></returns>
        public static string AESEncrypt(byte[] input, byte[] key, byte[] iv)
        {
            AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;
            aes.KeySize = 256;
            aes.BlockSize = 128;

            byte[] key_byte = new byte[aes.KeySize / 8];
            byte[] iv_byte = new byte[aes.BlockSize / 8];

            Array.Copy(key, key_byte, key_byte.Length);
            Array.Copy(key, iv_byte, iv_byte.Length);
            aes.Key = key_byte;
            aes.IV = iv_byte;

            var encryptor = aes.CreateEncryptor();

            byte[] encrypt_buffer;

            // Create the streams used for encryption.
            using (MemoryStream ms_encrypt = new MemoryStream())
            {
                using (CryptoStream cs_encrypt = new CryptoStream(ms_encrypt, encryptor, CryptoStreamMode.Write))
                {
                    cs_encrypt.Write(input, 0, input.Length);
                    cs_encrypt.Close();
                    encrypt_buffer = ms_encrypt.ToArray();
                }
            }

            return Convert.ToBase64String(encrypt_buffer);
        }

        /// <summary>
        /// AES解密 先Base64解码，再AES解密 Base64_Decode(AES_Decrypt(input))
        /// </summary>
        /// <param name="text">密文</param>
        /// <param name="key">32字节(byte)AESKey</param>
        /// <returns></returns>
        public static string AESDecrypt(string text, string key)
        {
            return AESDecrypt(text, key, key.Substring(0, 16));
        }

        /// <summary>
        /// AES解密 先Base64解码，再AES解密 Base64_Decode(AES_Decrypt(input))
        /// </summary>
        /// <param name="text">密文</param>
        /// <param name="key">32字节(byte)AESKey</param>
        /// <param name="iv">16字节(byte)AESIV</param>
        /// <returns></returns>
        public static string AESDecrypt(string text, string key, string iv)
        {
            byte[] input_buffer = Convert.FromBase64String(text);
            byte[] key_buffer = Encoding.UTF8.GetBytes(key);
            byte[] iv_buffer = Encoding.UTF8.GetBytes(iv);

            return AESDecrypt(input_buffer, key_buffer, iv_buffer);
        }
        /// <summary>
        /// AES解密 先Base64解码，再AES解密 Base64_Decode(AES_Decrypt(input))
        /// </summary>
        /// <param name="input">密文</param>
        /// <param name="key">32字节(byte)AESKey</param>
        /// <param name="iv">16字节(byte)AESIV</param>
        /// <returns></returns>
        public static string AESDecrypt(byte[] input, byte[] key, byte[] iv)
        {
            AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;
            aes.KeySize = 256;
            aes.BlockSize = 128;

            byte[] key_byte = new byte[aes.KeySize / 8];
            byte[] iv_byte = new byte[aes.BlockSize / 8];

            Array.Copy(key, key_byte, key_byte.Length);
            Array.Copy(key, iv_byte, iv_byte.Length);
            aes.Key = key_byte;
            aes.IV = iv_byte;

            var decryptor = aes.CreateDecryptor();
            string plaintext = string.Empty;    // 明文

            // Create the streams used for decryption.
            using (MemoryStream ms_decrypt = new MemoryStream(input))
            {
                using (CryptoStream cs_decrypt = new CryptoStream(ms_decrypt, decryptor, CryptoStreamMode.Read))
                {
                    using (StreamReader sr_decrypt = new StreamReader(cs_decrypt))
                    {
                        // Read the decrypted bytes from the decrypting stream and place them in a string.
                        plaintext = sr_decrypt.ReadToEnd();
                    }
                }
            }

            return plaintext;
        }

        ///// <summary>
        ///// 随机生成编码
        ///// </summary>
        ///// <param name="len">编码的长度</param>
        ///// <returns></returns>
        //public static string GetRandCode(int len)
        //{
        //    char[] arrChar = new char[]
        //    {
        //       'a','b','d','c','e','f','g','h','i','j','k','l','m','n','p','r','q','s','t','u','v','w','z','y','x',
        //       '0','1','2','3','4','5','6','7','8','9',
        //       'A','B','C','D','E','F','G','H','I','J','K','L','M','N','Q','P','R','T','S','V','U','W','X','Y','Z'
        //    };

        //    StringBuilder num = new StringBuilder();

        //    Random rnd = new Random(DateTime.Now.Millisecond);
        //    for (int i = 0; i < len; i++)
        //    {
        //        num.Append(arrChar[rnd.Next(0, arrChar.Length)].ToString());
        //    }

        //    return num.ToString();
        //}
        #endregion
    }
}
