using Api.Core;
using System.Collections.Generic;

namespace Api.Weixin.Qy
{
    /// <summary>
    /// 
    /// </summary>
    public class GetDepartmentResult : JsonResult
    {
        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<Department> department { get; set; }
    }
}