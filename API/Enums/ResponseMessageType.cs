using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace API
{
    /// <summary>
    /// 响应消息类型,0=text,1=image,2=voice,3=video,4=news
    /// </summary>
    public enum ResponseMessageType
    {
        /// <summary>
        /// 文本消息
        /// </summary>
        [Display(Name = "文本")]
        text = 0,
        /// <summary>
        /// 图片消息
        /// </summary>
        [Display(Name = "图片")]
        image,
        /// <summary>
        /// 语音消息
        /// </summary>
        [Display(Name = "语音")]
        voice,
        /// <summary>
        /// 视频消息
        /// </summary>
        [Display(Name = "视频")]
        video,
        /// <summary>
        /// 图文消息
        /// </summary>
        [Display(Name = "图文")]
        news,
    }
}
