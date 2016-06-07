using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace API.Core.Qy
{
    /// <summary>
    /// 接收图片消息
    /// </summary>
    [XmlRoot("xml")]
    public class ReceiveMessageText : ReceiveMessageBase
    {
        //// <summary>
        /// 消息内容
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 消息id，64位整型 
        /// </summary>
        public long MsgId { get; set; }
    }

    /// <summary>
    /// 接收图片消息
    /// </summary>
    [XmlRoot("xml")]
    public class ReceiveMessageImage : ReceiveMessageBase
    {
        /// <summary>
        /// 图片链接，仅当MsgType为image类型时有效
        /// </summary>
        public string PicUrl { get; set; }
        /// <summary>
        /// 视频消息媒体id，可以调用多媒体文件下载接口拉取数据 
        /// </summary>
        public string MediaId { get; set; }
        /// <summary>
        /// 消息id，64位整型 
        /// </summary>
        public long MsgId { get; set; }
    }

    /// <summary>
    /// 接收语音消息
    /// </summary>
    [XmlRoot("xml")]
    public class ReceiveMessageVoice : ReceiveMessageBase
    {
        /// <summary>
        /// 视频消息媒体id，可以调用多媒体文件下载接口拉取数据 
        /// </summary>
        public string MediaId { get; set; }
        /// <summary>
        /// 语音格式，如amr，speex等，仅MsgType当为voice时有效
        /// </summary>
        public string Format { get; set; }
        /// <summary>
        /// 消息id，64位整型 
        /// </summary>
        public long MsgId { get; set; }
    }

    /// <summary>
    /// 接收视频消息
    /// </summary>
    [XmlRoot("xml")]
    public class ReceiveMessageVideo : ReceiveMessageBase
    {
        /// <summary>
        /// 视频消息媒体id，可以调用多媒体文件下载接口拉取数据 
        /// </summary>
        public string MediaId { get; set; }
        /// <summary>
        /// 仅当为video时有效，视频消息缩略图的媒体id，可以调用多媒体文件下载接口拉取数据
        /// </summary>
        public string ThumbMediaId { get; set; }
        /// <summary>
        /// 消息id，64位整型 
        /// </summary>
        public long MsgId { get; set; }
    }

    /// <summary>
    /// 接收位置消息
    /// </summary>
    [XmlRoot("xml")]
    public class ReceiveMessageLocation : ReceiveMessageBase
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
        /// <summary>
        /// 消息id，64位整型 
        /// </summary>
        public long MsgId { get; set; }
    }

    /// <summary>
    /// 菜单事件推送
    /// </summary>
    [XmlRoot("xml")]
    public class ReceiveMessageMenuEvent : ReceiveMessageEventBase
    {
        /// <summary>
        /// 事件KEY值，与菜单接口中KEY值对应
        /// </summary>
        public string EventKey { get; set; }
    }

    /// <summary>
    /// 上报地理位置事件
    /// </summary>
    [XmlRoot("xml")]
    public class ReceiveMessageLoctionEvent : ReceiveMessageEventBase
    {
        /// <summary>
        /// 纬度,仅当Event为LOCATION有效
        /// </summary>
        public double Latitude { get; set; }
        /// <summary>
        /// 经度,仅当Event为LOCATION有效
        /// </summary>
        public double Longitude { get; set; }
        /// <summary>
        /// 地理位置精度,仅当Event为LOCATION有效
        /// </summary>
        public double Precision { get; set; }
    }

    /// <summary>
    /// 菜单事件推送
    /// </summary>
    [XmlRoot("xml")]
    public class ReceiveMessageScanEvent : ReceiveMessageEventBase
    {
        /// <summary>
        /// 事件KEY值，与菜单接口中KEY值对应
        /// </summary>
        public string EventKey { get; set; }

        private ScanCodeInfo _scanCodeInfo = new ScanCodeInfo();

        /// <summary>
        /// 扫描信息
        /// </summary>
        public ScanCodeInfo ScanCodeInfo
        {
            get { return _scanCodeInfo; }
            set { _scanCodeInfo = value; }
        }

    }

    /// <summary>
    /// 弹出微信相册发图器的事件推送
    /// </summary>
    [XmlRoot("xml")]
    public class ReceiveMessageSendImageEvent : ReceiveMessageEventBase
    {
        /// <summary>
        /// 事件KEY值，与菜单接口中KEY值对应
        /// </summary>
        public string EventKey { get; set; }

        private SendPicsInfo _sendPicsInfo = new SendPicsInfo();

        /// <summary>
        /// 发送的图片信息
        /// </summary>
        public SendPicsInfo SendPicsInfo
        {
            get { return _sendPicsInfo; }
            set { _sendPicsInfo = value; }
        }

    }

    /// <summary>
    /// 弹出地理位置选择器的事件推送
    /// </summary>
    [XmlRoot("xml")]
    public class ReceiveMessageSendLocationEvent : ReceiveMessageEventBase
    {
        /// <summary>
        /// 事件KEY值，与菜单接口中KEY值对应
        /// </summary>
        public string EventKey { get; set; }

        private SendLocationInfo _sendLocationInfo = new SendLocationInfo();

        /// <summary>
        /// 发送的图片信息
        /// </summary>
        public SendLocationInfo SendLocationInfo
        {
            get { return _sendLocationInfo; }
            set { _sendLocationInfo = value; }
        }
    }

    #region MyRegion
    /// <summary>
    /// 扫描信息
    /// </summary>
    public class ScanCodeInfo
    {
        /// <summary>
        /// 扫描类型，一般是qrcode 
        /// </summary>
        public ScanType ScanType { get; set; }
        /// <summary>
        /// 扫描结果，即二维码对应的字符串信息 
        /// </summary>
        public string ScanResult { get; set; }
    }

    /// <summary>
    /// 发送的图片信息
    /// </summary>
    public class SendPicsInfo
    {
        public SendPicsInfo()
        {
            //PicList = new List<PicList>();
        }
        private int _count = 0;
        private List<PicList> picList = new List<PicList>();
        public int Count
        {
            get { return _count; }
            set { _count = value; }
        }

        [XmlElement("item")]
        public List<PicList> PicList
        {
            get { return picList; }
            set
            {
                picList = value;
                _count = picList.Count();
            }
        }

    }
    /// <summary>
    /// 扫描类型
    /// </summary>
    public enum ScanType
    {
        qrcode = 0
    }

    /// <summary>
    /// 
    /// </summary>
    public class PicList
    {
        public string PicMd5Sum { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class SendLocationInfo
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
        /// <summary>
        /// 消息id，64位整型 
        /// </summary>
        public long MsgId { get; set; }
    }

    #endregion
}
