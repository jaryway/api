using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API.Mp
{
    /// <summary>
    /// 查询群发消息发送状态
    /// </summary>
    public class GetMassMessageResult : MpResult
    {
        /// <summary>
        /// 群发消息后返回的消息id 
        /// </summary>
        public long msg_id { get; set; }
        /// <summary>
        /// 消息发送后的状态，SEND_SUCCESS表示发送成功 
        /// </summary>
        public string msg_status { get; set; }
    }
}
