using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API.Qy
{
    /// <summary>
    /// 会话信息
    /// </summary>
    public class CreateChatRequest
    {
        /// <summary>
        /// 会话id 
        /// </summary>
        public string chatid { get; set; }
        /// <summary>
        /// 会话标题
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 管理员userid 
        /// </summary>
        public string owner { get; set; }
        /// <summary>
        ///  会话成员列表，成员用userid来标识 
        /// </summary>
        public string[] userlist { get; set; }
    }
}
