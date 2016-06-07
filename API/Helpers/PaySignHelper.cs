using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API.Helpers
{
    /// <summary>
    /// 签名帮助类，用于微信支付生签名
    /// </summary>
    public class PaySignHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dic"></param>
        /// <param name="apiSecret"></param>
        /// <returns></returns>
        public static string Generate(IDictionary<string, string> dic, string apiSecret)
        {
            string sign = string.Empty;

            dic = dic.Where(p => !string.IsNullOrEmpty(p.Value))
                .OrderBy(p => p.Key).ToDictionary(k => k.Key, v => v.Value);
            var list = dic.Select(p => string.Format("{0}={1}", p.Key, p.Value)).ToArray();
            var parms = string.Join("&", list);
            //签名步骤二：在string后加入KEY
            parms = string.Format("{0}&key={1}", parms, apiSecret);
            //签名步骤三：MD5加密，并转成大写
            var md5 = System.Security.Cryptography.MD5.Create();
            byte[] dataBytes = UTF8Encoding.UTF8.GetBytes(parms);
            var hashBytes = md5.ComputeHash(dataBytes);
            sign = BitConverter.ToString(hashBytes).Replace("-", "").ToUpper();

            return sign;
        }

        /// <summary>
        /// 生成签名
        /// </summary>
        /// <param name="parms"></param>
        /// <param name="apiSecret">API密钥(商户支付密钥)</param>
        /// <returns></returns>
        public static string Generate(string parms, string apiSecret)
        {
            //a.对所有传入参数按照字段名的ASCII码从小到大排序(字典序)后，使用URL键值对的格式（即 key1=value1&key2=value2…）拼接成字符串string1,注意:值为空的参数不与签名；
            //b.在string1最后拼接上key=Key(商户支付密钥)得到stringSignTemp字符串，并对stringSignTemp进行md5运算，再将得到的字符串所有字符转换为大写，得到 sign值 signValue。
            string sign = string.Empty;
            //签名步骤一：按字典序排序参数
            var list = parms.Split(new char[] { '&' });
            IDictionary<string, string> dic = new Dictionary<string, string>();
            foreach (var item in list)
            {
                var temp = item.Split(new char[] { '=' });
                if (!string.IsNullOrEmpty(temp[1]))
                    dic.Add(temp[0], temp[1]);
            }
            sign = Generate(dic, apiSecret);

            return sign;
        }
    }
}
