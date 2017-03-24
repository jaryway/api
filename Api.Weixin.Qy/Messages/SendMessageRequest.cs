
using Api.Core;
using Api.Core.Models;

namespace Api.Weixin.Qy
{

    /// <summary>
    /// 发送消息
    /// </summary>
    public class SendMessageRequest : IRequest
    {
        #region private fields
        private Text _text;// = new WeixinSendMessageText();
        private Image _image;// = new WeixinSendMessageImage();
        private Voice _voice;// = new WeixinSendMessageVoice();
        private Video _video;// = new WeixinSendMessageVideo();
        private File _file;// = new WeixinSendMessageFile();
        private News _news;// = new WeixinSendMessageNews();
        private MpNews _mpnews;// = new WeixinSendMessageMpnews();

        private string _msgtype = "text";
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public string touser { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string toparty { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string totag { get; set; }
        /// <summary>
        /// 企业客服应用的appid
        /// </summary>
        public int agentid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int safe { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string msgtype
        {
            get { return _msgtype; }
            set { _msgtype = value; }
        }

        #region Extensions Propoties

        /// <summary>
        /// 文本消息
        /// </summary>
        public Text text
        {
            get { return _text; }
            set
            {
                _text = value;
                _msgtype = "text";
            }
        }

        /// <summary>
        /// 图片消息
        /// </summary>
        public Image image
        {
            get { return _image; }
            set
            {
                _image = value;
                _msgtype = "image";
            }
        }
        /// <summary>
        /// 语音消息
        /// </summary>
        public Voice voice
        {
            get { return _voice; }
            set
            {
                _voice = value;
                _msgtype = "voice";
            }
        }
        /// <summary>
        /// 视频消息
        /// </summary>
        public Video video
        {
            get { return _video; }
            set
            {
                _video = value;
                _msgtype = "video";
            }
        }
        /// <summary>
        /// 文件消息
        /// </summary>
        public File file
        {
            get { return _file; }
            set
            {
                _file = value;
                _msgtype = "file";
            }
        }
        /// <summary>
        /// 新闻消息
        /// </summary>
        public News news
        {
            get { return _news; }
            set
            {
                _news = value;
                _msgtype = "news";
            }
        }
        /// <summary>
        /// 图文消息
        /// </summary>
        public MpNews mpnews
        {
            get { return _mpnews; }
            set
            {
                _mpnews = value;
                _msgtype = "mpnews";
            }
        }


        private LinkMessage _link;
        /// <summary>
        /// link消息体格式
        /// </summary>
        public LinkMessage link
        {
            get { return _link; }
            set
            {
                _link = value;
                _msgtype = "link";
            }
        }

        private OAMessage _oa;
        /// <summary>
        /// OA消息
        /// </summary>
        public OAMessage oa
        {
            get { return _oa; }
            set
            {
                _oa = value;
                _msgtype = "oa";
            }
        }

        #endregion

        #region Helper Mehthods
        /// <summary>
        /// 设置发送用户
        /// </summary>
        /// <param name="userIds"></param>
        public void SetToUser(params string[] userIds)
        {
            touser = string.Join("|", userIds);
        }
        /// <summary>
        /// 设置发送部门
        /// </summary>
        /// <param name="partyIds"></param>
        public void SetToParty(params int[] partyIds)
        {
            toparty = string.Join("|", partyIds);
        }
        /// <summary>
        /// 设置发送标签
        /// </summary>
        /// <param name="tagIds"></param>
        public void SetToTag(params int[] tagIds)
        {
            totag = string.Join("|", tagIds);
        }

        /// <summary>
        /// 设置text消息内容，同时将msgtype设为text
        /// </summary>
        /// <param name="text"></param>
        public void SetText(Text text)
        {
            if (this.text == null)
                this.text = new Text();
            this.text = text;
        }

        /// <summary>
        /// 设置image消息内容，同时将msgtype设为image
        /// </summary>
        /// <param name="image"></param>
        public void SetImage(Image image)
        {
            if (this.image == null)
                this.image = new Image();
            this.image = image;
        }
        /// <summary>
        /// 设置file消息内容，同时将msgtype设为file
        /// </summary>
        /// <param name="file"></param>
        public void SetFile(File file)
        {
            if (this.file == null)
                this.file = new File();
            this.file = file;
        }

        /// <summary>
        /// 设置voice消息内容，同时将msgtype设为voice
        /// </summary>
        /// <param name="voice"></param>
        public void SetVoice(Voice voice)
        {
            if (this.voice == null)
                this.voice = new Voice();
            this.voice = voice;
        }
        /// <summary>
        /// 设置video消息内容，同时将msgtype设为video
        /// </summary>
        /// <param name="video"></param>
        public void SetVideo(Video video)
        {
            if (this.video == null)
                this.video = new Video();
            this.video = video;
        }

        /// <summary>
        /// 设置news消息内容，同时将msgtype设为news
        /// </summary>
        /// <param name="articles"></param>
        public void SetNews(params Article[] articles)
        {
            if (articles.Length > 0 && this.news == null)
                this.news = new News();

            foreach (var item in articles)
                this.news.articles.Add(item);
        }
        /// <summary>
        /// 设置mpnews消息内容，同时将msgtype设为mpnews
        /// </summary>
        /// <param name="articles"></param>
        public void SetMpNews(params MpArticle[] articles)
        {
            if (articles.Length > 0 && this.mpnews == null)
                this.mpnews = new MpNews();

            foreach (var item in articles)
                this.mpnews.Add(item);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mediaId"></param>
        public void SetMpNewsMediaId(string mediaId)
        {
            if (this._mpnews == null)
                this._mpnews = new MpNews();
            this._mpnews.SetMediaId(mediaId);
        }

        #endregion

    }

    #region SubSendModel
    /*
    /// <summary>
    /// 用于发送文本信息
    /// </summary>
    public class WeixinSendMessageText
    {
        /// <summary>
        /// 消息内容
        /// </summary>
        public string content { get; set; }
    }
    /// <summary>
    /// 用于发送图片消息
    /// </summary>
    public class WeixinSendMessageImage
    {
        /// <summary>
        /// 媒体资源文件ID 
        /// </summary>
        public string media_id { get; set; }
    }
    /// <summary>
    /// 用于发送语音消息
    /// </summary>
    public class WeixinSendMessageVoice
    {
        /// <summary>
        /// 媒体资源文件ID 
        /// </summary>
        public string media_id { get; set; }
    }
    /// <summary>
    /// 用于发送视频消息
    /// </summary>
    public class WeixinSendMessageVideo
    {
        /// <summary>
        /// 媒体资源文件ID 
        /// </summary>
        public string media_id { get; set; }
        /// <summary>
        /// 视频消息的标题
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// 视频消息的描述
        /// </summary>
        public string description { get; set; }
    }
    /// <summary>
    /// 用于发送文件消息
    /// </summary>
    public class WeixinSendMessageFile
    {
        /// <summary>
        /// 文件ID 
        /// </summary>
        public string media_id { get; set; }
    }
    /// <summary>
    /// 用于发送新闻文章消息
    /// </summary>
    public class WeixinSendMessageNews
    {
        /// <summary>
        /// 
        /// </summary>
        public WeixinSendMessageNews()
        { }
        /// <summary>
        /// 
        /// </summary>
        public IList<WeixinArticle> articles { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="article"></param>
        public void Add(WeixinArticle article)
        {
            if (articles == null)
                articles = new List<WeixinArticle>();
            articles.Add(article);
        }
    }
    /// <summary>
    /// 用于发送图文文章消息
    /// </summary>
    public class WeixinSendMessageMpnews
    {
        /// <summary>
        /// 
        /// </summary>
        public WeixinSendMessageMpnews()
        { }

        /// <summary>
        /// 图文消息，一个图文消息支持1到10个图文 
        /// </summary>
        public IList<WeixinMparticle> articles { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string media_id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="article"></param>
        public void Add(WeixinMparticle article)
        {
            if (articles == null)
                articles = new List<WeixinMparticle>();
            articles.Add(article);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mediaId"></param>
        public void SetMediaId(string mediaId)
        {
            this.media_id = mediaId;
        }
    }
    /// <summary>
    /// 新闻文章
    /// </summary>
    public class WeixinArticle
    {
        /// <summary>
        /// 标题
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string description { get; set; }
        /// <summary>
        /// 点击后跳转的链接
        /// </summary>
        public string url { get; set; }
        /// <summary>
        /// 图文消息的图片链接，支持JPG、PNG格式，较好的效果为大图640*320，小图80*80。如不填，在客户端不显示图片 
        /// </summary>
        public string picurl { get; set; }
    }
    /// <summary>
    /// 图文文章
    /// </summary>
    public class WeixinMparticle
    {
        /// <summary>
        /// 标题
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// 图文消息缩略图的media_id, 
        /// </summary>
        public string thumb_media_id { get; set; }
        /// <summary>
        /// 图文消息的作者
        /// </summary>
        public string author { get; set; }
        /// <summary>
        /// 图文消息点击“阅读原文”之后的页面链接
        /// </summary>
        public string content_source_url { get; set; }
        /// <summary>
        /// 图文消息的内容，支持html标签 
        /// </summary>
        public string content { get; set; }
        /// <summary>
        /// 图文消息的描述
        /// </summary>
        public string digest { get; set; }
        /// <summary>
        /// 是否显示封面，1为显示，0为不显示 
        /// </summary>
        public int show_cover_pic { get; set; }
    }
    */




    #endregion
}