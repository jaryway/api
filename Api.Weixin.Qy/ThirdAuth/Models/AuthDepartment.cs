using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Api.Weixin.Qy.ThirdAuth
{
    /// <summary>
    /// 授权的通讯录部门，用于授权应用
    /// </summary>
    [Serializable]
    public class AuthDepartment
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
        /// <summary>
        /// 是否具有该部门的写权限
        /// </summary>
        public bool writable { get; set; }
    }
}
