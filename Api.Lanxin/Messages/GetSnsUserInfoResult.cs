using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Lanxin.Messages
{
    /// <summary>
    /// 
    /// </summary>
    public class GetSnsUserInfoResult : JsonResult
    {
        /// <summary>
        /// 
        /// </summary>
        public IList<SnsUserInfo> openOrgMemberList { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public class SnsUserInfo
    {
        /// <summary>
        /// 成员id
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 成员名称
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 手机号或USERUUNIID
        /// </summary>
        public string mobile { get; set; }
        /// <summary>
        /// Email
        /// </summary>
        public string email { get; set; }
        /// <summary>
        /// 成员在组织中的位置
        /// </summary>
        public string path { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string serialNumber { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string position { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string note { get; set; }
        /// <summary>
        /// 成员所在部门ID
        /// </summary>
        public string parentId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string companyId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string secondPosition { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string userUniId { get; set; }
        /// <summary>
        /// 成员所在公司名称，对应蓝信中的“单位”，一般和orgName一样。如果为集团公司，company一般为集团子公司名称
        /// </summary>
        public string company { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public dynamic[] busiTags { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public dynamic[] posiTags { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public dynamic[] contactExs { get; set; }
        /// <summary>
        /// 成员所在组织名称，一般和company一样。如果是集团公司，orgName为集团名称
        /// </summary>
        public string orgName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string orgId { get; set; }
    }
}
