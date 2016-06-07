using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API
{
    /// <summary>
    /// 
    /// </summary>
    public enum MediaType
    {
        /// <summary>
        /// 图片
        /// </summary>
        //[Display(Name = "image")]
        image = 0,
        /// <summary>
        /// 语音
        /// </summary>
        //[Display(Name = "voice")]
        voice = 1,
        /// <summary>
        /// 视频
        /// </summary>
        //[Display(Name = "video")]
        video = 2,
        /// <summary>
        /// 普通文件
        /// </summary>
        //[Display(Name = "file")]
        file = 3
    }
}