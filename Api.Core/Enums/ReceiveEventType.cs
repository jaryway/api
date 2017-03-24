using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api.Core.Enums
{
    /// <summary>
    /// 事件类型
    /// </summary>
    public enum ReceiveEventType
    {
        /// <summary>
        /// 单击
        /// </summary>
        click = 0,
        /// <summary>
        /// 浏览
        /// </summary>
        view,
        /// <summary>
        /// 订阅
        /// </summary>
        subscribe,
        /// <summary>
        /// 取消订阅
        /// </summary>
        unsubscribe,
        /// <summary>
        /// 上报地理位置事件
        /// </summary>
        LOCATION,
        /// <summary>
        /// 扫码推事件
        /// </summary>
        scancode_push,
        /// <summary>
        /// 扫码推事件且弹出“消息接收中”提示框的事件推送
        /// </summary>
        scancode_waitmsg,
        /// <summary>
        /// 弹出系统拍照发图的事件推送
        /// </summary>
        pic_sysphoto,
        /// <summary>
        /// 弹出微信相册发图器的事件推送
        /// </summary>
        pic_photo_or_album,
        /// <summary>
        /// 弹出地理位置选择器的事件推送
        /// </summary>
        location_select,
        /// <summary>
        /// 群发消息推送完成事件推送
        /// </summary>
        MASSSENDJOBFINISH,
        /// <summary>
        /// 创建会话
        /// </summary>
        create_chat,
        /// <summary>
        /// 修改会话
        /// </summary>
        update_chat,
        /// <summary>
        /// 退出会话
        /// </summary>
        quit_chat,

    }
}