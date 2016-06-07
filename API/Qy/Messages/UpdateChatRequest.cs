using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API.Qy
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateChatRequest : IRequest
    {
        /// <summary>
        /// 会话id 
        /// </summary>
        public string chatid { get; set; }
        /// <summary>
        /// 操作人userid
        /// </summary>
        public string op_user { get; set; }
        /// <summary>
        /// 会话标题 
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 管理员userid，必须是该会话userlist的成员之一
        /// </summary>
        public string owner { get; set; }
        /// <summary>
        /// 会话新增成员列表，成员用userid来标识 
        /// </summary>
        public string[] add_user_list { get; set; }
        /// <summary>
        /// 会话退出成员列表，成员用userid来标识
        /// </summary>
        public string[] del_user_list { get; set; }
    }
}
