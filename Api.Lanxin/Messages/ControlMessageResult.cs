using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Lanxin.Messages
{
    /// <summary>
    /// 查询消息送达、已读状态
    /// </summary>
    public class ControlMessageResult : JsonResult
    {
        public IList<MsgSendStateInfo> msgSendStateList { get; set; }
    }

    /// <summary>
    /// 查询消息状态信息
    /// </summary>
    public class MsgSendStateInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 发送状态
        /// </summary>
        public int sendingState { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        public int mobile { get; set; }
        /// <summary>
        /// Appid
        /// </summary>
        public int dialogId { get; set; }
        /// <summary>
        /// 发送时间
        /// </summary>
        public long sendTime { get; set; }
        /// <summary>
        /// 消息ID
        /// </summary>
        public int userMessageId { get; set; }
        /// <summary>
        /// 到达时间
        /// </summary>
        public long recieveTime { get; set; }
        /// <summary>
        /// 消息体ID
        /// </summary>
        public int userMessageBodyId { get; set; }
        /// <summary>
        /// 阅读时间
        /// </summary>
        public long readTime { get; set; }
    }
}
