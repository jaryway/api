using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Api.Core.Enums
{
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
