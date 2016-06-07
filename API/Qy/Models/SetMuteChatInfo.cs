using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API.Qy
{
    /// <summary>
    /// 
    /// </summary>
    public class SetMuteChatInfo
    {
        /// <summary>
        /// 成员UserID 
        /// </summary>
        public string userid { get; set; }
        /// <summary>
        /// 免打扰状态，0关闭，1打开,默认为0。当打开时所有消息不提醒；当关闭时，以成员对会话的设置为准。 
        /// </summary>
        public int status { get; set; }
    }
}
