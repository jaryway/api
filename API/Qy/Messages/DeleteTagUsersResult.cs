using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Qy
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteTagUsersResult : APIJsonResult
    {
        /// <summary>
        /// 若部分userid非法，则返回 e.g. usr1|usr2|usr3
        /// </summary>
        public string invalidlist { get; set; }
    }
}