using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Api.Weixin.Pay
{
    /// <summary>
    /// 
    /// </summary>
    public class WePayException : Exception
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public WePayException(string message) : base(message) { }
    }
}
