using API.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API.WeixinPay
{
    /// <summary>
    /// 
    /// </summary>
    public class WeixinPayHelper
    {
        #region Private fields
        private static volatile WeixinPayHelper _instance = null;
        private static readonly object lockObject = new object();
        /// <summary>
        /// 基础URL
        /// </summary>
        const string baseUrl = "https://api.mch.weixin.qq.com/";
        #endregion

        #region Instance
        /// <summary>
        /// 获取单例对象
        /// </summary>
        /// <returns></returns>
        public static WeixinPayHelper Instance()
        {
            if (_instance == null)
            {
                lock (lockObject)
                {
                    if (_instance == null)
                    {
                        _instance = new WeixinPayHelper();
                    }
                }
            }
            return _instance;
        }
        private WeixinPayHelper() { }
        #endregion

        /// <summary>
        /// 统一下单接口
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public UnifiedOrderResult UnifiedOrder(UnifiedOrderRequest request)
        {
            string url = string.Format("{0}pay/unifiedorder", baseUrl);
            return HttpHelper.HttpPost.GetXmlResult<UnifiedOrderRequest, UnifiedOrderResult>(url, request);
        }
    }
}
