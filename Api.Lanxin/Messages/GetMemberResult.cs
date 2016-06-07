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
    public class GetMemberResult : JsonResult
    {
        /// <summary>
        /// 
        /// </summary>
        public IList<MemberInfo> openOrgMemberList { get; set; }
    }

    /// <summary>
    /// 成员信息属性
    /// </summary>
    public class MemberInfo
    {
        /// <summary>
        /// 成员id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 成员名称
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// Email
        /// </summary>
        public string email { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        public string mobile { get; set; }
        /// <summary>
        /// 成员在组织中的位置
        /// </summary>
        public string path { get; set; }
        /// <summary>
        /// 成员所在部门ID
        /// </summary>
        public int parentId { get; set; }
        /// <summary>
        /// 成员所在组织名称，一般和company一样。如果是集团公司，orgName为集团名称
        /// </summary>
        public string orgName { get; set; }
        /// <summary>
        /// 成员所在公司名称，对应蓝信中的“单位”，一般和orgName一样。如果为集团公司，company一般为集团子公司名称
        /// </summary>
        public string company { get; set; }
        /// <summary>
        /// 所属单位ID
        /// </summary>
        public string companyId { get; set; }
        /// <summary>
        /// 业务属性列表
        /// </summary>
        public string busiTags { get; set; }
        /// <summary>
        /// 序列号，如警号 
        /// </summary>
        public string serialNumber { get; set; }
        /// <summary>
        /// 职务属性列表
        /// </summary>
        public string posiTags { get; set; }
        /// <summary>
        /// 备注，说明
        /// </summary>
        public string note { get; set; }
        /// <summary>
        /// 岗位类别
        /// </summary>
        public string secondPosition { get; set; }
        /// <summary>
        /// 联系方式扩展
        /// </summary>
        public dynamic contactExs { get; set; }
    }


}
