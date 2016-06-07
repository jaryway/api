using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API.Qy.ThirdAuth
{
    /// <summary>
    /// 获取应用套件令牌，返回信息
    /// </summary>
    public class GetSuiteTokenResult : QyResult
    {
        /// <summary>
        /// 应用套件access_token
        /// </summary>
        public string suite_access_token { get; set; }
        /// <summary>
        /// 有效期
        /// </summary>
        public int expires_in { get; set; }
    }
}
