using Api.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Api.Weixin.Qy.ThirdAuth
{
    /// <summary>
    /// 
    /// </summary>
    public class SyncGetPageResult : JsonResult
    {
        /// <summary>
        /// 
        /// </summary>
        public int next_seq { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int next_offset { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int is_last { get; set; }
        /// <summary>
        /// 数据数组
        /// </summary>
        public IList<dynamic> data { get; set; }


    }
}
