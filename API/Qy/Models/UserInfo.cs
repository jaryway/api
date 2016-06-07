using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API.Qy
{
    /// <summary>
    /// 成员信息
    /// </summary>
    public class UserInfo : UserSimple
    {
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
