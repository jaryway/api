using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Api.Weixin.Pay.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class WePayConfig
    {
        /// <summary>
        /// 绑定支付的APPID（必须配置）
        /// </summary>
        public string APPID { get; set; }
        /// <summary>
        /// 商户号（必须配置）
        /// </summary>
        public string MCHID { get; set; }
        /// <summary>
        /// 商户支付密钥，参考开户邮件设置（必须配置）
        /// </summary>
        public string KEY { get; set; }
        /// <summary>
        /// 公众帐号SECERT（仅JSAPI支付的时候需要配置）
        /// </summary>
        public string APPSECRET { get; set; }
        /// <summary>
        /// 支付结果通知回调url，用于商户接收支付结果
        /// e.g.http://paysdk.weixin.qq.com/example/ResultNotifyPage.aspx
        /// </summary>
        public string NOTIFY_URL { get; set; }
        /// <summary>
        /// 证书地址，相对地址
        /// e.g. "cert/apiclient_cert.p12"
        /// </summary>
        public string SSLCERT_PATH { get; set; }
        /// <summary>
        /// 证书密码
        /// </summary>
        public string SSLCERT_PASSWORD { get; set; }
        /// <summary>
        /// 是否上报测试,0=不上报，1=上报
        /// </summary>
        public int REPORT_LEVENL { get; set; }


    }
}
