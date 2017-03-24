using Api.Core;
using Api.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Api.Weixin.Mp
{
    /// <summary>
    /// 上传图文消息素材
    /// </summary>
    public class UploadMediaNewsRequest : IRequest
    {
        /// <summary>
        /// 图文消息，一个图文消息支持1到10条图文 
        /// </summary>
        public IList<MpArticle> articles { get; set; }
    }
}
