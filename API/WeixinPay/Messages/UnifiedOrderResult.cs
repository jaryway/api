using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace API.WeixinPay
{
    /// <summary>
    /// 
    /// </summary>
    [XmlRoot("xml")]
    public class UnifiedOrderResult : WeixinPayResult
    {
        /// <summary>
        /// 公众账号ID
        /// </summary>
        public string appid { get; set; }
        /// <summary>
        /// 商户号
        /// </summary>
        public string mch_id { get; set; }
        /// <summary>
        /// 设备号
        /// </summary>
        public string device_info { get; set; }
        /// <summary>
        /// 随机字符串
        /// </summary>
        public string nonce_str { get; set; }
        ///// <summary>
        ///// 签名
        ///// </summary>
        //public string sign { get; set; }
        /// <summary>
        /// 业务结果
        /// </summary>
        public string result_code { get; set; }
        /// <summary>
        /// 错误代码
        /// </summary>
        public string err_code { get; set; }
        /// <summary>
        /// 错误代码描述
        /// </summary>
        public string err_code_des { get; set; }

        #region 以下字段在return_code 和result_code都为SUCCESS的时候有返回

        /// <summary>
        /// 交易类型，可选参数JSAPI、NATIVE、APP
        /// </summary>
        public string trade_type { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string prepay_id { get; set; }
        /// <summary>
        /// 二维码链接,trade_type为NATIVE时返回,注意：此处的二维码地址为NATIVE模式二的二维码地址，并非静态二维码
        /// </summary>
        public string code_url { get; set; }
        #endregion
    }
}
