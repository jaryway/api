using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Api.Weixin.Qy
{
    /// <summary>
    /// 
    /// </summary>
    [XmlRoot("xml")]
    public class ChatReceiver
    {
        /// <summary>
        /// 接收人类型：single|group，分别表示：群聊|单聊 
        /// </summary>
        public string type { get; set; }
        /// <summary>
        /// 接收人的值，为userid|chatid，分别表示：成员id|会话id 
        /// </summary>
        public string id { get; set; }
    }
}
