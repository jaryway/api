using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API.Qy
{
    public class OAuthAuthorizeResult : APIJsonResult
    {
        public OAuthAuthorizeResult()
        {
            errcode = -1;
            errmsg = "无效";
            Target = "";
            UserId = "";
            DeviceId = "";
        }

        public static OAuthAuthorizeResult New()
        {
            return new OAuthAuthorizeResult
            {
                errcode = -1,
                errmsg = "无效",
                Target = "",
                UserId = "",
                DeviceId = ""
            };
        }
        /// <summary>
        ///  员工UserID 
        /// </summary>
        public string UserId { get; set; }
        /// <summary>
        /// 手机设备号(由微信在安装时随机生成)
        /// </summary>
        public string DeviceId { get; set; }
        /// <summary>
        /// 目标页面URL
        /// </summary>
        public string Target { get; set; }
    }
}
