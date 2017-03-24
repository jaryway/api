using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Api.Weixin.Pay.Fields
{
    /// <summary>
    /// 
    /// </summary>
    public class DownloadBillFields
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
        /// 对账单日期
        /// </summary>
        public const string bill_date = "bill_date";
        /// <summary>
        /// 账单类型
        /// </summary>
        public const string bill_type = "bill_type";
        /// <summary>
        /// 压缩账单
        /// </summary>
        public const string tar_type = "tar_type";
    }
}
