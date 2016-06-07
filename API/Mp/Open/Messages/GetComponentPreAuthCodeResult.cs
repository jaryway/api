using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API.Mp.Open
{
    /// <summary>
    /// 
    /// </summary>
    public class GetComponentPreAuthCodeResult : MpResult
    {
        /// <summary>
        /// 预授权码
        /// </summary>
        public string pre_auth_code { get; set; }
        /// <summary>
        /// 有效期，为20分钟
        /// </summary>
        public int expires_in { get; set; }
    }
}
