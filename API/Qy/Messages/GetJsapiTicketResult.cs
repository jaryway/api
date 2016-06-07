using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API.Qy
{
    public class GetJsapiTicketResult : APIJsonResult
    {
        /// <summary>
        /// 
        /// </summary>
        public string ticket { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int expires_in { get; set; }
    }
}
