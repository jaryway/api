using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Qy
{
    public class AddTagUsersRequest : IRequest
    {
        /// <summary>
        /// 标签ID 
        /// </summary>
        public int tagid { get; set; }
        /// <summary>
        /// 企业员工ID列表 eg. [ "user1","user2"]
        /// </summary>
        public IEnumerable<string> userlist { get; set; }
    }
}