using API.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace API
{
    /// <summary>
    /// 响应消息(被动消息)，用于回复被动消息
    /// </summary>
    [XmlRoot("xml")]
    public class ResponseMessage : IResponseMessage
    {
        #region private fields

        private DateTime dateInit = new DateTime(1970, 1, 1, 0, 0, 0);
        private int articleCount;
        private string _content;
        private string _msgType = "text";
        private ResponseMessageImage _image;
        private ResponseMessageVoice _voice;
        private ResponseMessageVideo _video;
        private ResponseMessageNews _news;

        #endregion

        public string ToUserName { get; set; }
        public string FromUserName { get; set; }
        public int CreateTime { get; set; }
        public string MsgType
        {
            get { return _msgType; }
            set { _msgType = value; }
        }
        public string Content
        {
            get { return _content; }
            set
            {
                _content = value;
                _msgType = string.Format("{0}", ResponseMessageType.text);
            }
        }
        public int ArticleCount
        {
            get { return articleCount; }
            set { articleCount = value; }
        }

        #region 扩展属性
        /// <summary>
        /// 图片消息
        /// </summary>
        [XmlElement("Image")]
        public ResponseMessageImage image
        {
            get { return _image; }
            set
            {
                _image = value;
                _msgType = string.Format("{0}", ResponseMessageType.image);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        [XmlElement("Voice")]
        public ResponseMessageVoice voice
        {
            get { return _voice; }
            set
            {
                _voice = value;
                _msgType = string.Format("{0}", ResponseMessageType.voice);
            }
        }
        /// <summary>
        /// 视频消息
        /// </summary>
        [XmlElement("Video")]
        public ResponseMessageVideo video
        {
            get { return _video; }
            set
            {
                _video = value;
                _msgType = string.Format("{0}", ResponseMessageType.video);
            }
        }

        [XmlElement("Articles")]
        public ResponseMessageNews news
        {
            get { return _news; }
            set
            {
                _news = value;
                _msgType = string.Format("{0}", ResponseMessageType.news);
                if (value.item != null)
                    articleCount = value.item.Count();
            }
        }

        #endregion

        #region Helper Methods
        /// <summary>
        /// 转成xml String
        /// </summary>
        /// <returns></returns>
        public string AsXmlString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("<xml>");
            builder.AppendFormat("<ToUserName><![CDATA[{0}]]></ToUserName>", ToUserName);
            builder.AppendFormat("<FromUserName><![CDATA[{0}]]></FromUserName>", FromUserName);
            builder.AppendFormat("<CreateTime>{0}</CreateTime>", CreateTime);
            builder.AppendFormat("<MsgType><![CDATA[{0}]]></MsgType>", MsgType);

            switch (MsgType)
            {
                case "text":
                default:
                    builder.AppendFormat("<Content><![CDATA[{0}]]></Content>", Content);
                    break;
                case "image":
                    builder.AppendFormat("<Image><MediaId><![CDATA[{0}]]></MediaId></Image>", image.MediaId);
                    break;
                case "voice":
                    builder.AppendFormat("<Voice><MediaId><![CDATA[{0}]]></MediaId></Voice>", voice.MediaId);
                    break;
                case "video":
                    builder.Append("<Video>");
                    builder.AppendFormat("<MediaId><![CDATA[{0}]]></MediaId>", video.MediaId);
                    builder.AppendFormat("<Title><![CDATA[{0}]]></Title>", video.Title);
                    builder.AppendFormat("<Description><![CDATA[{0}]]></Description>", video.Description);
                    builder.Append("</Video>");
                    break;
                case "news":
                    builder.AppendFormat("<ArticleCount>{0}</ArticleCount>", articleCount);
                    builder.Append("<Articles>");
                    foreach (var item in news.item)
                    {
                        builder.Append("<item>");
                        builder.AppendFormat("<Title><![CDATA[{0}]]></Title>", item.Title);
                        builder.AppendFormat("<Description><![CDATA[{0}]]></Description>", item.Description);
                        builder.AppendFormat("<PicUrl><![CDATA[{0}]]></PicUrl>", item.PicUrl);
                        builder.AppendFormat("<Url><![CDATA[{0}]]></Url>", item.Url);
                        builder.Append("</item>");
                    }
                    builder.Append("</Articles>");

                    break;
            }

            builder.Append("</xml>");
            return builder.ToString();
            //XmlSerializerUtility.Serialize<WeixinReplyMessageRequest>(this, true);
        }

        /// <summary>
        /// 加密消息
        /// </summary>
        /// <param name="wxcpt"></param>
        /// <param name="token"></param>
        /// <param name="encryptMsg"></param>
        /// <returns></returns>
        public int EncryptMessage(WXBizMsgCrypt wxcpt, string token, out string encryptMsg)
        {
            encryptMsg = string.Empty;
            var serializeMessage = this.AsXmlString();
            string timeSpan = DateTime.Now.Subtract(dateInit).TotalSeconds.ToString();
            string replyMsg = serializeMessage;
            string msgSignature = string.Empty;
            string nonce = DateTime.Now.Ticks.ToString();
            int encryptResult = wxcpt.EncryptMsg(replyMsg, timeSpan, nonce, ref encryptMsg);
            if (encryptResult != 0)
                return encryptResult;
            int genSinatureResult = WXBizMsgCrypt.GenerateSinature(token, timeSpan, nonce, encryptMsg, ref msgSignature);
            return genSinatureResult;
        }

        /// <summary>
        /// 设置创建时间
        /// </summary>
        /// <param name="dateCreated"></param>
        public void SetCreateTime(DateTime dateCreated)
        {
            CreateTime = (int)dateCreated.Subtract(dateInit).TotalSeconds;
        }

        ///// <summary>
        ///// 设置消息类型
        ///// </summary>
        ///// <param name="messageType"></param>
        //public void SetMessageType(WeixinReplyMessageType messageType)
        //{
        //    MsgType = string.Format("{0}", messageType);
        //}


        /// <summary>
        /// 设置text消息内容，同时将msgtype设为text
        /// </summary>
        /// <param name="content"></param>
        public void SetText(string content)
        {
            _content = content;
        }

        /// <summary>
        /// 设置image消息内容，同时将msgtype设为image
        /// </summary>
        /// <param name="image"></param>
        public void SetImage(ResponseMessageImage image)
        {
            if (_image == null)
                _image = new ResponseMessageImage();
            _image = image;
        }

        /// <summary>
        /// 设置voice消息内容，同时将msgtype设为voice
        /// </summary>
        /// <param name="voice"></param>
        public void SetVoice(ResponseMessageVoice voice)
        {
            if (_voice == null)
                _voice = new ResponseMessageVoice();
            _voice = voice;
        }
        /// <summary>
        /// 设置video消息内容，同时将msgtype设为video
        /// </summary>
        /// <param name="video"></param>
        public void SetVideo(ResponseMessageVideo video)
        {
            if (_video == null)
                _video = new ResponseMessageVideo();
            _video = video;
        }

        /// <summary>
        /// 设置news消息内容，同时将msgtype设为news
        /// </summary>
        /// <param name="articles"></param>
        public void SetNews(params ResponseArticle[] articles)
        {
            if (articles.Length > 0 && this._news == null)
                this.news = new ResponseMessageNews();

            foreach (var item in articles)
                this._news.Add(item);
        }

        #endregion
    }

    #region SubReplyModel
    /// <summary>
    /// 用于发送图片消息
    /// </summary>
    [XmlRoot("Voice")]
    public class ResponseMessageImage
    {
        /// <summary>
        /// 媒体资源文件ID 
        /// </summary>
        public string MediaId { get; set; }
    }
    /// <summary>
    /// 用于发送语音消息
    /// </summary>
    [XmlRoot("Voice")]
    public class ResponseMessageVoice
    {
        /// <summary>
        /// 媒体资源文件ID 
        /// </summary>
        public string MediaId { get; set; }
    }
    /// <summary>
    /// 用于发送视频消息
    /// </summary>
    [XmlRoot("Video")]
    public class ResponseMessageVideo
    {
        /// <summary>
        /// 媒体资源文件ID 
        /// </summary>
        public string MediaId { get; set; }
        /// <summary>
        /// 视频消息的标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 视频消息的描述
        /// </summary>
        public string Description { get; set; }
    }

    /// <summary>
    /// 用于发送新闻文章消息
    /// </summary>
    [XmlRoot("Articles")]
    public class ResponseMessageNews
    {
        public ResponseMessageNews()
        { }

        [XmlElement("item")]
        public List<ResponseArticle> item { get; set; }

        public void Add(ResponseArticle article)
        {
            if (item == null)
                item = new List<ResponseArticle>();
            item.Add(article);
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public class ResponseArticle
    {
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 点击后跳转的链接
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// 图文消息的图片链接，支持JPG、PNG格式，较好的效果为大图640*320，小图80*80。如不填，在客户端不显示图片 
        /// </summary>
        public string PicUrl { get; set; }
    }
    #endregion
}
