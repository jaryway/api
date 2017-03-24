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
    public class GetParentStructResult : JsonResult
    {
        /// <summary>
        /// 分支机构列表
        /// </summary>
        public IList<OrgStructInfo> openOrgStructList { get; set; }
        /// <summary>
        /// 成员列表
        /// </summary>
        public IList<OrgMemberInfo> openOrgMemberList { get; set; }
    }

    /// <summary>
    /// 分支机构
    /// </summary>
    public class OrgStructInfo
    {
        /// <summary>
        /// 分支ID
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 分支名称
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 分支所在位置
        /// </summary>
        public string path { get; set; }
        /// <summary>
        /// 分支父级机构，为0时，表示当前节点为根节点
        /// </summary>
        public int parentId { get; set; }

    }

    /// <summary>
    /// 成员信息属性
    /// </summary>
    public class OrgMemberInfo
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
        /// 成员所在组织名称
        /// </summary>
        public string orgName { get; set; }
        /// <summary>
        /// 成员所在组织id
        /// </summary>
        public int orgId { get; set; }
        /// <summary>
        /// 成员所在公司
        /// </summary>
        public string company { get; set; }
    }
}
