using Api.Core;

namespace Api.Weixin.Qy.ThirdAuth
{
    /// <summary>
    /// 获取企业号的授权信息所需参数
    /// </summary>
    public class GetAuthInfoRequest : IRequest
    {
        /// <summary>
        /// 应用套件id 
        /// </summary>
        public string suite_id { get; set; }
        /// <summary>
        /// 授权方corpid
        /// </summary>
        public string auth_corpid { get; set; }
        /// <summary>
        /// 永久授权码，通过get_permanent_code获取
        /// </summary>
        public string permanent_code { get; set; }
    }
}
