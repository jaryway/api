using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Qy
{
    /// <summary>
    /// <code>
    /// POST 的结构体
    ///{
    ///  "userid": "zhangsan",
    ///   "name": "张三",
    ///   "department": [1, 2],
    ///  "position": "产品经理",
    ///   "mobile": "15913215421",
    ///   "gender": 1,
    ///   "tel": "62394",
    ///  "email": "zhangsan@gzdev.com",
    ///  "weixinid": "zhangsan4dev",
    ///  "extattr": {"attrs":[{"name":"爱好","value":"旅游"},{"name":"卡号","value":"1234567234"}]}
    ///}
    /// </code>
    /// </summary>
    public class UpdateUserRequest : IRequest
    {
        #region private fields
        //private IEnumerable<int> deptIds;
        #endregion

        #region Ctor
        /// <summary>
        /// 
        /// </summary>
        public UpdateUserRequest()
        { }
        #endregion

        #region 需持提交的属性
        /// <summary>
        /// 员工UserID (必须与企业号中的UserID一致)。对应管理端的帐号，企业内必须唯一。长度为1~64个字符 
        /// </summary>
        public string userid { get; set; }
        /// <summary>
        /// 成员名称。长度为1~64个字符
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 部门ID
        /// </summary>
        public List<int> department { get; set; }
        /// <summary>
        /// 职位信息。长度为0~64个字符
        /// </summary>
        public string position { get; set; }
        /// <summary>
        /// 手机号码。企业内必须唯一，mobile/weixinid/email三者不能同时为空 
        /// </summary>
        public string mobile { get; set; }
        /// <summary>
        /// 性别。gender=0表示男，=1表示女。默认gender=0 
        /// </summary>
        public int gender { get; set; }
        /// <summary>
        /// 办公电话。长度为0~64个字符 
        /// </summary>
        public string tel { get; set; }
        /// <summary>
        /// 邮箱。长度为0~64个字符。企业内必须唯一
        /// </summary>
        public string email { get; set; }
        /// <summary>
        /// 微信号。企业内必须唯一
        /// </summary>
        public string weixinid { get; set; }
        /// <summary>
        /// 额外属性
        /// </summary>
        public UserExtensionAttribute extattr { get; set; }

        #endregion

        #region HelperMethods

        /// <summary>
        /// 设置用户所在部门
        /// </summary>
        /// <param name="deptIds"></param>
        public void SetDept(params int[] deptIds)
        {
            if (department == null)
                department = new List<int>();
            foreach (var deptId in deptIds)
                department.Add(deptId);
        }
        /// <summary>
        /// 设置额外属性
        /// </summary>
        /// <param name="items"></param>
        public void SetExtAttr(params UserExtensionAttributeItem[] items)
        {
            if (extattr == null)
                extattr = new UserExtensionAttribute();
            foreach (var item in items)
                extattr.Add(item);
        }
        #endregion
    }
}
