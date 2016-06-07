using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API.Mp
{
    /// <summary>
    /// 群发消息结果
    /// </summary>
    public class SendMassMessageResult : MpResult
    {
        /// <summary>
        /// 消息ID
        /// </summary>
        public int msg_id { get; set; }
    }
}
