using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Api.Core.XmlModels
{
    /// <summary>
    /// 用于接收微信post过来的加密xml
    /// </summary>
    [XmlRoot("xml")]
    public class EncryptMessage
    {
        //private string agentId;

        /// <summary>
        /// 企业号CorpID 
        /// </summary>
        public string ToUserName { get; set; }
        /// <summary>
        /// 消息密文
        /// </summary>
        public string Encrypt { get; set; }
        /// <summary>
        /// 应用ID
        /// </summary>
        public string AgentID { get; set; }

    }
}
