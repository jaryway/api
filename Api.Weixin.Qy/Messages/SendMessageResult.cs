﻿using Api.Core;
using System;


namespace Api.Weixin.Qy
{
    /// <summary>
    /// 
    /// </summary>
    public class SendMessageResult : JsonResult
    {
        /// <summary>
        /// 无效用户
        /// </summary>
        public string invaliduser { get; set; }
        /// <summary>
        /// 无效部门
        /// </summary>
        public string invalidparty { get; set; }
        /// <summary>
        /// 无效标签
        /// </summary>
        public string invalidtag { get; set; }
    }
}