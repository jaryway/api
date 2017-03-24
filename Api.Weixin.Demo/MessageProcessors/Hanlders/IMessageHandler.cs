using Api.Core.XmlModels;

namespace Api.Weixin.Demo.MessageProcessors.Hanlders
{
    /// <summary>
    /// 消息具体的处理器
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IMessageHandler<T>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        IResponseMessage Handle(T message);
    }
}
