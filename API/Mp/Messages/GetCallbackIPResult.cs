using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API.Mp
{
    /// <summary>
    /// 
    /// </summary>
    public class GetCallbackIPResult : MpResult
    {
        /// <summary>
        /// 微信服务器IP地址列表 
        /// </summary>
        public string[] ip_list { get; set; }
    }
}
