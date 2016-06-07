using API.Caching;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using API.Qy.ThirdAuth.Weixin;

namespace API.Qy.ThirdAuth.Weixin
{
    /// <summary>
    /// 
    /// </summary>
    public static class ThirdAuthTokenManagerExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="manager"></param>
        /// <param name="suiteId"></param>
        /// <param name="suiteSecret"></param>
        /// <param name="suiteTicket"></param>
        /// <returns></returns>
        public static string GetSuiteToken(this TokenManager manager, string suiteId, string suiteSecret, string suiteTicket, APIType type)
        {
            string errMessage;
            return manager.GetSuiteToken(suiteId, suiteSecret, suiteTicket, out errMessage, type);
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
        public static string GetSuiteToken(this TokenManager manager, string suiteId, string suiteSecret,
            string suiteTicket, out string errMessage, APIType type)
        {
            errMessage = string.Empty;
            string cacheKey = string.Format("SUITETOKEN:{0}:{1}:{2}:{3}", suiteId, suiteSecret, suiteTicket, type);
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
        public static string GetPreAuthCode(this TokenManager manager, string suiteId, IList<int> appIds, string suiteAccessToken, APIType type)
        {
            string errMessage;
            return manager.GetPreAuthCode(suiteId, appIds, suiteAccessToken, out errMessage, type);
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
        public static string GetPreAuthCode(this TokenManager manager, string suiteId, IList<int> appIds, string suiteAccessToken, out string errMessage, APIType type)
        {
            errMessage = string.Empty;
            string cacheKey = string.Empty;
            appIds = appIds == null ? new List<int>() : appIds;

            if (appIds == null || appIds.Count() == 0)
                cacheKey = string.Format("PREAUTHCODE:{0}:{1}:{2}:all", suiteId, suiteAccessToken, type);
            else
                cacheKey = string.Format("PREAUTHCODE:{0}:{1}:{2}:{3}", suiteId, suiteAccessToken, type, string.Join("-", appIds.OrderBy(p => p)));

            string pre_auth_code = CacheManager.Instance().Get<string>(cacheKey);

            if (!string.IsNullOrEmpty(pre_auth_code))
                return pre_auth_code;

            var request = new GetPreAuthCodeReqeust();

            request.suite_id = suiteId;
            request.appid = appIds.ToList();
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
        public static string GetCorpToken(this TokenManager manager, string suiteId, string authCorpId,
            string permanentCode, string suiteAccessToken, APIType type)
        {
            string errMessage;
            return manager.GetCorpToken(suiteId, authCorpId, permanentCode, suiteAccessToken, out errMessage, type);
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
        /// <returns></returns>
        public static string GetCorpToken(this TokenManager manager, string suiteId, string authCorpId,
            string permanentCode, string suiteAccessToken, out string errMessage, APIType type)
        {
            errMessage = string.Empty;
            string cacheKey = string.Format("CORPTOKEN:{0}:{1}:{2}:{3}", suiteId, authCorpId, suiteAccessToken, type);
            string access_token = CacheManager.Instance().Get<string>(cacheKey);

            if (!string.IsNullOrEmpty(access_token))
                return access_token;

            var request = new GetCorpTokenRequest();
            request.suite_id = suiteId;
            request.auth_corpid = authCorpId;
            request.permanent_code = permanentCode;
            var result = APIHelper.Instance().Qy(type).GetCorpToken(request, suiteAccessToken);

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
