using Api.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Api.Weixin.Mp
{
    /// <summary>
    /// 查询所有分组结果
    /// </summary>
    public class GetGroupListResult : JsonResult
    {
        /// <summary>
        /// 
        /// </summary>
        public IList<Group> groups { get; set; }
    }
}
