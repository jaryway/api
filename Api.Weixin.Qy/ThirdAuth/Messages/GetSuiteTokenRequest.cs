using Api.Core;

namespace Api.Weixin.Qy.ThirdAuth
{
    /// <summary>
    /// 获取应用套件令牌所需参数
    /// </summary>
    public class GetSuiteTokenRequest : IRequest
    {
        /// <summary>
        /// 应用套件id 
        /// </summary>
        public string suite_id { get; set; }
        /// <summary>
        /// 应用套件secret 
        /// </summary>
        public string suite_secret { get; set; }
        /// <summary>
        /// 微信后台推送的ticket 
        /// </summary>
        public string suite_ticket { get; set; }
    }
}
