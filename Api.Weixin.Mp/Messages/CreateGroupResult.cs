using Api.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Api.Weixin.Mp
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateGroupResult : JsonResult
    {
        /// <summary>
        /// 
        /// </summary>
        public Group group { get; set; }
    }


}
