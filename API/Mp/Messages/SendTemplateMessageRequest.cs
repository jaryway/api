using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API.Mp
{
    /// <summary>
    /// 发送模板消息请求
    /// </summary>
    public class SendTemplateMessageRequest : IRequest
    {
        /// <summary>
        /// 接收者的openID
        /// </summary>
        public string touser { get; set; }
        /// <summary>
        /// 模板ID
        /// </summary>
        public string template_id { get; set; }
        /// <summary>
        /// 链接地址
        /// </summary>
        public string url { get; set; }
        /// <summary>
        /// 顶部颜色
        /// </summary>
        public string topcolor { get; set; }

        /// <summary>
        /// 模板数据
        /// </summary>
        public Data data { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public class Data
        {
            /// <summary>
            /// 
            /// </summary>
            public DataItem first { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public DataItem keynote1 { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public DataItem keynote2 { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public DataItem keynote3 { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public DataItem remark { get; set; }
        }

        public class DataItem
        {
            /// <summary>
            /// 
            /// </summary>
            public string value { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string color { get; set; }
        }
    }

    public class TemplateMessageData
    {
        //public 
    }
}
