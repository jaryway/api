using Api.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Api.Weixin.Mp
{
    /// <summary>
    /// 查询用户所在分组结果
    /// </summary>
    public class GetGroupIdByOpenIdResult : JsonResult
    {
        /// <summary>
        /// 用户所属的groupid 
        /// </summary>
        public int groupid { get; set; }
    }
}
