using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Api.Weixin.Pay
{
    /// <summary>
    /// 
    /// </summary>
    public class UnifiedOrderFields
    {
        /// <summary>
        /// 公众账号ID,微信分配的公众账号ID（企业号corpid即为此appId）
        /// </summary>
        public const string appid = "appid";
        /// <summary>
        /// 商户号,微信支付分配的商户号
        /// </summary>
        public const string mch_id = "mch_id";
        /// <summary>
        /// 设备号,终端设备号(门店号或收银设备ID)，注意：PC网页或公众号内支付请传"WEB"
        /// </summary>
        public const string device_info = "device_info";
        /// <summary>
        /// 随机字符串,随机字符串，不长于32位。
        /// </summary>
        public const string nonce_str = "nonce_str";
        /// <summary>
        /// 签名
        /// </summary>
        public const string sign = "sign";
        /// <summary>
        /// 商品描述，该字段须严格按照规范传递，具体请见参数规定
        /// </summary>
        public const string body = "body";
        /// <summary>
        /// 商品详情
        /// </summary>
        public const string detail = "detail";
        /// <summary>
        /// 附加数据
        /// </summary>
        public const string attach = "attach";
        /// <summary>
        /// 商户订单号,商户系统内部的订单号,32个字符内、可包含字母, 其他说明见商户订单号
        /// </summary>
        public const string out_trade_no = "out_trade_no";
        /// <summary>
        /// 货币类型,符合ISO 4217标准的三位字母代码，默认人民币：CNY，其他值列表详见货币类型
        /// </summary>
        public const string fee_type = "fee_type";
        /// <summary>
        /// 总金额,订单总金额，单位为分
        /// </summary>
        public const string total_fee = "total_fee";
        /// <summary>
        /// 终端IP,APP和网页支付提交用户端ip，Native支付填调用微信支付API的机器IP。
        /// </summary>
        public const string spbill_create_ip = "spbill_create_ip";
        /// <summary>
        /// 交易起始时间
        /// </summary>
        public const string time_start = "time_start";
        /// <summary>
        /// 交易结束时间
        /// </summary>
        public const string time_expire = "time_expire";
        /// <summary>
        /// 商品标记
        /// </summary>
        public const string goods_tag = "goods_tag";
        /// <summary>
        /// 通知地址
        /// </summary>
        public const string notify_url = "notify_url";
        /// <summary>
        /// 交易类型
        /// </summary>
        public const string trade_type = "trade_type";
        /// <summary>
        /// 商品ID,trade_type=NATIVE，此参数必传。此id为二维码中包含的商品ID，商户自行定义。
        /// </summary>
        public const string product_id = "product_id";
        /// <summary>
        /// 指定支付方式， no_credit--指定不能使用信用卡支付
        /// </summary>
        public const string limit_pay = "limit_pay";
        /// <summary>
        /// 用户标识 trade_type=JSAPI，此参数必传，用户在商户appid下的唯一标识。
        /// </summary>
        public const string openid = "openid";

    }
}
