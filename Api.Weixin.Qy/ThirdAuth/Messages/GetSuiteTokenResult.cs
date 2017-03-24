using Api.Core;

namespace Api.Weixin.Qy.ThirdAuth
{
    /// <summary>
    /// 获取应用套件令牌，返回信息
    /// </summary>
    public class GetSuiteTokenResult : JsonResult
    {
        /// <summary>
        /// 应用套件access_token
        /// </summary>
        public string suite_access_token { get; set; }
        /// <summary>
        /// 有效期
        /// </summary>
        public int expires_in { get; set; }
    }
}
