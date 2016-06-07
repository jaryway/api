using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API.Qy.ThirdAuth
{
    /// <summary>
    /// 授权管理员的信息
    /// </summary>
    public class AuthUserInfo
    {
        /// <summary>
        /// 授权管理员的邮箱，可能为空（管理员通讯录中邮箱被清空）
        /// </summary>
        public string email { get; set; }
        /// <summary>
        /// 授权管理员的手机号，可能为空（管理员在通讯录中未设置手机号） 
        /// </summary>
        public string mobile { get; set; }
        /// <summary>
        /// 授权管理员的userid，可能为空（管理员不在通讯录中） 
        /// </summary>
        public string userid { get; set; }
    }
}
