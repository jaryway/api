using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API.Qy.ThirdAuth
{
    /// <summary>
    /// 获取企业号access_token
    /// </summary>
    public class GetCorpTokenRequest : IRequest
    {
        /// <summary>
        /// 应用套件id 
        /// </summary>
        public string suite_id { get; set; }
        /// <summary>
        /// 授权方corpid 
        /// </summary>
        public string auth_corpid { get; set; }
        /// <summary>
        /// 永久授权码，通过get_permanent_code获取 
        /// </summary>
        public string permanent_code { get; set; }
    }
}
