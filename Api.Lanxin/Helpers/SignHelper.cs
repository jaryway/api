using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Api.Lanxin.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    public class SignHelper
    {
        /// <summary>
        /// 检查签名是否正确
        /// </summary>
        /// <param name="signature"></param>
        /// <param name="timestamp"></param>
        /// <param name="nonce"></param>
        /// <param name="token"></param>
        /// <param name="others">其他别的参数</param>
        /// <returns></returns>
        public static bool Check(string signature, string timestamp, string nonce, params string[] others)
        {
            return signature == Generate(timestamp, nonce);
        }

        /// <summary>
        /// 生成签名
        /// </summary>
        /// <param name="timestamp"></param>
        /// <param name="nonce"></param>
        /// <param name="token"></param>
        /// <param name="others">其他别的参数</param>
        /// <returns></returns>
        public static string Generate(string timestamp, string nonce, params string[] others)
        {
            ArrayList arrayList = new ArrayList();
            //arrayList.Add(token);
            arrayList.Add(timestamp);
            arrayList.Add(nonce);
            foreach (var item in others)
                arrayList.Add(item);
            arrayList.Sort(new DictionarySort());
            string raw = "";
            for (int i = 0; i < arrayList.Count; ++i)
            {
                raw += arrayList[i];
            }

            SHA1 sha1;
            ASCIIEncoding enc;
            string hash = "";
            try
            {
                sha1 = System.Security.Cryptography.SHA1.Create();
                enc = new ASCIIEncoding();
                var dataHashed = sha1.ComputeHash(enc.GetBytes(raw));
                hash = BitConverter.ToString(dataHashed).Replace("-", "").ToLower();
            }
            catch (Exception)
            {
                return "";
            }

            return hash;
        }

        /// <summary>
        /// 
        /// </summary>
        private class DictionarySort : System.Collections.IComparer
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
