using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace API.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    public class SignHelper
    {
        /// <summary>
        /// 在网站没有提供Token（或传入为null）的情况下的默认Token，建议在网站中进行配置。
        /// </summary>
        public const string Token = "weixin";

        /// <summary>
        /// 检查签名是否正确
        /// </summary>
        /// <param name="signature"></param>
        /// <param name="timestamp"></param>
        /// <param name="nonce"></param>
        /// <param name="token"></param>
        /// <param name="others">其他别的参数</param>
        /// <returns></returns>
        public static bool Check(string signature, string timestamp, string nonce, string token, params string[] others)
        {
            return signature == Generate(timestamp, nonce, token);
        }

        /// <summary>
        /// 生成签名
        /// </summary>
        /// <param name="timestamp"></param>
        /// <param name="nonce"></param>
        /// <param name="token"></param>
        /// <param name="others">其他别的参数</param>
        /// <returns></returns>
        public static string Generate(string timestamp, string nonce, string token, params string[] others)
        {
            token = token ?? Token;

            ArrayList arrayList = new ArrayList();
            arrayList.Add(token);
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

        /// <summary>
        /// 生成JSAPI签名
        /// </summary>
        /// <param name="timestamp"></param>
        /// <param name="nonceStr"></param>
        /// <param name="jsapi_ticket"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string DTalkJSAPIGenerate(string timestamp, string nonceStr, string jsapi_ticket, string url)
        {

            /*timestamp = "1439386491.99038";
            nonceStr = "Zn4zmLFKD0wzilzM";
            jsapi_ticket = "3y1eOaXvo2QgQmiMFUTmqSOo93xKB3ZTK4y6kJYcTlZYvfMJCA9vy0DerMmNKKydM0qHiOQBq5DUxKHEVDni3I";
            url = "http://dtalk.tunnel.mobi";*/

            var arr = new[] { jsapi_ticket, nonceStr, timestamp, url };
            var arrString = string.Format("jsapi_ticket={0}&noncestr={1}&timestamp={2}&url={3}", arr);
            var enc = new ASCIIEncoding();
            var sha1 = System.Security.Cryptography.SHA1.Create();
            var sha1Arr = sha1.ComputeHash(enc.GetBytes(arrString));

            //var signature = BitConverter.ToString(sha1Arr).Replace("-", "").ToLower();
            return BitConverter.ToString(sha1Arr).Replace("-", "").ToLower();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="timestamp"></param>
        /// <param name="nonceStr"></param>
        /// <param name="jsapi_ticket"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string JSAPIGenerate(string timestamp, string nonceStr, string jsapi_ticket, string url)
        {

            /*timestamp = "1439386491.99038";
            nonceStr = "Zn4zmLFKD0wzilzM";
            jsapi_ticket = "3y1eOaXvo2QgQmiMFUTmqSOo93xKB3ZTK4y6kJYcTlZYvfMJCA9vy0DerMmNKKydM0qHiOQBq5DUxKHEVDni3I";
            url = "http://dtalk.tunnel.mobi";*/

            var arr = new[] { jsapi_ticket, nonceStr, timestamp, url };
            var arrString = string.Format("jsapi_ticket={0}&noncestr={1}&timestamp={2}&url={3}", arr);
            var enc = new ASCIIEncoding();
            var sha1 = System.Security.Cryptography.SHA1.Create();
            var sha1Arr = sha1.ComputeHash(enc.GetBytes(arrString));

            //var signature = BitConverter.ToString(sha1Arr).Replace("-", "").ToLower();
            return BitConverter.ToString(sha1Arr).Replace("-", "").ToLower();
        }

        /// <summary>
        /// 生成时间戳
        /// </summary>
        /// <param name="date">编码的长度</param>
        /// <returns></returns>
        public static string GetTimestamp(DateTime date)
        {
            var dateutc = new DateTime(1970, 1, 1);
            return string.Format("{0}", (date.ToUniversalTime() - dateutc).TotalSeconds);
        }

        /// <summary>
        /// 生成时间戳
        /// </summary>
        /// <returns></returns>
        public static string GetTimestamp()
        {
            //时间戳是指格林威治时间1970年01月01日00时00分00秒(北京时间1970年01月01日08时00分00秒)起至现在的总秒数。
            var dateutc = new DateTime(1970, 1, 1);
            return string.Format("{0}", (DateTime.UtcNow - dateutc).TotalSeconds);
        }
    }


}
