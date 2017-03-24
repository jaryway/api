using Api.Core.Caching;
using System.Collections.Generic;
using System.Linq;

namespace Api.Weixin.Qy.ThirdAuth
{
    /// <summary>
    /// 
    /// </summary>
    public static class ThirdAuthTokenManagerExtensions
    {

        /// <summary>
        /// 获取应用提供商凭证。
        /// 先从缓存获取，没有则从微信端获取。
        /// </summary>
        /// <param name="manager"></param>
        /// <param name="corpid">企业号（提供商）的corpid </param>
        /// <param name="provider_secret">提供商的secret，在提供商管理页面可见</param>
        /// <returns></returns>
        public static string GetProviderToken(this TokenManager manager, string corpid, string provider_secret)
        {
            string errmessage;
            return manager.GetProviderToken(corpid, provider_secret, out errmessage);
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
        public static string GetProviderToken(this TokenManager manager, string corpid, string provider_secret, out string errMessage)
        {
            errMessage = string.Empty;
            string cacheKey = string.Format("PROVIDERTOKEN:{0}:{1}", corpid, provider_secret);
            string provider_access_token = CacheManager.Instance().Get<string>(cacheKey);

            if (!string.IsNullOrEmpty(provider_access_token))
                return provider_access_token;

            var result = ApiHelper.Instance().GetProviderToken(corpid, provider_secret);
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
        public static string GetSuiteToken(this TokenManager manager, string suiteId, string suiteSecret, string suiteTicket)
        {
            string errMessage;
            return manager.GetSuiteToken(suiteId, suiteSecret, suiteTicket, out errMessage);
        }
        /// <summary>
        /// 获取应用套件令牌。
        /// 先从本地缓存获取，没有则从微信端获取。
        /// </summary>
        /// <param name="manager"></param>
        /// <param name="suiteId"></param>
        /// <param name="suiteSecret"></param>
        /// <param name="suiteTicket"></param>
        /// <param name="errMessage"></param>
        /// <returns></returns>
        public static string GetSuiteToken(this TokenManager manager, string suiteId, string suiteSecret, string suiteTicket, out string errMessage)
        {
            errMessage = string.Empty;
            string cacheKey = string.Format("SUITETOKEN:{0}:{1}:{2}", suiteId, suiteSecret, suiteTicket);
            string suite_access_token = CacheManager.Instance().Get<string>(cacheKey);

            if (!string.IsNullOrEmpty(suite_access_token))
                return suite_access_token;

            var request = new GetSuiteTokenRequest();
            request.suite_id = suiteId;
            request.suite_secret = suiteSecret;
            request.suite_ticket = suiteTicket;
            var result = ApiHelper.Instance().GetSuiteToken(request);
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
        public static string GetPreAuthCode(this TokenManager manager, string suiteId, IList<int> appIds, string suiteAccessToken)
        {
            string errMessage;
            return manager.GetPreAuthCode(suiteId, appIds, suiteAccessToken, out errMessage);
        }

        /// <summary>
        /// 获取预授权码。
        /// 先从本地缓存获取，没有则从微信端获取。
        /// </summary>
        /// <param name="manager"></param>
        /// <param name="suiteId"></param>
        /// <param name="appIds"></param>
        /// <param name="suiteAccessToken"></param>
        /// <param name="errMessage"></param>
        /// <returns></returns>
        public static string GetPreAuthCode(this TokenManager manager, string suiteId, IList<int> appIds, string suiteAccessToken, out string errMessage)
        {
            errMessage = string.Empty;
            string cacheKey = string.Empty;
            appIds = appIds == null ? new List<int>() : appIds;

            if (appIds == null || appIds.Count() == 0)
                cacheKey = string.Format("PREAUTHCODE:{0}:{1}:all", suiteId, suiteAccessToken);
            else
                cacheKey = string.Format("PREAUTHCODE:{0}:{1}:{2}", suiteId, suiteAccessToken, string.Join("-", appIds.OrderBy(p => p)));

            string pre_auth_code = CacheManager.Instance().Get<string>(cacheKey);

            if (!string.IsNullOrEmpty(pre_auth_code))
                return pre_auth_code;

            var request = new GetPreAuthCodeReqeust();

            request.suite_id = suiteId;
            request.appid = appIds.ToList();
            var result = ApiHelper.Instance().GetPreAuthCode(suiteAccessToken, request);
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
        public static string GetCorpToken(this TokenManager manager, string suiteId, string authCorpId, string permanentCode,
            string suiteAccessToken)
        {
            string errMessage;
            return manager.GetCorpToken(suiteId, authCorpId, permanentCode, suiteAccessToken, out errMessage);
        }
        /// <summary>
        /// 获取企业号access_token。
        /// 先从本地缓存获取，没有则从微信端获取。
        /// </summary>
        /// <param name="manager"></param>
        /// <param name="suiteId"></param>
        /// <param name="authCorpId">授权的企业号ID</param>
        /// <param name="permanentCode">永久授权码</param>
        /// <param name="suiteAccessToken"></param>
        /// <param name="errMessage"></param>
        /// <returns></returns>
        public static string GetCorpToken(this TokenManager manager, string suiteId, string authCorpId, string permanentCode,
            string suiteAccessToken, out string errMessage)
        {
            errMessage = string.Empty;
            string cacheKey = string.Format("CORPTOKEN:{0}:{1}:{2}", suiteId, authCorpId, suiteAccessToken);
            string access_token = CacheManager.Instance().Get<string>(cacheKey);

            if (!string.IsNullOrEmpty(access_token))
                return access_token;

            var request = new GetCorpTokenRequest();
            request.suite_id = suiteId;
            request.auth_corpid = authCorpId;
            request.permanent_code = permanentCode;
            var result = ApiHelper.Instance().GetCorpToken(suiteAccessToken, request);

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
    }
}
