using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Qy
{
    /// <summary>
    /// 
    /// </summary>
    public class GetDepartmentResult : APIJsonResult
    {
        public IEnumerable<WeixinDepartment> department { get; set; }
    }
}