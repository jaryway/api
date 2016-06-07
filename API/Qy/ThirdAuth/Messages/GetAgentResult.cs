using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API.Qy.ThirdAuth
{
    /// <summary>
    /// 获取企业号应用，返回信息
    /// </summary>
    public class GetAgentResult : QyResult
    {
        public GetAgentResult()
        {
            report_location_flag = null;
        }
        /// <summary>
        /// 授权方企业应用id
        /// </summary>
        public int agentid { get; set; }
        /// <summary>
        /// 授权方企业应用名称
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 授权方企业应用方形头像
        /// </summary>
        public string square_logo_url { get; set; }
        /// <summary>
        /// 授权方企业应用圆形头像
        /// </summary>
        public string round_logo_url { get; set; }
        /// <summary>
        /// 授权方企业应用详情
        /// </summary>
        public string description { get; set; }
        /// <summary>
        /// 授权方企业应用可见范围（人员），其中包括userid和关注状态state
        /// </summary>
        public AllowUserInfos allow_userinfos { get; set; }
        /// <summary>
        /// 授权方企业应用可见范围（部门）
        /// </summary>
        public AllowPartys allow_partys { get; set; }
        /// <summary>
        /// 授权方企业应用可见范围（标签）
        /// </summary>
        public AllowTags allow_tags { get; set; }
        /// <summary>
        /// 授权方企业应用是否被禁用
        /// </summary>
        public int close { get; set; }
        /// <summary>
        /// 授权方企业应用可信域名
        /// </summary>
        public string redirect_domain { get; set; }
        /// <summary>
        /// 授权方企业应用是否打开地理位置上报 null：不设置；0：不上报；1：进入会话上报；2：持续上报
        /// </summary>
        public int? report_location_flag { get; set; }
        /// <summary>
        /// 是否接收用户变更通知。0：不接收；1：接收
        /// </summary>
        public int isreportuser { get; set; }
        /// <summary>
        /// 是否上报用户进入应用事件。0：不接收；1：接收
        /// </summary>
        public int isreportenter { get; set; }
        /// <summary>
        /// 应用类型。1：消息型；2：主页型 
        /// </summary>
        public int type { get; set; }
    }

    #region subclass
    /// <summary>
    /// 授权方企业应用可见范围（人员），其中包括userid和关注状态state 
    /// </summary>
    public class AllowUserInfos
    {
        public List<AllowUserInfo> user { get; set; }
    }

    /// <summary>
    /// 授权方企业应用可见范围（人员），其中包括userid和关注状态state 
    /// </summary>
    public class AllowUserInfo
    {
        /// <summary>
        /// userId
        /// </summary>
        public string userid { get; set; }
        /// <summary>
        /// 关注状态
        /// </summary>
        public string status { get; set; }
    }

    /// <summary>
    /// 授权方企业应用可见范围（部门）
    /// </summary>
    public class AllowPartys
    {
        /// <summary>
        /// 
        /// </summary>
        public List<int> partyid { get; set; }
    }

    /// <summary>
    /// 授权方企业应用可见范围（标签） 
    /// </summary>
    public class AllowTags
    {
        /// <summary>
        /// 标签
        /// </summary>
        public List<int> tagid { get; set; }
    }
    #endregion
}
