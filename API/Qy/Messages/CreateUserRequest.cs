using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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
    public class CreateUserRequest : IRequest
    {
        #region private fields
        //private IEnumerable<int> deptIds;
        #endregion

        #region Ctor
        /// <summary>
        /// 
        /// </summary>
        public CreateUserRequest()
        {
            department = new List<int>();
            extattr = new UserExtensionAttribute();
        }
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

        /// <summary>
        /// 设置用户额外属性
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public void AddExtAttr(string name, string value)
        {
            if (extattr == null)
                extattr = new UserExtensionAttribute();
            extattr.Add(name, value);
        }
        /// <summary>
        /// 设置用户额外属性
        /// </summary>
        /// <param name="attrs"></param>
        public void AddExtAttr(NameValueCollection attrs)
        {
            if (extattr == null)
                extattr = new UserExtensionAttribute();
            foreach (string key in attrs.Keys)
                extattr.Add(key, attrs[key]);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="deptIds"></param>
        public void SetDept(int[] deptIds)
        {
            if (department == null)
                department = new List<int>();
            department.AddRange(deptIds);
        }

        #endregion
    }
}
