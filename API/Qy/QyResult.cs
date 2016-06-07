using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API.Qy
{
    /// <summary>
    /// 
    /// </summary>
    public class QyResult : IJsonResult
    {
        /// <summary>
        /// 错误代码
        /// </summary>
        public int errcode { get; set; }
        /// <summary>
        /// 错误信息
        /// </summary>
        public string errmsg { get; set; }
    }
}
