using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api.Core.Enums
{
    /// <summary>
    /// 接收消息类型枚举
    /// </summary>
    public enum ReceiveMessageType
    {
        /// <summary>
        /// 文本
        /// </summary>
        text = 0,
        /// <summary>
        /// 图片
        /// </summary>
        image = 1,
        /// <summary>
        /// 语音  
        /// </summary>
        voice = 2,
        /// <summary>
        /// 视频 
        /// </summary>
        video = 3,
        /// <summary>
        /// 地理位置
        /// </summary>
        location = 4,
        /// <summary>
        /// 事件
        /// </summary>
        @event = 5,
        /// <summary>
        /// 链接
        /// </summary>
        link = 6,
    }
}