using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API.Qy
{
    /// <summary>
    /// 微信部门
    /// </summary>
    public class WeixinDepartment
    {
        /// <summary>
        /// 部门ID
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 部门名称
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 父级部门ID
        /// </summary>
        public int parentid { get; set; }
    }
}
