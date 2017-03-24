using Api.Core;

namespace Api.Weixin.Qy.ThirdAuth
{
    /// <summary>
    /// 获取企业号access_token
    /// </summary>
    public class GetCorpTokenResult : JsonResult
    {
        /// <summary>
        /// 授权方（企业）access_token 
        /// </summary>
        public string access_token { get; set; }
        /// <summary>
        /// 授权方（企业）access_token超时时间 
        /// </summary>
        public int expires_in { get; set; }
    }
}
