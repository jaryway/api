using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Api.Core.Models
{
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
    
}
