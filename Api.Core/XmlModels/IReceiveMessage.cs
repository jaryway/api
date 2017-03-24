using Api.Core.Enums;

namespace Api.Core.XmlModels
{
    /// <summary>
    /// 消息接收接口标识
    /// </summary>
    public interface IReceiveMessage
    {
        /// <summary>
        /// 接收者ID 
        /// </summary>
        string ToUserName { get; set; }
        /// <summary>
        /// 发送者ID 
        /// </summary>
        string FromUserName { get; set; }
        /// <summary>
        /// 消息创建时间（整型） 
        /// </summary>
        double CreateTime { get; set; }
        /// <summary>
        /// 消息类型
        /// </summary>
        ReceiveMessageType MsgType { get; set; }
        ///// <summary>
        ///// 消息id，64位整型 
        ///// </summary>
        //long MsgId { get; set; }
    }
}
