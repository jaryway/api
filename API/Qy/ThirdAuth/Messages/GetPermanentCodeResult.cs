using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace API.Qy.ThirdAuth
{
    /// <summary>
    /// 获取企业号的永久授权码，返回信息
    /// </summary>
    [Serializable]
    public class GetPermanentCodeResult : QyResult
    {
        /// <summary>
        /// 授权方（企业）access_token 
        /// </summary>
        public string access_token { get; set; }
        /// <summary>
        /// 授权方（企业）access_token超时时间 
        /// </summary>
        public int expires_in { get; set; }
        /// <summary>
        /// 企业号永久授权码
        /// </summary>
        public string permanent_code { get; set; }
        /// <summary>
        /// 授权方企业信息
        /// </summary>
        public AuthCorpInfo auth_corp_info { get; set; }
        /// <summary>
        /// 授权信息
        /// </summary>
        public AuthInfo auth_info { get; set; }
        /// <summary>
        /// 授权管理员的信息
        /// </summary>
        public AuthUserInfo auth_user_info { get; set; }
    }
}
