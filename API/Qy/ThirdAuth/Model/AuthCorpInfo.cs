using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace API.Qy.ThirdAuth
{
    /// <summary>
    /// 授权方企业信息
    /// </summary>
    [Serializable]
    public class AuthCorpInfo
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
        /// <summary>
        /// 所绑定的企业号主体名称
        /// </summary>
        public string corp_full_name { get; set; }
        /// <summary>
        /// 认证到期时间
        /// </summary>
        public long verified_end_time { get; set; }
        /// <summary>
        /// 企业类型，1. 企业; 2. 政府以及事业单位; 3. 其他组织, 4.团队号 
        /// </summary>
        public string subject_type { get; set; }
        /// <summary>
        /// 授权方企业号二维码
        /// </summary>
        public string corp_wxqrcode { get; set; }
    }
}
