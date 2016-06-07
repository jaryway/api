using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace API.Qy.ThirdAuth
{
    /// <summary>
    /// 授权信息，用于授权
    /// </summary>
    [Serializable]
    public class AuthInfo
    {
        /// <summary>
        /// 授权的应用信息
        /// </summary>
        public List<AuthAgent> agent { get; set; }
        /// <summary>
        /// 授权的通讯录部门
        /// </summary>
        public List<AuthDepartment> department { get; set; }
    }
}
