using Api.Core;

namespace Api.Weixin.Qy.ThirdAuth
{
    /// <summary>
    /// 获取企业号应用所需参数
    /// </summary>
    public class GetAgentRequest : IRequest
    {
        /// <summary>
        ///  应用套件id 
        /// </summary>
        public string suite_id { get; set; }
        /// <summary>
        /// 授权方corpid
        /// </summary>
        public string auth_corpid { get; set; }
        /// <summary>
        /// 永久授权码，从get_permanent_code接口中获取
        /// </summary>
        public string permanent_code { get; set; }
        /// <summary>
        /// 授权方应用id
        /// </summary>
        public string agentid { get; set; }
    }
}
