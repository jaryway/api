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
    public class GetCallbackIPResult : JsonResult
    {
        /// <summary>
        /// 微信服务器IP地址列表 
        /// </summary>
        public string[] ip_list { get; set; }
    }
}
