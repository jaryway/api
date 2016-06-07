using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Qy
{
    /// <summary>
    /// 请求包结构体为:
    /// <code>
    /// {
    ///   "name": "广州研发中心",
    ///   "parentid": "1",
    ///   "order": "1"
    ///}
    /// </code>
    /// </summary>
    public class CreateDepartmentRequest : IRequest
    {
        /// <summary>
        /// 
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 部门名称。长度限制为1~64个字符 
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 父亲部门id。根部门id为1 
        /// </summary>
        public int parentid { get; set; }
        /// <summary>
        /// 在父部门中的次序。从1开始，数字越大排序越靠后 
        /// </summary>
        public int order { get; set; }
    }

}