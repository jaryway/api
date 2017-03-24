using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Api.Weixin.Qy
{
    /// <summary>
    /// 
    /// </summary>
    public class AgentInfo
    {
        /// <summary>
        /// 应用id
        /// </summary>
        public string agentid { get; set; }
        /// <summary>
        /// 应用名称
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 方形头像url
        /// </summary>
        public string square_logo_url { get; set; }
        /// <summary>
        /// 圆形头像url
        /// </summary>
        public string round_logo_url { get; set; }
    }
}
