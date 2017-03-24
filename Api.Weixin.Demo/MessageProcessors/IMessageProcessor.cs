using Api.Core.XmlModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api.Weixin.Demo.MessageProcessors
{
    /// <summary>
    /// 
    /// </summary>
    public interface IMessageProcessor
    {
        /// <summary>
        /// 处理消息并返回处理结果
        /// </summary>
        /// <returns></returns>
        IResponseMessage Process();
    }
}