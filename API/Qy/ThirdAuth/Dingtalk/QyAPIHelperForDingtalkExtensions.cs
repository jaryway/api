using API.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API.Qy.ThirdAuth.Dingtalk
{
    /// <summary>
    /// 对IQyHelper扩展以便
    /// </summary>
    public static class QyAPIHelperForDingtalkExtensions
    {
        /// <summary>
        /// 获取套件访问Token（suite_access_token）
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="suite_access_token"></param>
        /// <param name="tmp_auth_code"></param>
        /// <returns></returns>
        public static GetSuiteTokenResult DtGetSuiteToken(this IQyHelper helper, string suite_key, string suite_secret, string suite_ticket)
        {
            string url = string.Format("https://oapi.dingtalk.com/service/get_suite_token");
            return HttpHelper.Send<dynamic, GetSuiteTokenResult>(url, new { suite_key = suite_key, suite_secret = suite_secret, suite_ticket = suite_ticket });
        }

        /// <summary>
        /// 获取企业的永久授权码
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="suite_access_token"></param>
        /// <param name="tmp_auth_code"></param>
        /// <returns></returns>
        public static DtGetPermanentCodeResult DtGetPermanentCode(this IQyHelper helper, string suite_access_token, string tmp_auth_code)
        {
            string url = string.Format("https://oapi.dingtalk.com/service/get_permanent_code?suite_access_token={0}", suite_access_token);
            return HttpHelper.Send<dynamic, DtGetPermanentCodeResult>(url, new { tmp_auth_code = tmp_auth_code });
        }

        /// <summary>
        /// 获取企业授权的access_token
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="suite_access_token"></param>
        /// <param name="auth_corpid"></param>
        /// <param name="permanent_code"></param>
        /// <returns></returns>
        public static DtGetCorpTokenResult DtGetCorpToken(this IQyHelper helper, string suite_access_token, string auth_corpid, string permanent_code)
        {
            string url = string.Format("https://oapi.dingtalk.com/service/get_corp_token?suite_access_token={0}", suite_access_token);
            return HttpHelper.Send<dynamic, DtGetCorpTokenResult>(url, new { auth_corpid = auth_corpid, permanent_code = permanent_code });
        }
        /// <summary>
        /// 获取企业授权的授权数据
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="suite_access_token"></param>
        /// <param name="suite_key"></param>
        /// <param name="auth_corpid"></param>
        /// <param name="permanent_code"></param>
        /// <returns></returns>
        public static DtGetAuthInfoResult DtGetAuthInfo(this IQyHelper helper, string suite_access_token, string suite_key, string auth_corpid, string permanent_code)
        {
            string url = string.Format("https://oapi.dingtalk.com/service/get_auth_info?suite_access_token={0}", suite_access_token);
            return HttpHelper.Send<dynamic, DtGetAuthInfoResult>(url, new { suite_key = suite_key, auth_corpid = auth_corpid, permanent_code = permanent_code });
        }
        /// <summary>
        /// 获取企业的应用信息
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="suite_access_token"></param>
        /// <param name="suite_key"></param>
        /// <param name="auth_corpid"></param>
        /// <param name="permanent_code"></param>
        /// <param name="agentid"></param>
        /// <returns></returns>
        public static DtGetAgentResult DtGetAgent(this IQyHelper helper, string suite_access_token, string suite_key, string auth_corpid, string permanent_code, int agentid)
        {
            string url = string.Format("https://oapi.dingtalk.com/service/get_agent?suite_access_token={0}", suite_access_token);
            return HttpHelper.Send<dynamic, DtGetAgentResult>(url, new { suite_key = suite_key, auth_corpid = auth_corpid, permanent_code = permanent_code, agentid = agentid });
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="suite_access_token"></param>
        /// <param name="suite_key"></param>
        /// <param name="auth_corpid"></param>
        /// <param name="permanent_code"></param>
        /// <returns></returns>
        public static QyResult DtActivateSuite(this IQyHelper helper, string suite_access_token, string suite_key, string auth_corpid, string permanent_code)
        {
            string url = string.Format("https://oapi.dingtalk.com/service/activate_suite?suite_access_token={0}", suite_access_token);
            return HttpHelper.Send<dynamic, QyResult>(url, new { suite_key = suite_key, auth_corpid = auth_corpid, permanent_code = permanent_code });
        }
    }
    #region Models
    /// <summary>
    /// 
    /// </summary>
    public class DtGetPermanentCodeResult : QyResult
    {
        /// <summary>
        /// 永久授权码
        /// </summary>
        public string permanent_code { get; set; }
        /// <summary>
        /// 授权方企业信息
        /// </summary>
        public DtAuthCorpInfo auth_corp_info { get; set; }
        /// <summary>
        /// 授权方管理员信息
        /// </summary>
        public DtAuthUserInfo auth_user_info { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public class DtGetCorpTokenResult : QyResult
    {
        /// <summary>
        /// 授权方（企业）access_token
        /// </summary>
        public string access_token { get; set; }

        /// <summary>
        /// 授权方（企业）access_token超时时间
        /// </summary>
        public int expires_in { get; set; }
    }
    /// <summary>
    /// 获取企业授权的授权数据
    /// </summary>
    public class DtGetAuthInfoResult : QyResult
    {
        /// <summary>
        /// 授权方企业信息
        /// </summary>
        public DtAuthCorpInfo auth_corp_info { get; set; }
        /// <summary>
        /// 授权方管理员信息
        /// </summary>
        public DtAuthUserInfo auth_user_info { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DtAuthInfo auth_info { get; set; }

    }
    /// <summary>
    /// 获取企业的应用信息
    /// </summary>
    public class DtGetAgentResult : QyResult
    {
        /// <summary>
        /// 授权方企业应用id
        /// </summary>
        public int agentid { get; set; }
        /// <summary>
        /// 授权方企业应用名称
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 授权方企业应用头像
        /// </summary>
        public string logo_url { get; set; }
        /// <summary>
        /// 授权方企业应用详情
        /// </summary>
        public string description { get; set; }
        /// <summary>
        /// 授权方企业应用是否被禁用（0:禁用 1:正常 2:待激活 ）
        /// </summary>
        public int close { get; set; }
    }
    /// <summary>
    /// 授权方管理员信息
    /// </summary>
    public class DtAuthUserInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public string userId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string mobile { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string name { get; set; }
    }
    /// <summary>
    /// 授权方企业信息
    /// </summary>
    public class DtAuthCorpInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public string corpid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string corp_name { get; set; }
    }
    /// <summary>
    /// 授权信息
    /// </summary>
    public class DtAuthInfo
    {
        /// <summary>
        /// 授权的应用信息
        /// </summary>
        public IList<DtAuthAgent> agent { get; set; }
    }
    /// <summary>
    /// 授权的应用信息
    /// </summary>
    public class DtAuthAgent
    {
        /// <summary>
        /// 
        /// </summary>
        public int appid { get; set; }
        /// <summary>
        /// 授权方应用id
        /// </summary>
        public int agentid { get; set; }
        /// <summary>
        /// 授权方应用名字
        /// </summary>
        public string agent_name { get; set; }
        /// <summary>
        /// 授权方应用头像
        /// </summary>
        public string logo_url { get; set; }
    }
    #endregion
}
