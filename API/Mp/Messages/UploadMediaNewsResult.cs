using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API.Mp
{
    /// <summary>
    /// 上传图文消息素材
    /// </summary>
    public class UploadMediaNewsResult : MpResult
    {
        /// <summary>
        /// 媒体文件类型，分别有图片（image）、语音（voice）、视频（video）和缩略图（thumb），次数为news，即图文消息 
        /// </summary>
        public string type { get; set; }
        /// <summary>
        /// 媒体文件/图文消息上传后获取的唯一标识 
        /// </summary>
        public string media_id { get; set; }
        /// <summary>
        /// 媒体文件上传时间
        /// </summary>
        public int created_at { get; set; }
    }
}
