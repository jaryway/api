using API.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API.WeixinPay
{
    public class Signable
    {

        /// <summary>
        /// 签名，请调用GenerateSign赋值
        /// </summary>
        public virtual string sign { get; set; }
        /// <summary>
        /// 获取签名所需参数
        /// </summary>
        /// <returns></returns>
        public virtual Dictionary<string, string> GetSignParams()
        {
            var dic = new Dictionary<string, string>();
            var properties = this.GetType().GetProperties();
            foreach (var item in properties)
            {
                //跳过 sign 字段
                if (item.Name == "sign")
                    continue;
                var objValue = item.GetValue(this, null);
                if (objValue == null)
                    continue;

                var objValueType = objValue.GetType();
                if (objValueType.IsPrimitive || objValueType.Equals(typeof(string)))
                {
                    var value = string.Format("{0}", item.GetValue(this, null));
                    //值为空跳过
                    if (string.IsNullOrEmpty(value))
                        continue;
                    dic.Add(item.Name, item.GetValue(this, null).ToString());
                }
            }

            return dic;
        }

        /// <summary>
        /// 生成签名
        /// </summary>
        /// <param name="apiSecret">API密钥</param>
        /// <returns></returns>
        public virtual void GenerateSign(string apiSecret)
        {
            this.sign = PaySignHelper.Generate(GetSignParams(), apiSecret);
        }
    }
}
