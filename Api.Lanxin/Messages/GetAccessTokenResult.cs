using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Lanxin.Messages
{
    /// <summary>
    /// 获取
    /// </summary>
    public class GetAccessTokenResult : JsonResult
    {
        /// <summary>
        /// 获取到的凭证
        /// </summary>
        public string access_token { get; set; }
        /// <summary>
        /// 凭证有效时间，单位：秒
        /// </summary>
        public int expires_in { get; set; }
    }
}
