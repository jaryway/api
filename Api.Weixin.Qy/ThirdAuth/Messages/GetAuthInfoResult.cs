using Api.Core;

namespace Api.Weixin.Qy.ThirdAuth
{
    /// <summary>
    /// 获取企业号的授权信息 返回信息
    /// </summary>
    public class GetAuthInfoResult : JsonResult
    {
        /// <summary>
        /// 授权方企业信息
        /// </summary>
        public AuthCorpInfo corp_info { get; set; }
        /// <summary>
        /// 授权信息
        /// </summary>
        public AuthInfo auth_info { get; set; }
    }
}
