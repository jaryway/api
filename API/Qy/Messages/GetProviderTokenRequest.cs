
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace API.Qy
{
    public class GetProviderTokenRequest : IRequest
    {
        private string _corpid;
        private string _provider_secret;

        /// <summary>
        /// 企业号（提供商）的corpid
        /// </summary>
        public string corpid
        {
            get { return _corpid; }
            set { _corpid = value; }
        }
        /// <summary>
        /// 提供商的secret，在提供商管理页面可见
        /// </summary>
        public string provider_secret
        {
            get { return _provider_secret; }
            set { _provider_secret = value; }
        }
    }
}