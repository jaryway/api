using Api.Core;
using System.Collections.Generic;

namespace Api.Weixin.Qy
{
    /// <summary>
    /// 获取企业号管理员登录信息
    /// </summary>
    public class GetLoginInfoResult : JsonResult
    {
        /// <summary>
        /// 是否系统管理员
        /// </summary>
        public bool is_sys { get; set; }
        /// <summary>
        /// 是否内部管理员
        /// </summary>
        public bool is_inner { get; set; }
        /// <summary>
        /// 登录管理员的信息
        /// </summary>
        public userInfo user_info { get; set; }
        /// <summary>
        /// 授权方企业信息
        /// </summary>
        public corpInfo corp_info { get; set; }

        /// <summary>
        /// 该管理员在该提供商中能使用的应用列表
        /// </summary>
        public IList<agentInfo> agent { get; set; }

        /// <summary>
        /// 该管理员拥有的通讯录权限
        /// </summary>
        public authInfo auth_info { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public class userInfo
        {
            /// <summary>
            /// 管理员邮箱
            /// </summary>
            public string email { get; set; }
            /// <summary>
            /// 该管理员的userid（仅为内部管理员时展示） 
            /// </summary>
            public string userid { get; set; }
            /// <summary>
            /// 该管理员的名字（仅为内部管理员时展示） 
            /// </summary>
            public string name { get; set; }
            /// <summary>
            /// 该管理员的头像（仅为内部管理员时展示） 
            /// </summary>
            public string avatar { get; set; }
            /// <summary>
            /// 该管理员的手机（仅为内部管理员时展示） 
            /// </summary>
            public string mobile { get; set; }
        }
        /// <summary>
        /// 授权方企业信息
        /// </summary>
        public class corpInfo
        {
            /// <summary>
            /// 授权方企业号id
            /// </summary>
            public string corpid { get; set; }
            /// <summary>
            /// 授权方企业号名称
            /// </summary>
            public string corp_name { get; set; }
            /// <summary>
            /// 授权方企业号类型，认证号：verified, 注册号：unverified，体验号：test
            /// </summary>
            public string corp_type { get; set; }
            /// <summary>
            /// 授权方企业号圆形头像
            /// </summary>
            public string corp_round_logo_url { get; set; }
            /// <summary>
            /// 授权方企业号方形头像
            /// </summary>
            public string corp_square_logo_url { get; set; }
            /// <summary>
            /// 授权方企业号用户规模
            /// </summary>
            public int corp_user_max { get; set; }
            /// <summary>
            /// 授权方企业号应用规模
            /// </summary>
            public int corp_agent_max { get; set; }
        }
        /// <summary>
        /// 该管理员在该提供商中能使用的应用列表
        /// </summary>
        public class agentInfo
        {
            /// <summary>
            /// 应用id 
            /// </summary>
            public int agentid { get; set; }
            /// <summary>
            /// 该管理员对应用的权限：1.管理权限，0.使用权限 
            /// </summary>
            public int auth_type { get; set; }
        }
        /// <summary>
        /// 该管理员拥有的通讯录权限
        /// </summary>
        public class authInfo
        {
            /// <summary>
            /// 
            /// </summary>
            public IList<departmentInfo> department { get; set; }
        }

        /// <summary>
        /// 
        /// </summary>
        public class departmentInfo
        {
            /// <summary>
            /// 
            /// </summary>
            public int id { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public bool writable { get; set; }
        }
    }
}