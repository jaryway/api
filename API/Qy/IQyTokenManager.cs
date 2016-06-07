using API.Caching;
using API.Qy.ThirdAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API.Qy
{
    /// <summary>
    /// 
    /// </summary>
    public interface IQyTokenManager
    {

        /// <summary>
        /// 获取access_token。
        /// 先从缓存获取，没有则从微信端获取。
        /// </summary>
        /// <param name="manager"></param>
        /// <param name="corpId"></param>
        /// <param name="corpSecret"></param>
        /// <returns></returns>
        string GetAccessToken(string corpId, string corpSecret);
        /// <summary>
        /// 获取access_token。
        /// 先从缓存获取，没有则从微信端获取。
        /// </summary>
        /// <param name="manager"></param>
        /// <param name="corpId"></param>
        /// <param name="corpSecret"></param>
        /// <param name="errMessage"></param>
        /// <returns></returns>
        string GetAccessToken(string corpId, string corpSecret, out string errMessage);

        /// <summary>
        /// 获取jsapi_ticket。
        /// 先从缓存获取，没有则从微信端获取。
        /// </summary>
        /// <param name="manager"></param>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        string GetJsapiTicket(string accessToken);
        /// <summary>
        /// 获取jsapi_ticket。
        /// 先从缓存获取，没有则从微信端获取。
        /// </summary>
        /// <param name="manager"></param>
        /// <param name="accessToken"></param>
        /// <param name="errMessage"></param>
        /// <returns></returns>
        string GetJsapiTicket(string accessToken, out string errMessage);

        /// <summary>
        /// 获取应用提供商凭证。
        /// 先从缓存获取，没有则从微信端获取。
        /// </summary>
        /// <param name="manager"></param>
        /// <param name="corpid">企业号（提供商）的corpid </param>
        /// <param name="provider_secret">提供商的secret，在提供商管理页面可见</param>
        /// <returns></returns>
        string GetProviderToken(string corpid, string provider_secret);
        /// <summary>
        /// 获取应用提供商凭证。
        /// 先从缓存获取，没有则从微信端获取。
        /// </summary>
        /// <param name="manager"></param>
        /// <param name="corpid">企业号（提供商）的corpid </param>
        /// <param name="provider_secret">提供商的secret，在提供商管理页面可见</param>
        /// <param name="errMessage">错误信息</param>
        /// <returns></returns>
        string GetProviderToken(string corpid, string provider_secret, out string errMessage);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="manager"></param>
        /// <param name="suiteId"></param>
        /// <param name="suiteSecret"></param>
        /// <param name="suiteTicket"></param>
        /// <returns></returns>
        string GetSuiteToken(string suiteId, string suiteSecret, string suiteTicket);

        /// <summary>
        /// 获取应用套件令牌。
        /// 先从本地缓存获取，没有则从微信端获取。
        /// </summary>
        /// <param name="manager"></param>
        /// <param name="suiteId"></param>
        /// <param name="suiteSecret"></param>
        /// <param name="suiteTicket"></param>
        /// <returns></returns>
        string GetSuiteToken(string suiteId, string suiteSecret, string suiteTicket, out string errMessage);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="manager"></param>
        /// <param name="suiteId"></param>
        /// <param name="appIds"></param>
        /// <param name="suiteAccessToken"></param>
        /// <returns></returns>
        string GetPreAuthCode(string suiteId, IList<int> appIds, string suiteAccessToken);

        /// <summary>
        /// 获取预授权码。
        /// 先从本地缓存获取，没有则从微信端获取。
        /// </summary>
        /// <param name="manager"></param>
        /// <param name="suiteId"></param>
        /// <param name="appIds"></param>
        /// <param name="suiteAccessToken"></param>
        /// <returns></returns>
        string GetPreAuthCode(string suiteId, IList<int> appIds, string suiteAccessToken, out string errMessage);

        /// <summary>
        /// 第三方获取授权方的access_token。
        /// </summary>
        /// <param name="manager"></param>
        /// <param name="suiteId"></param>
        /// <param name="authCorpId"></param>
        /// <param name="permanentCode"></param>
        /// <param name="suiteAccessToken"></param>
        /// <returns></returns>
        string GetCorpToken(string suiteId, string authCorpId, string permanentCode,
           string suiteAccessToken);
        /// <summary>
        /// 第三方获取授权方的access_token。
        /// 先从本地缓存获取，没有则从微信端获取。
        /// </summary>
        /// <param name="manager"></param>
        /// <param name="suiteId"></param>
        /// <param name="authCorpId">授权的企业号ID</param>
        /// <param name="permanentCode">永久授权码</param>
        /// <param name="suiteAccessToken"></param>
        /// <returns></returns>
        string GetCorpToken(string suiteId, string authCorpId, string permanentCode,
            string suiteAccessToken, out string errMessage);
    }
}
