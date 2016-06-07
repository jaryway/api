using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API
{
    /// <summary>
    /// 发送消息类型枚举,0=text,1=image,2=voice,3=video,4=file,5=news,6=mpnews
    /// </summary>
    public enum SendMessageType
    {
        /// <summary>
        /// 文本
        /// </summary>
        [Display(Name = "文本")]
        text = 0,
        /// <summary>
        /// 图片
        /// </summary>
        [Display(Name = "图片")]
        image = 1,
        /// <summary>
        /// 语音  
        /// </summary>
        [Display(Name = "语音")]
        voice = 2,
        /// <summary>
        /// 视频 
        /// </summary>
        [Display(Name = "视频")]
        video = 3,
        /// <summary>
        /// 文件
        /// </summary>
        [Display(Name = "文件")]
        file = 4,
        /// <summary>
        /// 新闻
        /// </summary>
        [Display(Name = "新闻")]
        news = 5,
        /// <summary>
        /// 图文
        /// </summary>
        [Display(Name = "图文")]
        mpnews = 6,
    }
}
