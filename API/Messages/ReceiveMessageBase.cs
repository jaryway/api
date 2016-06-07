using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using API.Helpers;

namespace API
{
    /// <summary>
    /// 接收消息基础类
    /// </summary>
    [XmlRoot("xml")]
    public class ReceiveMessageBase : IReceiveMessage
    {
        /// <summary>
        /// 企业号CorpID 
        /// </summary>
        public string ToUserName { get; set; }
        /// <summary>
        /// 员工UserID 
        /// </summary>
        public string FromUserName { get; set; }
        /// <summary>
        /// 消息创建时间（整型） 
        /// </summary>
        public double CreateTime { get; set; }
        /// <summary>
        /// 消息类型
        /// </summary>
        public virtual ReceiveMessageType MsgType { get; set; }
        /// <summary>
        /// 企业应用的id，整型。可在应用的设置页面查看
        /// </summary>
        public int AgentID { get; set; }
        ///// <summary>
        ///// 消息id，64位整型 
        ///// </summary>
        //public long MsgId { get; set; }
        /// <summary>
        /// 获取真实Model 之后可以使用 as xxxx 转成真实model
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
        public IReceiveMessage GetRealModel(string xml)
        {
            switch (GetMessageType())
            {
                default:
                case ReceiveMessageType.text:
                    return XmlHelper.Deserialize<ReceiveMessageText>(xml);
                case ReceiveMessageType.image:
                    return XmlHelper.Deserialize<ReceiveMessageImage>(xml);
                case ReceiveMessageType.voice:
                    return XmlHelper.Deserialize<ReceiveMessageVoice>(xml);
                case ReceiveMessageType.video:
                    return XmlHelper.Deserialize<ReceiveMessageVideo>(xml);
                case ReceiveMessageType.location:
                    return XmlHelper.Deserialize<ReceiveMessageLocation>(xml);
                case ReceiveMessageType.@event:
                    var eventBaseModel = XmlHelper.Deserialize<ReceiveMessageEventBase>(xml);
                    switch (eventBaseModel.GetEventType())
                    {
                        case ReceiveEventType.click:
                        case ReceiveEventType.view:
                            return XmlHelper.Deserialize<ReceiveMessageMenuEvent>(xml);
                        //break;
                        case ReceiveEventType.subscribe:
                            //return XmlSerializerUtility.Deserialize<WeixinReceiveMessageMenuEventModel>(xml);
                            break;
                        case ReceiveEventType.unsubscribe:
                            break;
                        case ReceiveEventType.LOCATION:
                            break;
                        case ReceiveEventType.scancode_push:
                            break;
                        case ReceiveEventType.scancode_waitmsg:
                            break;
                        case ReceiveEventType.pic_sysphoto:
                            break;
                        case ReceiveEventType.pic_photo_or_album:
                            break;
                        case ReceiveEventType.location_select:
                            break;
                        default:
                            break;
                    }
                    return eventBaseModel;
            }

        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ReceiveMessageType GetMessageType()
        {
            return MsgType;
            //var messageType = MsgType.ToLower();
            //ReceiveMessageType tempMessageType;
            //Enum.TryParse<ReceiveMessageType>(messageType, out tempMessageType);
            //return tempMessageType;
        }
    }
}
