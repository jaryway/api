
using Api.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Api.Core.XmlModels
{
    /// <summary>
    /// 事件消息基础类
    /// </summary>
    [XmlRoot("xml")]
    public class ReceiveMessageEventBase : ReceiveMessageBase
    {
        /// <summary>
        /// 消息类型
        /// </summary>
        public override ReceiveMessageType MsgType { get { return ReceiveMessageType.@event; } }
        /// <summary>
        /// 事件类型
        /// </summary>
        public string Event { get; set; }

        /// <summary>
        /// 获取事件类型
        /// </summary>
        /// <returns></returns>
        public ReceiveEventType GetEventType()
        {
            var eventType = Event.ToLower();
            ReceiveEventType tempEventType;
            Enum.TryParse<ReceiveEventType>(eventType, out tempEventType);
            return tempEventType;
        }
    }
}
