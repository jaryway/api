using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Api.Core.Models
{
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
}
