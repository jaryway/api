using Api.Core.Enums;
using Api.Core.XmlModels;
using System;

namespace Api.Weixin.Demo.MessageProcessors.Hanlders
{
    /// <summary>
    /// 具体的消息处理器
    /// </summary>
    public class MpMessageHandler : IMessageHandler<ReceiveMessageText>,
        IMessageHandler<ReceiveMessageVideo>,
        IMessageHandler<ReceiveMessageImage>,
        IMessageHandler<ReceiveMessageSubscribeEvent>,
        IMessageHandler<ReceiveMessageMenuEvent>,
        IMessageHandler<ReceiveMessageViewEvent>,
        IMessageHandler<ReceiveMessageLocationEvent>
    {
        /// <summary>
        /// 在这里处理消息并返回要返回的信息
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public IResponseMessage Handle(ReceiveMessageText message)
        {
            ResponseMessage r = new ResponseMessage();
            r.SetText("消息被处理了");
            r.SetCreateTime(DateTime.Now);
            r.ToUserName = message.FromUserName;
            r.FromUserName = message.ToUserName;

            #region switch
            switch (message.Content)
            {
                case "11":

                    break;
                case "12":

                    r.SetImage(new ResponseMessageImage
                    {
                        MediaId = "1mzGcGxSGcChgUalQE6ZirdUcMXJbPrWdZDTPRiOGHU95MsSoTDvv6yJ85gNR-p1B"
                    });

                    break;
                case "13":

                    r.SetVoice(new ResponseMessageVoice
                    {
                        MediaId = "1mzGcGxSGcChgUalQE6ZirdUcMXJbPrWdZDTPRiOGHU95MsSoTDvv6yJ85gNR-p1B"
                    });

                    break;
                case "-help":
                default:

                    r.SetText("[11] 重新生成菜单。\r\n[12] Image。\r\n[13] Vioce。\r\n[-help] 查看帮助。");

                    break;
            }
            #endregion

            return r;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public IResponseMessage Handle(ReceiveMessageVideo message)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public IResponseMessage Handle(ReceiveMessageImage message)
        {
            ResponseMessage r = new ResponseMessage();
            r.SetText("ReceiveMessageImage");
            r.SetCreateTime(DateTime.Now);
            r.ToUserName = message.FromUserName;
            r.FromUserName = message.ToUserName;

            return r;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public IResponseMessage Handle(ReceiveMessageSubscribeEvent message)
        {
            ResponseMessage resp_message = new ResponseMessage();
            resp_message.SetText(string.Format("用户【{0}】{2}", message.FromUserName, message.GetEventType() == ReceiveEventType.subscribe ? "成功的关注了我们" : "遗憾的和我们擦肩而过"));
            resp_message.SetCreateTime(DateTime.Now);
            resp_message.ToUserName = message.FromUserName;
            resp_message.FromUserName = message.ToUserName;
            return resp_message;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public IResponseMessage Handle(ReceiveMessageViewEvent message)
        {
            ResponseMessage resp_message = new ResponseMessage();
            resp_message.SetText(string.Format("用户【{0}】EventKey为{1}", message.FromUserName, message.EventKey));
            resp_message.SetCreateTime(DateTime.Now);
            resp_message.ToUserName = message.FromUserName;
            resp_message.FromUserName = message.ToUserName;
            return resp_message;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public IResponseMessage Handle(ReceiveMessageLocationEvent message)
        {
            ResponseMessage resp_message = new ResponseMessage();
            resp_message.SetText(string.Format("用户【{0}】你的位置坐标为,纬度{1}，经度{2}，精度{3}。",
                message.FromUserName, message.Latitude, message.Longitude, message.Precision));
            resp_message.SetCreateTime(DateTime.Now);
            resp_message.ToUserName = message.FromUserName;
            resp_message.FromUserName = message.ToUserName;
            return resp_message;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public IResponseMessage Handle(ReceiveMessageMenuEvent message)
        {
            ResponseMessage resp_message = new ResponseMessage();

            //根据key来处理相应的信息
            switch (message.EventKey)
            {
                default:
                case "last_news":
                    resp_message.SetText("目前没有新闻");
                    break;
            }
            resp_message.SetCreateTime(DateTime.Now);
            resp_message.ToUserName = message.FromUserName;
            resp_message.FromUserName = message.ToUserName;
            return resp_message;
        }
    }
}