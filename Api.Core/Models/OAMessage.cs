using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Api.Core.Models
{/// <summary>
 /// OA消息 钉钉特有
 /// </summary>
    public class OAMessage
    {
        /// <summary>
        /// 消息点击链接地址
        /// </summary>
        public string message_url { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Head head { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Body body { get; set; }

        #region SubClass
        /// <summary>
        /// 消息头部内容
        /// </summary>
        public class Head
        {
            /// <summary>
            /// 消息头部的背景颜色。长度限制为8个英文字符，其中前2为表示透明度，后6位表示颜色值。不要添加0x 
            /// </summary>
            public string bgcolor { get; set; }
            /// <summary>
            /// 消息的头部标题
            /// </summary>
            public string text { get; set; }
        }

        /// <summary>
        /// 
        /// </summary>
        public class Body
        {
            /// <summary>
            /// 消息体的标题 
            /// </summary>
            public string title { get; set; }
            /// <summary>
            /// 消息体的表单，最多显示6个，超过会被隐藏
            /// </summary>
            public FormItem[] form { get; set; }
            /// <summary>
            /// 单行富文本信息
            /// </summary>
            public Rich rich { get; set; }
            /// <summary>
            /// 消息的头部标题
            /// </summary>
            public string content { get; set; }
            /// <summary>
            /// 消息体中的图片media_id
            /// </summary>
            public string image { get; set; }
            /// <summary>
            /// 自定义的附件数目。此数字仅供显示，钉钉不作验证
            /// </summary>
            public string file_count { get; set; }
            /// <summary>
            /// 自定义的作者名字
            /// </summary>
            public string author { get; set; }
        }

        /// <summary>
        /// 
        /// </summary>
        public class Rich
        {
            /// <summary>
            /// 单行富文本信息的数目
            /// </summary>
            public string num { get; set; }
            /// <summary>
            /// 单行富文本信息的单位
            /// </summary>
            public string unit { get; set; }
        }
        /// <summary>
        /// 
        /// </summary>
        public class FormItem
        {
            /// <summary>
            /// 消息体的关键字 
            /// </summary>
            public string key { get; set; }
            /// <summary>
            /// 消息体的关键字对应的值
            /// </summary>
            public string value { get; set; }
        }
        #endregion
    }
}
