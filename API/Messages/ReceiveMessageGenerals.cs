using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace API
{
    /// <summary>
    /// 接收普通消息之图片消息
    /// </summary>
    [XmlRoot("xml")]
    public class ReceiveMessageText : ReceiveMessageGeneralBase
    {
        /// <summary>
        /// 消息内容
        /// </summary>
        public string Content { get; set; }
    }

    /// <summary>
    /// 接收普通消息之图片消息
    /// </summary>
    [XmlRoot("xml")]
    public class ReceiveMessageImage : ReceiveMessageGeneralBase
    {
        /// <summary>
        /// 图片链接，仅当MsgType为image类型时有效
        /// </summary>
        public string PicUrl { get; set; }
        /// <summary>
        /// 视频消息媒体id，可以调用多媒体文件下载接口拉取数据 
        /// </summary>
        public string MediaId { get; set; }
    }

    /// <summary>
    /// 接收普通消息之语音消息
    /// </summary>
    [XmlRoot("xml")]
    public class ReceiveMessageVoice : ReceiveMessageGeneralBase
    {
        /// <summary>
        /// 视频消息媒体id，可以调用多媒体文件下载接口拉取数据 
        /// </summary>
        public string MediaId { get; set; }
        /// <summary>
        /// 语音格式，如amr，speex等，仅MsgType当为voice时有效
        /// </summary>
        public string Format { get; set; }
    }

    /// <summary>
    /// 接收普通消息之视频消息
    /// </summary>
    [XmlRoot("xml")]
    public class ReceiveMessageVideo : ReceiveMessageGeneralBase
    {
        /// <summary>
        /// 视频消息媒体id，可以调用多媒体文件下载接口拉取数据 
        /// </summary>
        public string MediaId { get; set; }
        /// <summary>
        /// 仅当为video时有效，视频消息缩略图的媒体id，可以调用多媒体文件下载接口拉取数据
        /// </summary>
        public string ThumbMediaId { get; set; }
    }

    /// <summary>
    /// 接收普通消息之位置消息
    /// </summary>
    [XmlRoot("xml")]
    public class ReceiveMessageLocation : ReceiveMessageGeneralBase
    {
        /// <summary>
        /// 地理位置纬度，仅当为location时有效
        /// </summary>
        public double Location_X { get; set; }
        /// <summary>
        /// 地理位置经度，仅当MsgType为location时有效
        /// </summary>
        public double Location_Y { get; set; }
        /// <summary>
        /// 地图缩放大小，仅当MsgType为location时有效
        /// </summary>
        public double Scale { get; set; }
        /// <summary>
        /// 地理位置信息，仅当MsgType为location时有效
        /// </summary>
        public string Label { get; set; }
    }
}
