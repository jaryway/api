using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Api.Lanxin.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class Text
    {
        /// <summary>
        /// 
        /// </summary>
        public string content { get; set; }
    }

    /// <summary>
    /// 附件消息-附件信息
    /// </summary>
    public class Attachment
    {
        /// <summary>
        /// 
        /// </summary>
        public string media_id { get; set; }
    }
    /// <summary>
    /// 链接消息
    /// </summary>
    public class Link
    {
        public string url { get; set; }
    }
    /// <summary>
    /// 邮件消息
    /// </summary>
    public class Mail
    {
        /// <summary>
        /// 
        /// </summary>
        public string url { get; set; }
        /// <summary>
        /// 邮件标题
        /// </summary>
        public string title { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public class File
    {
        /// <summary>
        /// 
        /// </summary>
        public string media_id { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class Image
    {
        /// <summary>
        /// 
        /// </summary>
        public string media_id { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public class Voice
    {
        /// <summary>
        /// 
        /// </summary>
        public string media_id { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public class Video
    {
        /// <summary>
        /// 
        /// </summary>
        public string media_id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string thumb_media_id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string description { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class Music
    {
        /// <summary>
        /// 
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string description { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string musicurl { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string hqmusicurl { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string thumb_media_id { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public class wxcard
    {

        /// <summary>
        /// 
        /// </summary>
        public string card_id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string card_ext { get; set; }

    }

    /// <summary>
    /// 
    /// </summary>
    public class Article
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
        /// <summary>
        /// 图文消息链接类型，默认值为0：0 URL；1 语音； 2 视频； 3 文档 ； 4 未知
        /// </summary>
        public int type { get; set; }
        /// <summary>
        /// int类型：0 默认值，可以不传；1. 访问link的时候增加name和telephone要求以_ckey为可以传递。例如：http://host/path/uri?_ckey=base64(name=name&telephone=telephon)
        /// </summary>
        public int flag { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class News
    {
        /// <summary>
        /// 
        /// </summary>
        public IList<Article> articles { get; set; }
    }

    /// <summary>
    /// 用于发送图文文章消息
    /// </summary>
    public class MpNews
    {
        /// <summary>
        /// 
        /// </summary>
        public MpNews()
        { }

        /// <summary>
        /// 图文消息，一个图文消息支持1到10个图文 
        /// </summary>
        public IList<MpArticle> articles { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string media_id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="article"></param>
        public void Add(MpArticle article)
        {
            if (articles == null)
                articles = new List<MpArticle>();
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
    /// 图文文章
    /// </summary>
    public class MpArticle
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
    /// <summary>
    /// link消息 钉钉特有
    /// </summary>
    public class LinkMessage
    {
        /// <summary>
        /// 消息点击链接地址
        /// </summary>
        public string messageUrl { get; set; }
        /// <summary>
        /// 图片媒体文件id，可以调用上传媒体文件接口获取
        /// </summary>
        public string picUrl { get; set; }
        /// <summary>
        /// 消息标题
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// 消息描述
        /// </summary>
        public string text { get; set; }
    }
    /// <summary>
    /// OA消息 钉钉特有
    /// </summary>
    public class OAMessage
    {
        /// <summary>
        /// 消息点击链接地址
        /// </summary>
        public string message_url { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Head head { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Body body { get; set; }

        #region SubClass
        /// <summary>
        /// 消息头部内容
        /// </summary>
        public class Head
        {
            /// <summary>
            /// 消息头部的背景颜色。长度限制为8个英文字符，其中前2为表示透明度，后6位表示颜色值。不要添加0x 
            /// </summary>
            public string bgcolor { get; set; }
            /// <summary>
            /// 消息的头部标题
            /// </summary>
            public string text { get; set; }
        }

        /// <summary>
        /// 
        /// </summary>
        public class Body
        {
            /// <summary>
            /// 消息体的标题 
            /// </summary>
            public string title { get; set; }
            /// <summary>
            /// 消息体的表单，最多显示6个，超过会被隐藏
            /// </summary>
            public FormItem[] form { get; set; }
            /// <summary>
            /// 单行富文本信息
            /// </summary>
            public Rich rich { get; set; }
            /// <summary>
            /// 消息的头部标题
            /// </summary>
            public string content { get; set; }
            /// <summary>
            /// 消息体中的图片media_id
            /// </summary>
            public string image { get; set; }
            /// <summary>
            /// 自定义的附件数目。此数字仅供显示，钉钉不作验证
            /// </summary>
            public string file_count { get; set; }
            /// <summary>
            /// 自定义的作者名字
            /// </summary>
            public string author { get; set; }
        }

        /// <summary>
        /// 
        /// </summary>
        public class Rich
        {
            /// <summary>
            /// 单行富文本信息的数目
            /// </summary>
            public string num { get; set; }
            /// <summary>
            /// 单行富文本信息的单位
            /// </summary>
            public string unit { get; set; }
        }
        /// <summary>
        /// 
        /// </summary>
        public class FormItem
        {
            /// <summary>
            /// 消息体的关键字 
            /// </summary>
            public string key { get; set; }
            /// <summary>
            /// 消息体的关键字对应的值
            /// </summary>
            public string value { get; set; }
        }
        #endregion
    }

    /// <summary>
    /// 
    /// </summary>
    public enum MsgType
    {
        /// <summary>
        /// 文本
        /// </summary>
        text,
        /// <summary>
        /// 图片
        /// </summary>
        image,
        /// <summary>
        /// 文件
        /// </summary>
        file,
        /// <summary>
        /// 录音
        /// </summary>
        voice,
        /// <summary>
        /// 音乐
        /// </summary>
        music,
        /// <summary>
        /// 卡
        /// </summary>
        wxcard,
        /// <summary>
        /// 文章
        /// </summary>
        article,
        /// <summary>
        /// 图文
        /// </summary>
        mparticle,
    }
}
