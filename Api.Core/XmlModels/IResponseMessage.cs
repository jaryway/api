using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Api.Core.Helpers;

namespace Api.Core.XmlModels
{
    /// <summary>
    /// 响应消息接口标识
    /// </summary>
    public interface IResponseMessage
    {
        /// <summary>
        /// 接收人
        /// </summary>
        string ToUserName { get; set; }
        /// <summary>
        /// 发起人
        /// </summary>
        string FromUserName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        int CreateTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        string Content { get; set; }
        /// <summary>
        /// 转成xml对象
        /// </summary>
        /// <returns></returns>
        string AsXmlString();
        /// <summary>
        /// 加密消息
        /// </summary>
        /// <param name="wxcpt"></param>
        /// <param name="token"></param>
        /// <param name="encryptMsg"></param>
        /// <returns></returns>
        int EncryptMessage(WXBizMsgCrypt wxcpt, string token, out string encryptMsg);
    }
}
