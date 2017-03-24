using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Api.Weixin.Pay
{
    /// <summary>
    /// 申请退款
    /// </summary>
    public class RefundFields
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
        /// 设备号
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
        /// 微信的订单号(二选一)，优先使用。
        /// </summary>
        public const string transaction_id = "transaction_id";
        /// <summary>
        /// 商户订单号(二选一),商户系统内部的订单号，当没提供transaction_id时需要传这个。
        /// </summary>
        public const string out_trade_no = "out_trade_no";
        /// <summary>
        /// 商户退款单号，商户系统内部的退款单号，商户系统内部唯一，同一退款单号多次请求只退一笔
        /// </summary>
        public const string out_refund_no = "out_refund_no";
        /// <summary>
        /// 订单金额，订单总金额，单位为分，只能为整数
        /// </summary>
        public const string total_fee = "total_fee";
        /// <summary>
        /// 退款金额
        /// </summary>
        public const string refund_fee = "refund_fee";
        /// <summary>
        /// 货币种类
        /// </summary>
        public const string refund_fee_type = "refund_fee_type";
        /// <summary>
        /// 操作员
        /// </summary>
        public const string op_user_id = "op_user_id";
        /// <summary>
        /// 退款资金来源
        /// </summary>
        public const string refund_account = "refund_account";

    }
}
