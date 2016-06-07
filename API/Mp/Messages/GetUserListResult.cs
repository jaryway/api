using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API.Mp
{
    /// <summary>
    /// 获取用户列表结果
    /// </summary>
    public class GetUserListResult : MpResult
    {
        /// <summary>
        /// 关注该公众账号的总用户数
        /// </summary>
        public int total { get; set; }
        /// <summary>
        /// 拉取的OPENID个数，最大值为10000 
        /// </summary>
        public int count { get; set; }
        /// <summary>
        /// 列表数据，OPENID的列表 
        /// </summary>
        public OpenIdList data { get; set; }
        /// <summary>
        /// 拉取列表的后一个用户的OPENID 
        /// </summary>
        public string next_openid { get; set; }

        /// <summary>
        /// OPENID的列表
        /// </summary>
        public class OpenIdList { IList<string> openid { get; set; } }
    }


}
