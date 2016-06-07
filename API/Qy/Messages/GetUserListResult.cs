using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Qy
{
    /// <summary>
    /// 
    /// </summary>
    public class GetUserListResult : APIJsonResult
    {
        /// <summary>
        /// 用户列表
        /// </summary>
        public IEnumerable<UserInfo> userlist { get; set; }

    }
}