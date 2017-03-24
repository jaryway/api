using Api.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Api.Weixin.Mp.Open
{
    /// <summary>
    /// 刷新access_token（如果需要）
    /// </summary>
    public class RefreshSNSAccessTokenResult : JsonResult
    {
        /// <summary>
        /// 获取到的凭证
        /// </summary>
        public string access_token { get; set; }
        /// <summary>
        /// 凭证有效时间，单位：秒 
        /// </summary>
        public int expires_in { get; set; }
        /// <summary>
        /// 用户刷新access_token
        /// </summary>
        public string refresh_token { get; set; }
        /// <summary>
        /// 授权用户唯一标识
        /// </summary>
        public string openid { get; set; }
        /// <summary>
        /// 用户授权的作用域，使用逗号（,）分隔
        /// </summary>
        public string scope { get; set; }
    }
}
