using System;
using System.Collections.Generic;

namespace Api.Core
{
    /// <summary>
    /// 
    /// </summary>
    public class JsonResult : IJsonResult
    {
        /// <summary>
        /// 
        /// </summary>
        public int errcode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string errmsg { get; set; }
    }
}
