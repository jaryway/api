using Api.Weixin.Pay.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Api.Weixin.Pay
{
    /// <summary>
    /// 
    /// </summary>
    public class WePayConfigFactory
    {
        //[ThreadStatic]
        private static IWePayConfigAdapter _adapter;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="adapter"></param>
        public static void Initialize(IWePayConfigAdapter adapter)
        {
            _adapter = adapter;
        }

        /// <summary>
        /// 获取支付配置，使用前请先初始化Initialize，如果没用初始化则使用默认配置
        /// </summary>
        /// <returns></returns>
        public static WePayConfig Get()
        {
            if (_adapter == null)
            {
                _adapter = new DefaultWePayConfigAdapter();
            }

            return _adapter.Get();
        }
    }
}
