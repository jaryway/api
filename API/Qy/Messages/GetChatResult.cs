using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API.Qy
{
    public class GetChatResult : APIJsonResult
    {
        public ChatInfo chat_info { get; set; }
        
    }
}
