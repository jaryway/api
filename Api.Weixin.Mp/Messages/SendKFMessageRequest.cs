using Api.Core;
using Api.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Api.Weixin.Mp
{
    /// <summary>
    /// 客服消息
    /// </summary>
    public class SendKFMessageRequest : IRequest
    {
        /// <summary>
        /// 普通用户openid 
        /// </summary>
        public string touser { get; set; }
        /// <summary>
        /// 消息类型，文本为text，图片为image，语音为voice，视频消息为video，音乐消息为music，图文消息为news，卡券为wxcard
        /// </summary>
        public string msgtype { get; set; }
        /// <summary>
        /// 发送文本消息
        /// </summary>
        public Text text { get; set; }
        /// <summary>
        /// 发送图片消息
        /// </summary>
        public Image image { get; set; }
        /// <summary>
        /// 发送语音消息
        /// </summary>
        public Voice voice { get; set; }
        /// <summary>
        /// 发送视频消息
        /// </summary>
        public Video video { get; set; }
        /// <summary>
        /// 发送音乐消息
        /// </summary>
        public Music music { get; set; }

        /// <summary>
        /// 发送图文消息
        /// </summary>
        public News news { get; set; }
        /// <summary>
        /// 发送卡券
        /// </summary>
        public wxcard wxcard { get; set; }
    }
}
