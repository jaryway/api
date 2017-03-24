using Api.Core.Enums;
using Api.Core.Helpers;
using Api.Core.XmlModels;
using Api.Weixin.Demo.MessageProcessors.Hanlders;

namespace Api.Weixin.Demo.MessageProcessors
{
    public class ReceiveMessageProcessor
    {
        private IReceiveMessage _receiveMessage;
        private string _xmlMessage;
        public ReceiveMessageProcessor(string xmlMessage)
        {
            _xmlMessage = xmlMessage;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual IResponseMessage Process()
        {
            var messageHandler = new QyMessageHandler();
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
