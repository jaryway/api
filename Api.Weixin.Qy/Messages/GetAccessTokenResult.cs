using Api.Core;

namespace Api.Weixin.Qy
{
    /// <summary>
    /// 
    /// </summary>
    public class GetAccessTokenResult : JsonResult
    {
        /// <summary>
        /// 
        /// </summary>
        public string access_token { get; set; }
        /// <summary>
        /// 过期时间
        /// </summary>
        public int expires_in { get; set; }
    }
}