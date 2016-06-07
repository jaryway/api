using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Qy
{
    /// <summary>
    /// 获取标签成员结果类
    /// </summary>
    public class GetTagUserResult : APIJsonResult
    {
        /// <summary>
        /// 用户列表
        /// </summary>
        public IEnumerable<UserSimple> userlist { get; set; }
    }
}