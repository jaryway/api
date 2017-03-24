using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Api.Weixin.Pay.Models;

namespace Api.Weixin.Pay
{
    /// <summary>
    /// 
    /// </summary>
    public class DefaultWePayConfigAdapter : IWePayConfigAdapter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public WePayConfig Get()
        {
            var config = new WePayConfig();
            config.APPID = System.Configuration.ConfigurationManager.AppSettings["wepay:appid"];
            config.KEY = System.Configuration.ConfigurationManager.AppSettings["wepay:key"];
            config.MCHID = System.Configuration.ConfigurationManager.AppSettings["wepay:mchid"];
            config.APPSECRET = System.Configuration.ConfigurationManager.AppSettings["wepay:appsecret"];
            config.NOTIFY_URL = System.Configuration.ConfigurationManager.AppSettings["wepay:notify_url"];
            config.SSLCERT_PATH = System.Configuration.ConfigurationManager.AppSettings["wepay:sslcert_path"];
            config.SSLCERT_PASSWORD = System.Configuration.ConfigurationManager.AppSettings["wepay:sslcert_password"];
            var s = System.Configuration.ConfigurationManager.AppSettings["wepay:report_levenl"];
            config.REPORT_LEVENL = int.Parse(string.IsNullOrEmpty(s) ? "0" : "1");
            return config;
        }
    }
}
