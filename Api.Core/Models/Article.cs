using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Api.Core.Models
{
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
    }
}
