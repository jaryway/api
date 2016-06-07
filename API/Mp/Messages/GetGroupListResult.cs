using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API.Mp
{
    /// <summary>
    /// 查询所有分组结果
    /// </summary>
    public class GetGroupListResult : MpResult
    {
        public IList<Group> groups { get; set; }
    }
}
