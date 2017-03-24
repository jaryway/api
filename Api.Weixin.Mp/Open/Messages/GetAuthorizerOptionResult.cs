using Api.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Api.Weixin.Mp.Open
{
    /// <summary>
    /// 
    /// </summary>
    public class GetAuthorizerOptionResult : JsonResult
    {
        /// <summary>
        /// 授权公众号appid
        /// </summary>
        public string authorizer_appid { get; set; }
        /// <summary>
        /// 选项名称
        /// </summary>
        public string option_name { get; set; }
        /// <summary>
        /// 选项值
        /// </summary>
        public string option_value { get; set; }
    }
}
