using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace API
{
    /// <summary>
    /// 事件类型
    /// </summary>
    public enum ReceiveEventType
    {
        /// <summary>
        /// 单击
        /// </summary>
        [Display(Name = "单击")]
        click = 0,
        /// <summary>
        /// 浏览
        /// </summary>
        [Display(Name = "跳转")]
        view,
        /// <summary>
        /// 订阅
        /// </summary>
        [Display(Name = "订阅")]
        subscribe,
        /// <summary>
        /// 取消订阅
        /// </summary>
        [Display(Name = "取消订阅")]
        unsubscribe,
        /// <summary>
        /// 上报地理位置事件
        /// </summary>
        [Display(Name = "上报地理位置")]
        LOCATION,
        /// <summary>
        /// 扫码推事件
        /// </summary>
        [Display(Name = "扫码推-PUST")]
        scancode_push,
        /// <summary>
        /// 扫码推事件且弹出“消息接收中”提示框的事件推送
        /// </summary>
        [Display(Name = "扫码推-WAITMSG")]
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
        [Display(Name = "企业会话-会话事件-创建会话")]
        create_chat,
        /// <summary>
        /// 修改会话
        /// </summary>
        [Display(Name = "企业会话-会话事件-修改会话")]
        update_chat,
        /// <summary>
        /// 退出会话
        /// </summary>
        [Display(Name = "企业会话-会话事件-退出会话")]
        quit_chat,

    }
}