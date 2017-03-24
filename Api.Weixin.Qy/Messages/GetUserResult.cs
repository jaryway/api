using Api.Core;
using System.Collections.Generic;

namespace Api.Weixin.Qy
{
    /// <summary>
    /// 
    /// </summary>
    public class GetUserResult : JsonResult
    {
        /// <summary>
        /// 员工UserID。对应管理端的帐号，企业内必须唯一。长度为1~64个字符 
        /// </summary>
        public string userid { get; set; }
        /// <summary>
        /// 成员名称。长度为1~64个字符 
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 所在部门ID集合
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
        /// 头像url。注：如果要获取小图将url最后的"/0"改成"/64"即可
        /// </summary>
        public string avatar { get; set; }
        /// <summary>
        /// 关注状态: 1=已关注，2=已冻结，4=未关注 
        /// </summary>
        public int status { get; set; }
        /// <summary>
        /// 扩展属性
        /// </summary>
        public UserExtensionAttribute extattr { get; set; }

    }

}