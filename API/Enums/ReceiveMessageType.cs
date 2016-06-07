using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace API
{
    /// <summary>
    /// 接收消息类型枚举
    /// </summary>
    public enum ReceiveMessageType
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
        /// 地理位置
        /// </summary>
        [Display(Name = "地理位置")]
        location = 4,
        /// <summary>
        /// 事件
        /// </summary>
        [Display(Name = "事件")]
        @event = 5,
        /// <summary>
        /// 链接
        /// </summary>
        [Display(Name = "链接")]
        link = 6,
    }
}