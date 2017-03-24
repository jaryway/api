using Api.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Api.Weixin.Mp.Open
{
    /// <summary>
    /// 
    /// </summary>
    public class RefreshAuthorizerTokenResult : JsonResult
    {
        /// <summary>
        /// 授权方令牌（在授权的公众号具备API权限时，才有此返回值）
        /// </summary>
        public string authorizer_access_token { get; set; }
        /// <summary>
        /// 有效期（在授权的公众号具备API权限时，才有此返回值）
        /// </summary>
        public int expires_in { get; set; }
        /// <summary>
        /// 刷新令牌（在授权的公众号具备API权限时，才有此返回值），刷新令牌主要用于公众号第三方平台获取和刷新已授权用户的access_token，只会在授权时刻提供，请妥善保存。 一旦丢失，只能让用户重新授权，才能再次拿到新的刷新令牌
        /// </summary>
        public string authorizer_refresh_token { get; set; }
    }
}
