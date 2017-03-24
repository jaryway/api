using Api.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Api.Weixin.Qy
{
    /// <summary>
    /// 
    /// </summary>
    public class GetChatResult : JsonResult
    {
        /// <summary>
        /// 
        /// </summary>
        public ChatInfo chat_info { get; set; }

    }
}
