using Api.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Api.Weixin.Mp
{
    /// <summary>
    /// 
    /// </summary>
    public class GetShortUrlResult : JsonResult
    {
        /// <summary>
        /// 换取到的短链接
        /// </summary>
        public string short_url { get; set; }
    }
}
