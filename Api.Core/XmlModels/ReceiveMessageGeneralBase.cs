using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Api.Core.XmlModels
{
    /// <summary>
    /// 接收普通消息基础类
    /// </summary>
    public class ReceiveMessageGeneralBase : ReceiveMessageBase
    {
        /// <summary>
        /// 消息ID
        /// </summary>
        public string MsgId { get; set; }
    }
}
