using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API.Qy.ThirdAuth
{
    /// <summary>
    /// 获取预授权码 返回信息
    /// </summary>
    public class GetPreAuthCodeResult : QyResult
    {
        private string _pre_auth_code;
        /// <summary>
        /// 预授权码
        /// </summary>
        public string pre_auth_code
        {
            get { return _pre_auth_code; }
            set { _pre_auth_code = value; }
        }
        /// <summary>
        /// 有效期
        /// </summary>
        public int expires_in { get; set; }
    }
}
