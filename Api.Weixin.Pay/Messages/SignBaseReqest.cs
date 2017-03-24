using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Api.Weixin.Pay
{
    public class SignBaseReqest
    {
        //internal SortedDictionary<string, string> dict = new SortedDictionary<string, string>();

        /// <summary>
        /// 签名字段
        /// </summary>
        public virtual string sign { get; private set; }

        /// <summary>
        /// 生成签名
        /// </summary>
        /// <param name="mchkey">商户支付密钥</param>
        /// <returns></returns>
        public void SetSign(string mchkey)
        {
            this.sign = MakeSign(mchkey);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public SortedDictionary<string, object> ToDict()
        {
            var dict = new SortedDictionary<string, object>();
            var properties = this.GetType().GetProperties();
            foreach (var item in properties)
            {
                //跳过 sign 字段
                var value = item.GetValue(this, null);
                if (item.Name == "sign" || value == null)
                    continue;

                var valueType = value.GetType();
                if (valueType.IsPrimitive || valueType.Equals(typeof(string)))
                {
                    //值为空跳过
                    if (string.IsNullOrEmpty(string.Format("{0}", value)))
                        continue;
                    dict.Add(item.Name, value);
                }
            }

            return dict;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string ToUrl()
        {
            var dict = ToDict();
            string url = "";
            foreach (var item in dict)
            {
                if (item.Key != "sign" && !string.IsNullOrEmpty(string.Format("{0}", item.Value)))
                    url += string.Format("{0}={1}", item.Key, item.Value);
            }
            // 去掉头尾的&
            return url.Trim('&');

        }

        public string ToXml()
        {
            var m_values = ToDict();
            //数据为空时不能转化为xml格式
            if (0 == m_values.Count)
            {
                throw new WxPayException("WxPayData数据为空!");
            }

            string xml = "<xml>";
            foreach (KeyValuePair<string, object> pair in m_values)
            {
                //字段值不能为null，会影响后续流程
                if (pair.Value == null)
                {
                    //Log.Error(this.GetType().ToString(), "WxPayData内部含有值为null的字段!");
                    throw new WxPayException("WxPayData内部含有值为null的字段!");
                }

                if (pair.Value.GetType() == typeof(int))
                {
                    xml += "<" + pair.Key + ">" + pair.Value + "</" + pair.Key + ">";
                }
                else if (pair.Value.GetType() == typeof(string))
                {
                    xml += "<" + pair.Key + ">" + "<![CDATA[" + pair.Value + "]]></" + pair.Key + ">";
                }
                else//除了string和int类型不能含有其他数据类型
                {
                    //Log.Error(this.GetType().ToString(), "WxPayData字段数据类型错误!");
                    throw new WxPayException("WxPayData字段数据类型错误!");
                }
            }
            xml += "</xml>";
            return xml;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mchkey"></param>
        /// <returns></returns>
        public string MakeSign(string mchkey)
        {
            //转url格式
            string str = ToUrl();
            //在string后加入API KEY
            str += "&key=" + mchkey;
            //MD5加密
            var md5 = MD5.Create();
            var bs = md5.ComputeHash(Encoding.UTF8.GetBytes(str));
            var sb = new StringBuilder();
            foreach (byte b in bs)
            {
                sb.Append(b.ToString("x2"));
            }
            //所有字符转为大写
            return sb.ToString().ToUpper();
        }
    }
}
