using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API.WeixinPay
{
    public class WeixinPayResult
    {
        /// <summary>
        /// 错误代码，SUCCESS/FAIL
        /// </summary>
        public string return_code { get; set; }
        /// <summary>
        /// 错误信息
        /// </summary>
        public string return_msg { get; set; }
    }
}
