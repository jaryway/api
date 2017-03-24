
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Api.Weixin.Pay
{
    /// <summary>
    /// 
    /// </summary>
    [XmlRoot("xml")]
    public class UnifiedOrderRequest : SignBaseReqest
    {
        private string m_appid;
        /// <summary>
        /// 公众账号ID
        /// </summary>
        public string appid
        {
            get { return m_appid; }
            set { m_appid = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        //public string appid { get; set; }
        /// <summary>
        /// 商户号
        /// </summary>
        public string mch_id { get; set; }
        /// <summary>
        /// 设备号，如001号收银台
        /// </summary>
        public string device_info { get; set; }
        /// <summary>
        /// 随机字符串
        /// </summary>
        public string nonce_str { get; set; }
        /// <summary>
        /// 商品描述
        /// </summary>
        public string body { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string detail { get; set; }
        /// <summary>
        /// 附加数据
        /// </summary>
        public string attach { get; set; }
        /// <summary>
        /// 货币类型
        /// 符合ISO 4217标准的三位字母代码，默认人民币：CNY，其他值列表详见货币类型
        /// </summary>
        public string fee_type { get; set; }
        /// <summary>
        /// 商户订单号
        /// </summary>
        public string out_trade_no { get; set; }
        /// <summary>
        /// 总金额,订单总金额，单位为分，不能带小数点
        /// </summary>
        public int total_fee { get; set; }
        /// <summary>
        /// 终端IP,订单生成的机器IP
        /// </summary>
        public string spbill_create_ip { get; set; }
        /// <summary>
        /// 订单生成时间，格式为yyyyMMddHHmmss,该时间取自商户服务器
        /// </summary>
        public string time_start { get; set; }
        /// <summary>
        /// 交易结束时间
        /// </summary>
        public string time_expire { get; set; }
        /// <summary>
        /// 商品标记
        /// </summary>
        public string goods_tag { get; set; }
        /// <summary>
        /// 通知地址
        /// </summary>
        public string notify_url { get; set; }
        /// <summary>
        /// 交易类型，可选参数 JSAPI、NATIVE、APP
        /// </summary>
        public string trade_type { get; set; }
        /// <summary>
        /// 用户标识,trade_type=JSAPI，此参数必传，用户在商户appid下的唯一标识。
        /// </summary>
        public string openid { get; set; }
        /// <summary>
        /// 商品ID,只在trade_type为NATIVE时需要填写。此id为二维码中包含的商品ID，商户自行维护。
        /// </summary>
        public string product_id { get; set; }


    }
}
