using Api.Core;
using System.Collections.Generic;

namespace Api.Weixin.Qy
{
    /// <summary>
    /// 获取标签成员结果类
    /// </summary>
    public class GetTagUserResult : JsonResult
    {
        /// <summary>
        /// 用户列表
        /// </summary>
        public IEnumerable<UserSimple> userlist { get; set; }
    }
}