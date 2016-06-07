using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace API.Qy.ThirdAuth
{
    /// <summary>
    /// 授权的应用信息，用于授权应用
    /// </summary>
    [Serializable]
    public class AuthAgent
    {
        /// <summary>
        /// 授权方应用id 
        /// </summary>
        public int agentid { get; set; }
        /// <summary>
        /// 授权方应用名字
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 授权方应用方形头像
        /// </summary>
        public string square_logo_url { get; set; }
        /// <summary>
        /// 授权方应用圆形头像
        /// </summary>
        public string round_logo_url { get; set; }
        /// <summary>
        /// 服务商套件中的对应应用id  
        /// </summary>
        public int appid { get; set; }
        /// <summary>
        /// 授权方应用敏感权限组，目前仅有get_location，表示是否有权限设置应用获取地理位置的开关 
        /// </summary>
        public string[] api_group { get; set; }
    }
}
