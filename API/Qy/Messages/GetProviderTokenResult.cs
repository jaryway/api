using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Qy
{
    /// <summary>
    /// 获取应用提供商凭证
    /// </summary>
    public class GetProviderTokenResult : APIJsonResult
    {
        private int _expires_in;
        private string _provider_access_token;
        /// <summary>
        ///  accesstoken有效期 单位s
        /// </summary>
        public int expires_in 
        {
            get { return _expires_in; }
            set { _expires_in = value; }
        }
        /// <summary>
        /// 服务提供商的accesstoken，可用于用户授权登录信息查询接口
        /// </summary>
        public string provider_access_token 
        {
            get { return _provider_access_token; }
            set { _provider_access_token = value; }
        }
    }
}