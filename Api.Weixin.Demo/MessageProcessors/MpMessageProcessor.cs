using Api.Core.Enums;
using Api.Core.Helpers;
using Api.Core.XmlModels;
using Api.Weixin.Demo.MessageProcessors.Hanlders;

namespace Api.Weixin.Demo.MessageProcessors
{
    /// <summary>
    /// 
    /// </summary>
    public class MpMessageProcessor : IMessageProcessor
    {
        private IReceiveMessage _receiveMessage;
        private string _xmlMessage;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="xmlMessage"></param>
        public MpMessageProcessor(string xmlMessage)
        {
            _xmlMessage = xmlMessage;
        }

        /// <summary>
        /// 处理消息并返回被动消息
        /// </summary>
        /// <returns></returns>
        public IResponseMessage Process()
        {
            var messageHandler = new MpMessageHandler();
            _receiveMessage = XmlHelper.Deserialize<ReceiveMessageBase>(_xmlMessage);

            switch (_receiveMessage.MsgType)
            {
                case ReceiveMessageType.text:
                    _receiveMessage = XmlHelper.Deserialize<ReceiveMessageText>(_xmlMessage);
                    return (messageHandler as IMessageHandler<ReceiveMessageText>).Handle(_receiveMessage as ReceiveMessageText);
                //break;
                case ReceiveMessageType.image:
                    _receiveMessage = XmlHelper.Deserialize<ReceiveMessageImage>(_xmlMessage);
                    return (messageHandler as IMessageHandler<ReceiveMessageImage>).Handle(_receiveMessage as ReceiveMessageImage);
                //break;
                case ReceiveMessageType.voice:
                    _receiveMessage = XmlHelper.Deserialize<ReceiveMessageVoice>(_xmlMessage);
                    return (messageHandler as IMessageHandler<ReceiveMessageVoice>).Handle(_receiveMessage as ReceiveMessageVoice);
                //break;
                case ReceiveMessageType.video:
                    break;
                case ReceiveMessageType.location:
                    break;
                case ReceiveMessageType.@event:
                    var eventMessage = XmlHelper.Deserialize<ReceiveMessageEventBase>(_xmlMessage);
                    var eventType = eventMessage.GetEventType();

                    //根据事件类型，把消息传给相应的事件处理器
                    #region 处理事件消息
                    switch (eventType)
                    {
                        case ReceiveEventType.click:
                            _receiveMessage = XmlHelper.Deserialize<ReceiveMessageMenuEvent>(_xmlMessage);
                            return (messageHandler as IMessageHandler<ReceiveMessageMenuEvent>).Handle(_receiveMessage as ReceiveMessageMenuEvent);
                        case ReceiveEventType.view:
                            _receiveMessage = XmlHelper.Deserialize<ReceiveMessageViewEvent>(_xmlMessage);
                            return (messageHandler as IMessageHandler<ReceiveMessageViewEvent>).Handle(_receiveMessage as ReceiveMessageViewEvent);
                        case ReceiveEventType.subscribe:
                        case ReceiveEventType.unsubscribe:
                            _receiveMessage = XmlHelper.Deserialize<ReceiveMessageEventBase>(_xmlMessage);
                            return (messageHandler as IMessageHandler<ReceiveMessageSubscribeEvent>).Handle(_receiveMessage as ReceiveMessageSubscribeEvent);
                        case ReceiveEventType.LOCATION:
                            _receiveMessage = XmlHelper.Deserialize<ReceiveMessageLocationEvent>(_xmlMessage);
                            return (messageHandler as IMessageHandler<ReceiveMessageLocationEvent>).Handle(_receiveMessage as ReceiveMessageLocationEvent);
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
                        case ReceiveEventType.MASSSENDJOBFINISH:
                            break;
                        default:
                            break;
                    }
                    #endregion

                    return (messageHandler as IMessageHandler<ReceiveMessageVoice>).Handle(_receiveMessage as ReceiveMessageVoice);
                    break;
                case ReceiveMessageType.link:
                    break;
                default:
                    break;
            }

            return null;
        }
    }
}