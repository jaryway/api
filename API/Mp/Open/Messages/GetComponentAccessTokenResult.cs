using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API.Mp.Open
{
    /// <summary>
    /// 
    /// </summary>
    public class GetComponentAccessTokenResult : MpResult
    {
        /// <summary>
        /// 获取到的凭证
        /// </summary>
        public string component_access_token { get; set; }
        /// <summary>
        /// 凭证有效时间，单位：秒 
        /// </summary>
        public int expires_in { get; set; }
    }
}
