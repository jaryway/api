using Api.Core.XmlModels;
using System;

namespace Api.Weixin.Demo.MessageProcessors.Hanlders
{
    public class QyMessageHandler : IMessageHandler<ReceiveMessageText>,
        IMessageHandler<ReceiveMessageVideo>
    {
        public QyMessageHandler()
        {

        }

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

        public IResponseMessage Handle(ReceiveMessageVideo message)
        {
            throw new NotImplementedException();
        }
    }
}
