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
    public class GetKFListResult : JsonResult
    {
        /// <summary>
        /// 
        /// </summary>
        public KFInfo[] kf_list { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public class KFInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public string kf_id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string kf_account { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string kf_nick { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string kf_headimgurl { get; set; }

    }
}
