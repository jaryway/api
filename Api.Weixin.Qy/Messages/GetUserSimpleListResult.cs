using Api.Core;
using System.Collections.Generic;

namespace Api.Weixin.Qy
{
    /// <summary>
    /// 
    /// </summary>
    public class GetUserSimpleListResult : JsonResult
    {

        /// <summary>
        /// 用户列表
        /// </summary>
        public IEnumerable<UserSimple> userlist { get; set; }


    }
}
