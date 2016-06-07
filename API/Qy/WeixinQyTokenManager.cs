using API.Caching;
using API.Qy.ThirdAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using API.Qy.ThirdAuth.Weixin;

namespace API.Qy
{
    /// <summary>
    /// 
    /// </summary>
    public class WeixinQyTokenManager : IQyTokenManager
    {
        #region Private fields
        private static volatile WeixinQyTokenManager _instance = null;
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
        internal static WeixinQyTokenManager Instance()
        {
            if (_instance == null)
            {
                lock (lockObject)
                {
                    if (_instance == null)
                    {
                        _instance = new WeixinQyTokenManager();
                    }
                }
            }
            return _instance;
        }
        private WeixinQyTokenManager() { }
        #endregion

        #region Methods
        /// <summary>
        /// 获取access_token。
        /// 先从缓存获取，没有则从微信端获取。
        /// </summary>
        /// <param name="manager"></param>
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
        /// <param name="manager"></param>
        /// <param name="corpId"></param>
        /// <param name="corpSecret"></param>
        /// <param name="errMessage"></param>
        /// <returns></returns>
        public string GetAccessToken(string corpId, string corpSecret, out string errMessage)
        {
            errMessage = string.Empty;
            string cacheKey = string.Format("ACCESSTOKEN:{0}:{1}:{2}", corpId, corpSecret, APIType.Weixin);
            string access_token = CacheManager.Instance().Get<string>(cacheKey);

            if (!string.IsNullOrEmpty(access_token))
                return access_token;

            var result = APIHelper.Instance().Qy(APIType.Weixin).GetAccessToken(corpId, corpSecret);
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
        /// <param name="manager"></param>
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
        /// <param name="manager"></param>
        /// <param name="accessToken"></param>
        /// <param name="errMessage"></param>
        /// <returns></returns>
        public string GetJsapiTicket(string accessToken, out string errMessage)
        {
            errMessage = string.Empty;
            string cacheKey = string.Format("JSAPITICKET:{0}:{1}", accessToken, APIType.Weixin);
            string jsapi_ticket = CacheManager.Instance().Get<string>(cacheKey);

            if (!string.IsNullOrEmpty(jsapi_ticket))
                return jsapi_ticket;

            var result = APIHelper.Instance().Qy(APIType.Weixin).GetJsapiTicket(accessToken);
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
        /// <param name="manager"></param>
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
        /// <param name="manager"></param>
        /// <param name="corpid">企业号（提供商）的corpid </param>
        /// <param name="provider_secret">提供商的secret，在提供商管理页面可见</param>
        /// <param name="errMessage">错误信息</param>
        /// <returns></returns>
        public string GetProviderToken(string corpid, string provider_secret, out string errMessage)
        {
            errMessage = string.Empty;
            string cacheKey = string.Format("PROVIDERTOKEN:{0}:{1}:{2}:{3}", corpid, provider_secret, APIType.Weixin);
            string provider_access_token = CacheManager.Instance().Get<string>(cacheKey);

            if (!string.IsNullOrEmpty(provider_access_token))
                return provider_access_token;

            var result = APIHelper.Instance().Qy(APIType.Weixin).GetProviderToken(corpid, provider_secret);
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
        /// <param name="manager"></param>
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
        /// <param name="manager"></param>
        /// <param name="suiteId"></param>
        /// <param name="suiteSecret"></param>
        /// <param name="suiteTicket"></param>
        /// <returns></returns>
        public string GetSuiteToken(string suiteId, string suiteSecret, string suiteTicket, out string errMessage)
        {
            errMessage = string.Empty;
            string cacheKey = string.Format("SUITETOKEN:{0}:{1}:{2}:{3}", suiteId, suiteSecret, suiteTicket, APIType.Weixin);
            string suite_access_token = CacheManager.Instance().Get<string>(cacheKey);

            if (!string.IsNullOrEmpty(suite_access_token))
                return suite_access_token;

            var request = new GetSuiteTokenRequest();
            request.suite_id = suiteId;
            request.suite_secret = suiteSecret;
            request.suite_ticket = suiteTicket;
            var result = APIHelper.Instance().Qy().GetSuiteToken(request);
            if (result.errcode != 0)
            {
                errMessage = string.Format("GetSuiteToken: errcode:{0},errmsg:{1}", result.errcode, result.errmsg);
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
        /// <param name="manager"></param>
        /// <param name="suiteId"></param>
        /// <param name="appIds"></param>
        /// <param name="suiteAccessToken"></param>
        /// <returns></returns>
        public string GetPreAuthCode(string suiteId, IList<int> appIds, string suiteAccessToken)
        {
            string errMessage;
            return GetPreAuthCode(suiteId, appIds, suiteAccessToken, out errMessage);
        }

        /// <summary>
        /// 获取预授权码。
        /// 先从本地缓存获取，没有则从微信端获取。
        /// </summary>
        /// <param name="manager"></param>
        /// <param name="suiteId"></param>
        /// <param name="appIds"></param>
        /// <param name="suiteAccessToken"></param>
        /// <returns></returns>
        public string GetPreAuthCode(string suiteId, IList<int> appIds, string suiteAccessToken, out string errMessage)
        {
            errMessage = string.Empty;
            string cacheKey = string.Empty;
            appIds = appIds == null ? new List<int>() : appIds;

            if (appIds == null || appIds.Count() == 0)
                cacheKey = string.Format("PREAUTHCODE:{0}:{1}:all:{2}", suiteId, suiteAccessToken, APIType.Weixin);
            else
                cacheKey = string.Format("PREAUTHCODE:{0}:{1}:{2}:{3}", suiteId, suiteAccessToken, string.Join("-", appIds.OrderBy(p => p)), APIType.Weixin);

            string pre_auth_code = CacheManager.Instance().Get<string>(cacheKey);

            if (!string.IsNullOrEmpty(pre_auth_code))
                return pre_auth_code;

            var request = new GetPreAuthCodeReqeust();

            request.suite_id = suiteId;
            request.appid = appIds.ToList();
            //request.SetUrl(WeixinUrls.Instance().Qy_GetPreAuthCode(suiteAccessToken));
            var result = APIHelper.Instance().Qy().GetPreAuthCode(request, suiteAccessToken);
            if (result.errcode != 0)
            {
                errMessage = string.Format("GetPreAuthCode: errcode:{0},errmsg:{1}", result.errcode, result.errmsg);
                return pre_auth_code;
            }

            //缓存pre_auth_code
            pre_auth_code = result.pre_auth_code;
            CacheManager.Instance().Set(cacheKey, pre_auth_code, result.expires_in);

            return pre_auth_code;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="manager"></param>
        /// <param name="suiteId"></param>
        /// <param name="authCorpId"></param>
        /// <param name="permanentCode"></param>
        /// <param name="suiteAccessToken"></param>
        /// <returns></returns>
        public string GetCorpToken(string suiteId, string authCorpId, string permanentCode,
            string suiteAccessToken)
        {
            string errMessage;
            return GetCorpToken(suiteId, authCorpId, permanentCode, suiteAccessToken, out errMessage);
        }
        /// <summary>
        /// 获取企业号access_token。
        /// 先从本地缓存获取，没有则从微信端获取。
        /// </summary>
        /// <param name="suiteId"></param>
        /// <param name="authCorpId">授权的企业号ID</param>
        /// <param name="permanentCode">永久授权码</param>
        /// <param name="suiteAccessToken"></param>
        /// <returns></returns>
        public string GetCorpToken(string suiteId, string authCorpId, string permanentCode,
            string suiteAccessToken, out string errMessage)
        {
            errMessage = string.Empty;
            string cacheKey = string.Format("CORPTOKEN:{0}:{1}:{2}:{3}", suiteId, authCorpId, suiteAccessToken, APIType.Weixin);
            string access_token = CacheManager.Instance().Get<string>(cacheKey);

            if (!string.IsNullOrEmpty(access_token))
                return access_token;

            var request = new GetCorpTokenRequest();
            request.suite_id = suiteId;
            request.auth_corpid = authCorpId;
            request.permanent_code = permanentCode;
            var result = APIHelper.Instance().Qy().GetCorpToken(request, suiteAccessToken);

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
        #endregion
    }
}
