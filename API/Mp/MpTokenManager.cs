using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using API.Caching;
using API.Helpers;

namespace API.Mp
{
    /// <summary>
    /// 
    /// </summary>
    public class MpTokenManager
    {
        #region Private fields
        private static volatile MpTokenManager _instance = null;
        private static readonly object lockObject = new object();
        /// <summary>
        /// 基础URL
        /// </summary>
        const string baseUrl = "https://api.weixin.qq.com/";
        #endregion

        #region Instance
        /// <summary>
        /// 获取单例对象
        /// </summary>
        /// <returns></returns>
        internal static MpTokenManager Instance()
        {
            if (_instance == null)
            {
                lock (lockObject)
                {
                    if (_instance == null)
                    {
                        _instance = new MpTokenManager();
                    }
                }
            }
            return _instance;
        }
        private MpTokenManager() { }
        #endregion

        /// <summary>
        /// 获取access_token。
        /// 先从缓存获取，没有则从微信端获取。
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="appSecret"></param>
        /// <returns></returns>
        public string GetAccessToken(string appId, string appSecret)
        {
            string errMessage;
            return GetAccessToken(appId, appSecret, out errMessage);
        }
        /// <summary>
        /// 获取access_token。
        /// 先从缓存获取，没有则从微信端获取。
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="appSecret"></param>
        /// <param name="errMessage"></param>
        /// <returns></returns>
        public string GetAccessToken(string appId, string appSecret, out string errMessage)
        {
            errMessage = string.Empty;
            string cacheKey = string.Format("MP-ACCESSTOKEN:{0}:{1}", appId, appSecret);
            string access_token = CacheManager.Instance().Get<string>(cacheKey);

            if (!string.IsNullOrEmpty(access_token))
                return access_token;

            var result = APIHelper.Instance().Mp().GetAccessToken(appId, appSecret);
            if (result.errcode != 0)
            {
                errMessage = string.Format("GetSuiteToken: errcode:{0},errmsg:{1}", result.errcode, result.errmsg);
                return access_token;
            }

            access_token = result.access_token;
            //缓存 access_token
            CacheManager.Instance().Set(cacheKey, access_token, result.expires_in);
            return access_token;
        }
    }
}
