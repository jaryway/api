using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Api.Core.XmlModels
{
    /// <summary>
    /// 关注/取消关注事件
    /// </summary>
    [XmlRoot("xml")]
    public class ReceiveMessageSubscribeEvent : ReceiveMessageEventBase
    {
        ///// <summary>
        ///// 事件KEY值，与菜单接口中KEY值对应
        ///// </summary>
        //public string EventKey { get; set; }
    }
    /// <summary>
    /// 点击菜单拉取消息时的事件推送
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
    /// 点击菜单跳转链接时的事件推送
    /// </summary>
    [XmlRoot("xml")]
    public class ReceiveMessageViewEvent : ReceiveMessageEventBase
    {
        /// <summary>
        /// 事件KEY值，与菜单接口中KEY值对应
        /// </summary>
        public string EventKey { get; set; }
    }
    /// <summary>
    /// 接收事件推送之上报地理位置事件
    /// </summary>
    [XmlRoot("xml")]
    public class ReceiveMessageLocationEvent : ReceiveMessageEventBase
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
    /// 接收事件推送之菜单事件推送
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
    /// 接收事件推送之弹出微信相册发图器的事件推送
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
    /// 接收事件推送之弹出地理位置选择器的事件推送
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

    /// <summary>
    /// 群发消息完成事件推送
    /// </summary>
    [XmlRoot("xml")]
    public class ReceiveMessageMassSendFinishEvent : ReceiveMessageEventBase
    {
        /// <summary>
        /// 群发的消息ID 
        /// </summary>
        public string MsgID { get; set; }

        /// <summary>
        /// 群发的结构，为“send success”或“send fail”或“err(num)”。但send success时，也有可能因用户拒收公众号的消息、系统错误等原因造成少量用户接收失败。err(num)是审核失败的具体原因，可能的情况如下：
        /// err(10001), //涉嫌广告 err(20001), //涉嫌政治 err(20004), //涉嫌社会 err(20002), //涉嫌色情 err(20006), //涉嫌违法犯罪 err(20008), //涉嫌欺诈 err(20013), //涉嫌版权 err(22000), //涉嫌互推(互相宣传) err(21000), //涉嫌其他 
        /// </summary>
        private string Status { get; set; }

        /// <summary>
        /// 发送的图片信息
        /// </summary>
        public int TotalCount { get; set; }
        /// <summary>
        /// 过滤（过滤是指特定地区、性别的过滤、用户设置拒收的过滤，用户接收已超4条的过滤）后，准备发送的粉丝数，原则上，FilterCount = SentCount + ErrorCount 
        /// </summary>
        public int FilterCount { get; set; }
        /// <summary>
        /// 发送成功的粉丝数
        /// </summary>
        public int SentCount { get; set; }
        /// <summary>
        /// 发送失败的粉丝数
        /// </summary>
        public int ErrorCount { get; set; }
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
        /// <summary>
        /// 
        /// </summary>
        public SendPicsInfo()
        {
            //PicList = new List<PicList>();
        }
        private int _count = 0;
        private List<PicList> picList = new List<PicList>();
        /// <summary>
        /// 
        /// </summary>
        public int Count
        {
            get { return _count; }
            set { _count = value; }
        }
        /// <summary>
        /// 
        /// </summary>
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
        /// <summary>
        /// 
        /// </summary>
        qrcode = 0
    }

    /// <summary>
    /// 
    /// </summary>
    public class PicList
    {
        /// <summary>
        /// 
        /// </summary>
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
