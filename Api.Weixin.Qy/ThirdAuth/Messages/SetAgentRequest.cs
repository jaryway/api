using Api.Core;

namespace Api.Weixin.Qy.ThirdAuth
{
    /// <summary>
    /// 设置企业号应用
    /// </summary>
    public class SetAgentRequest : IRequest
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
        /// 永久授权码，从get_permanent_code接口中获取
        /// </summary>
        public string permanent_code { get; set; }
        /// <summary>
        /// 要设置的企业应用的信息
        /// </summary>
        public SetAgentInfo agent { get; set; }
    }

    /// <summary>
    /// 要设置的企业应用的信息
    /// </summary>
    public class SetAgentInfo
    {
        /// <summary>
        /// 企业应用的id 
        /// </summary>
        public int agentid { get; set; }
        /// <summary>
        /// 企业应用是否打开地理位置上报 0：不上报；1：进入会话上报；2：持续上报
        /// </summary>
        public int? report_location_flag { get; set; }
        /// <summary>
        /// 企业应用头像的mediaid，通过多媒体接口上传图片获得mediaid，上传后会自动裁剪成方形和圆形两个头像 
        /// </summary>
        public string logo_mediaid { get; set; }
        /// <summary>
        /// 企业应用名称
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 企业应用详情
        /// </summary>
        public string description { get; set; }
        /// <summary>
        /// 企业应用可信域名
        /// </summary>
        public string redirect_domain { get; set; }
        /// <summary>
        /// 是否接收用户变更通知。0：不接收；1：接收 
        /// </summary>
        public int isreportuser { get; set; }
        /// <summary>
        /// 是否上报用户进入应用事件。0：不接收；1：接收
        /// </summary>
        public int isreportenter { get; set; }
    }
}
