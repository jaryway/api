using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API.Mp
{
    /// <summary>
    /// 
    /// </summary>
    public class MpResult : IJsonResult
    {
        private int _errcode = 0;
        /// <summary>
        /// 错误代码
        /// </summary>
        public int errcode
        {
            get { return _errcode; }
            set { _errcode = value; }
        }
        /// <summary>
        /// 错误信息
        /// </summary>
        public string errmsg { get; set; }
    }
}
