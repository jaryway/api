using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace API.Qy
{
    /// <summary>
    /// 
    /// </summary>
    public static class QyTokenManagerExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="manager"></param>
        /// <returns></returns>
        public static IQyTokenManager Qy(this TokenManager manager, APIType type=APIType.Weixin)
        {
            switch (type)
            {
                default:
                case APIType.Weixin:
                    return WeixinQyTokenManager.Instance();
                case APIType.Dingtalk:
                    return DingtalkQyTokenManager.Instance();
            }
        }
    }
}
