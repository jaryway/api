using Api.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Api.Weixin.Qy
{
    /// <summary>
    /// 
    /// </summary>
    public class OAuthAuthorizeResult : JsonResult
    {
        /// <summary>
        /// 
        /// </summary>
        public OAuthAuthorizeResult()
        {
            errcode = -1;
            errmsg = "无效";
            Target = "";
            UserId = "";
            DeviceId = "";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
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
