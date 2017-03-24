using Api.Core;
using System.Collections.Generic;

namespace Api.Weixin.Qy
{
    /// <summary>
    /// 
    /// </summary>
    public class GetUserListResult : JsonResult
    {
        /// <summary>
        /// 用户列表
        /// </summary>
        public IEnumerable<UserInfo> userlist { get; set; }

    }
}