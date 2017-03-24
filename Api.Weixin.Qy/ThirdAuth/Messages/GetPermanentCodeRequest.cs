using Api.Core;

namespace Api.Weixin.Qy.ThirdAuth
{
    /// <summary>
    /// 获取企业号的永久授权码，所需参数
    /// </summary>
    public class GetPermanentCodeRequest : IRequest
    {
        /// <summary>
        /// 应用套件id 
        /// </summary>
        public string suite_id { get; set; }
        /// <summary>
        /// 临时授权码会在授权成功时附加在redirect_uri中跳转回应用提供商网站。
        /// </summary>
        public string auth_code { get; set; }
    }

}
