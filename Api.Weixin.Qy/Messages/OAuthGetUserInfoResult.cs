using Api.Core;

namespace Api.Weixin.Qy
{
    /// <summary>
    /// 
    /// </summary>
    public class OAuthGetUserInfoResult : JsonResult
    {
        /// <summary>
        ///  员工UserID 
        /// </summary>
        public string UserId { get; set; }
        /// <summary>
        /// 手机设备号(由微信在安装时随机生成)
        /// </summary>
        public string DeviceId { get; set; }
    }
}
