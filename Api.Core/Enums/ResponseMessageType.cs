using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Api.Core.Enums
{
    /// <summary>
    /// 响应消息类型,0=text,1=image,2=voice,3=video,4=news
    /// </summary>
    public enum ResponseMessageType
    {
        /// <summary>
        /// 文本消息
        /// </summary>
        text = 0,
        /// <summary>
        /// 图片消息
        /// </summary>
        image,
        /// <summary>
        /// 语音消息
        /// </summary>
        voice,
        /// <summary>
        /// 视频消息
        /// </summary>
        video,
        /// <summary>
        /// 图文消息
        /// </summary>
        news,
    }
}
