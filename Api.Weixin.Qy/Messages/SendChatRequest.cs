using Api.Core;
using Api.Core.Models;

namespace Api.Weixin.Qy
{
    /// <summary>
    /// 
    /// </summary>
    public class SendChatRequest : IRequest
    {
        /// <summary>
        /// 接收人
        /// </summary>
        public ChatReceiver receiver { get; set; }
        /// <summary>
        /// 发送人
        /// </summary>
        public string sender { get; set; }
        /// <summary>
        /// 消息类型
        /// </summary>
        public string msgtype { get; set; }

        private Text _text;
        /// <summary>
        /// text消息
        /// </summary>
        public Text text
        {
            get { return _text; }
            set
            {
                _text = value;
                msgtype = "text";
            }
        }

        private Image _image;
        /// <summary>
        /// 
        /// </summary>
        public Image image
        {
            get { return _image; }
            set
            {
                _image = value;
                msgtype = "image";
            }
        }

        private File _file;
        /// <summary>
        /// file消息
        /// </summary>
        public File file
        {
            get { return _file; }
            set
            {
                _file = value;
                msgtype = "file";
            }
        }

    }
}
