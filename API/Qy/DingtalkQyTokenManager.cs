using API.Caching;
using API.Qy.ThirdAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using API.Qy.ThirdAuth.Dingtalk;

namespace API.Qy
{
    /// <summary>
    /// 
    /// </summary>
    public class DingtalkQyTokenManager : IQyTokenManager
    {
        #region Private fields
        private static volatile DingtalkQyTokenManager _instance = null;
        private static readonly object lockObject = new object();
        /// <summary>
        /// 基础URL
        /// </summary>
        const string baseUrl = "https://oapi.dingtalk.com/";
        #endregion

        #region Instance
        /// <summary>
        /// 获取单例对象
        /// </summary>
        /// <returns></returns>
        internal static DingtalkQyTokenManager Instance()
        {
            if (_instance == null)
            {
                lock (lockObject)
                {
                    if (_instance == null)
                    {
                        _instance = new DingtalkQyTokenManager();
                    }
                }
            }
            return _instance;
        }
        private DingtalkQyTokenManager() { }
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
        /// <param name="corpId"></param>
        /// <param name="corpSecret"></param>
        /// <param name="errMessage"></param>
        /// <returns></returns>
        public string GetAccessToken(string corpId, string corpSecret, out string errMessage)
        {
            errMessage = string.Empty;
            string cacheKey = string.Format("ACCESSTOKEN:{0}:{1}:{2}", corpId, corpSecret, APIType.Dingtalk);
            string access_token = CacheManager.Instance().Get<string>(cacheKey);

            if (!string.IsNullOrEmpty(access_token))
                return access_token;

            var result = APIHelper.Instance().Qy(APIType.Dingtalk).GetAccessToken(corpId, corpSecret);
            if (result.errcode != 0)
            {
                errMessage = string.Format("GetSuiteToken: errcode:{0},errmsg:{1}", result.errcode, result.errmsg);
                return access_token;
            }

            access_token = result.access_token;
            //缓存 access_token
            CacheManager.Instance().Set(cacheKey, access_token, 7200);
            return access_token;
        }

        /// <summary>
        /// 获取jsapi_ticket。
        /// 先从缓存获取，没有则从微信端获取。
        /// </summary>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        public string GetJsapiTicket(string accessToken)
        {
            string errMessage;
            return GetJsapiTicket(accessToken, out errMessage);
        }
        /// <summary>
        /// 获取jsapi_ticket。
        /// 先从缓存获取，没有则从微信端获取。
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="errMessage"></param>
        /// <returns></returns>
        public string GetJsapiTicket(string accessToken, out string errMessage)
        {
            errMessage = string.Empty;
            string cacheKey = string.Format("JSAPITICKET:{0}:{1}", accessToken, APIType.Dingtalk);
            string jsapi_ticket = CacheManager.Instance().Get<string>(cacheKey);

            if (!string.IsNullOrEmpty(jsapi_ticket))
                return jsapi_ticket;

            var result = APIHelper.Instance().Qy(APIType.Dingtalk).GetJsapiTicket(accessToken);
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

        /// <summary>
        /// 获取应用提供商凭证。
        /// 先从缓存获取，没有则从微信端获取。
        /// </summary>
        /// <param name="corpid">企业号（提供商）的corpid </param>
        /// <param name="provider_secret">提供商的secret，在提供商管理页面可见</param>
        /// <returns></returns>
        public string GetProviderToken(string corpid, string provider_secret)
        {
            string errMessage;
            return GetProviderToken(corpid, provider_secret, out errMessage);
        }
        /// <summary>
        /// 获取应用提供商凭证。
        /// 先从缓存获取，没有则从微信端获取。
        /// </summary>
        /// <param name="corpid">企业号（提供商）的corpid </param>
        /// <param name="provider_secret">提供商的secret，在提供商管理页面可见</param>
        /// <param name="errMessage">错误信息</param>
        /// <returns></returns>
        public string GetProviderToken(string corpid, string provider_secret, out string errMessage)
        {
            errMessage = string.Empty;
            string cacheKey = string.Format("PROVIDERTOKEN:{0}:{1}:{2}:{3}", corpid, provider_secret, APIType.Dingtalk);
            string provider_access_token = CacheManager.Instance().Get<string>(cacheKey);

            if (!string.IsNullOrEmpty(provider_access_token))
                return provider_access_token;

            var result = APIHelper.Instance().Qy(APIType.Dingtalk).GetProviderToken(corpid, provider_secret);
            if (result.errcode != 0)
            {
                errMessage = string.Format("GetProviderToken: errcode:{0},errmsg:{1}", result.errcode, result.errmsg);
                return provider_access_token;
            }

            provider_access_token = result.provider_access_token;
            //缓存 access_token
            CacheManager.Instance().Set(cacheKey, provider_access_token, result.expires_in);
            return provider_access_token;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="suiteId"></param>
        /// <param name="suiteSecret"></param>
        /// <param name="suiteTicket"></param>
        /// <returns></returns>
        public string GetSuiteToken(string suiteId, string suiteSecret, string suiteTicket)
        {
            string errMessage;
            return GetSuiteToken(suiteId, suiteSecret, suiteTicket, out errMessage);
        }
        /// <summary>
        /// 获取应用套件令牌。
        /// 先从本地缓存获取，没有则从微信端获取。
        /// </summary>
        /// <param name="suite_key"></param>
        /// <param name="suite_secret"></param>
        /// <param name="suite_ticket"></param>
        /// <param name="errMessage"></param>
        /// <returns></returns>
        public string GetSuiteToken(string suite_key, string suite_secret, string suite_ticket, out string errMessage)
        {
            errMessage = string.Empty;
            string cacheKey = string.Format("SUITETOKEN:{0}:{1}:{2}:{3}", suite_key, suite_secret, suite_ticket, APIType.Dingtalk);
            string suite_access_token = CacheManager.Instance().Get<string>(cacheKey);

            if (!string.IsNullOrEmpty(suite_access_token))
                return suite_access_token;

            var result = APIHelper.Instance().Qy().DtGetSuiteToken(suite_key, suite_secret, suite_ticket);
            if (result.errcode != 0)
            {
                errMessage = string.Format("GetSuiteToken: errcode:{0},errmsg:{1},suite_key:{2}", result.errcode, result.errmsg, suite_key);
                return suite_access_token;
            }

            //缓存suite_access_token
            suite_access_token = result.suite_access_token;
            CacheManager.Instance().Set(cacheKey, suite_access_token, result.expires_in);

            return suite_access_token;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="suiteId"></param>
        /// <param name="auth_corpid"></param>
        /// <param name="permanent_code"></param>
        /// <param name="suite_access_token"></param>
        /// <returns></returns>
        public string GetCorpToken(string suiteId, string auth_corpid, string permanent_code,
            string suite_access_token)
        {
            string errMessage;
            return GetCorpToken(suiteId, auth_corpid, permanent_code, suite_access_token, out errMessage);
        }
        /// <summary>
        /// 获取企业号access_token。
        /// 先从本地缓存获取，没有则从微信端获取。
        /// </summary>
        /// <param name="suiteId"></param>
        /// <param name="auth_corpid">授权的企业号ID</param>
        /// <param name="permanent_code">永久授权码</param>
        /// <param name="suite_access_token"></param>
        /// <param name="errMessage"></param>
        /// <returns></returns>
        public string GetCorpToken(string suiteId, string auth_corpid, string permanent_code,
            string suite_access_token, out string errMessage)
        {
            errMessage = string.Empty;
            string cacheKey = string.Format("CORPTOKEN:{0}:{1}:{2}:{3}", suiteId, auth_corpid, suite_access_token, APIType.Dingtalk);
            string access_token = CacheManager.Instance().Get<string>(cacheKey);

            if (!string.IsNullOrEmpty(access_token))
                return access_token;

            var result = APIHelper.Instance().Qy().DtGetCorpToken(suite_access_token, auth_corpid, permanent_code);

            if (result.errcode != 0)
            {
                errMessage = string.Format("GetCorpToken: errcode:{0},errmsg:{1}", result.errcode, result.errmsg);
                return access_token;
            }

            //缓存corp_token
            access_token = result.access_token;
            CacheManager.Instance().Set(cacheKey, access_token, result.expires_in);

            return access_token;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="suiteId"></param>
        /// <param name="appIds"></param>
        /// <param name="suiteAccessToken"></param>
        /// <returns></returns>
        public string GetPreAuthCode(string suiteId, IList<int> appIds, string suiteAccessToken)
        {
            throw new NotImplementedException("钉钉没有这个接口");
        }

        public string GetPreAuthCode(string suiteId, IList<int> appIds, string suiteAccessToken, out string errMessage)
        {
            throw new NotImplementedException("钉钉没有这个接口");
        }
        #endregion



    }
}
