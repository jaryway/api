using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Api.Weixin.Pay
{
    /// <summary>
    /// 
    /// </summary>
    public class OrderQueryFields
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
        /// 微信的订单号(二选一)，优先使用。
        /// </summary>
        public const string transaction_id = "transaction_id";
        /// <summary>
        /// 商户订单号(二选一),商户系统内部的订单号，当没提供transaction_id时需要传这个。
        /// </summary>
        public const string out_trade_no = "out_trade_no";
        /// <summary>
        /// 随机字符串,随机字符串，不长于32位。
        /// </summary>
        public const string nonce_str = "nonce_str";
        /// <summary>
        /// 签名
        /// </summary>
        public const string sign = "sign";
    }
}
