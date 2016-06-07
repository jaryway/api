using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API.Qy
{
    public class GetUserSimpleListResult : APIJsonResult
    {

        /// <summary>
        /// 用户列表
        /// </summary>
        public IEnumerable<UserSimple> userlist { get; set; }


    }
}
