
using Api.Core.Caching;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Api.Weixin.Qy
{
    /// <summary>
    /// 
    /// </summary>
    public class TokenManager
    {
        #region Private fields
        private static volatile TokenManager _instance = null;
        private static readonly object lockObject = new object();
        /// <summary>
        /// 基础URL
        /// </summary>
        const string baseUrl = "https://qyapi.weixin.qq.com/cgi-bin/";
        #endregion

        #region Instance
        /// <summary>
        /// 获取单例对象
        /// </summary>
        /// <returns></returns>
        public static TokenManager Instance()
        {
            if (_instance == null)
            {
                lock (lockObject)
                {
                    if (_instance == null)
                    {
                        _instance = new TokenManager();
                    }
                }
            }
            return _instance;
        }
        private TokenManager() { }
        #endregion

        #region Methods
        /// <summary>
        /// 获取access_token。
        /// 先从缓存获取，没有则从微信端获取。
        /// </summary>
        /// <param name="corpId"></param>
        /// <param name="corpSecret"></param>
        /// <returns></returns>
        public string GetAccessToken(string corpId, string corpSecret)
        {
            string errMessage;
            return GetAccessToken(corpId, corpSecret, out errMessage);
        }
        /// <summary>
        /// 获取access_token。
        /// 先从缓存获取，没有则从微信端获取。
        /// </summary>
        /// <param name="corpid"></param>
        /// <param name="corpsecret"></param>
        /// <param name="errmessage"></param>
        /// <returns></returns>
        public string GetAccessToken(string corpid, string corpsecret, out string errmessage)
        {
            errmessage = string.Empty;
            string cacheKey = string.Format("ACCESSTOKEN:{0}:{1}", corpid, corpsecret);
            string access_token = CacheManager.Instance().Get<string>(cacheKey);

            if (!string.IsNullOrEmpty(access_token))
                return access_token;

            var result = ApiHelper.Instance().GetAccessToken(corpid, corpsecret);
            if (result.errcode != 0)
            {
                errmessage = string.Format("GetSuiteToken: errcode:{0},errmsg:{1}", result.errcode, result.errmsg);
                return access_token;
            }

            access_token = result.access_token;
            //缓存 access_token
            CacheManager.Instance().Set(cacheKey, access_token, result.expires_in);
            return access_token;
        }

        /// <summary>
        /// 获取jsapi_ticket。
        /// 先从缓存获取，没有则从微信端获取。
        /// </summary>
        /// <param name="access_token"></param>
        /// <returns></returns>
        public string GetJsapiTicket(string access_token)
        {
            string errmessage;
            return GetJsapiTicket(access_token, out errmessage);
        }
        /// <summary>
        /// 获取jsapi_ticket。
        /// 先从缓存获取，没有则从微信端获取。
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="errMessage"></param>
        /// <returns></returns>
        public string GetJsapiTicket(string access_token, out string errMessage)
        {
            errMessage = string.Empty;
            string cacheKey = string.Format("JSAPITICKET:{0}", access_token);
            string jsapi_ticket = CacheManager.Instance().Get<string>(cacheKey);

            if (!string.IsNullOrEmpty(jsapi_ticket))
                return jsapi_ticket;

            var result = ApiHelper.Instance().GetJsapiTicket(access_token);
            if (result.errcode != 0)
            {
                errMessage = string.Format("GetJsapiTicket: errcode:{0},errmsg:{1}", result.errcode, result.errmsg);
                return jsapi_ticket;
            }

            jsapi_ticket = result.ticket;
            //缓存 jsapi_ticket
            CacheManager.Instance().Set(cacheKey, jsapi_ticket, result.expires_in);
            return jsapi_ticket;
        }


        #endregion
    }
}
