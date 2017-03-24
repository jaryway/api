using Api.Core;
using Api.Core.Helpers;

namespace Api.Weixin.Qy.ThirdAuth
{
    /// <summary>
    /// 针对微信第三方授权扩展IQyHelper
    /// </summary>
    public static class ThirdAuthApiHelperExtensions
    {
        const string baseUrl = "https://qyapi.weixin.qq.com/cgi-bin/";
        /// <summary>
        /// 获取应用套件令牌
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="suite_id"></param>
        /// <param name="suite_secret"></param>
        /// <param name="suite_ticket"></param>
        /// <returns></returns>
        public static GetSuiteTokenResult GetSuiteToken(this ApiHelper helper, string suite_id, string suite_secret, string suite_ticket)
        {
            GetSuiteTokenRequest request = new GetSuiteTokenRequest();
            request.suite_id = suite_id;
            request.suite_secret = suite_secret;
            request.suite_ticket = suite_ticket;
            return helper.GetSuiteToken(request);
        }

        /// <summary>
        /// 获取应用套件令牌
        /// 该Api.Weixin用于获取应用套件令牌（suite_access_token）。
        /// 注1：由于应用提供商可能托管了大量的企业号，其安全问题造成的影响会更加严重，故Api.Weixin中除了合法来源IP校验之外，还额外增加了1项安全策略：
        /// 获取suite_access_token时，还额外需要suite_ticket参数（请永远使用最新接收到的suite_ticket）。suite_ticket由企业号后台定时推送给应用套件，并定时更新。
        /// 注2：通过本接口获取的accesstoken不会自动续期，每次获取都会自动更新。
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public static GetSuiteTokenResult GetSuiteToken(this ApiHelper helper, GetSuiteTokenRequest request)
        {
            string url = string.Format("{0}service/get_suite_token", baseUrl);
            return HttpHelper.HttpPost.GetJsonResult<GetSuiteTokenRequest, GetSuiteTokenResult>(url, request);
        }
        /// <summary>
        /// 获取预授权码
        /// 该Api.Weixin用于获取预授权码。预授权码用于企业号授权时的应用提供商安全验证。
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="request"></param>
        /// <param name="suite_access_token"></param>
        /// <returns></returns>
        public static GetPreAuthCodeResult GetPreAuthCode(this ApiHelper helper, string suite_access_token, GetPreAuthCodeReqeust request)
        {
            string url = string.Format("{0}service/get_pre_auth_code?suite_access_token={1}", baseUrl, suite_access_token);
            return HttpHelper.HttpPost.GetJsonResult<GetPreAuthCodeReqeust, GetPreAuthCodeResult>(url, request);
        }
        /// <summary>
        /// 获取企业号的永久授权码
        /// 该Api.Weixin用于使用临时授权码换取授权方的永久授权码，并换取授权信息、企业access_token。
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="suite_id"></param>
        /// <param name="auth_code"></param>
        /// <param name="suite_access_token"></param>
        /// <returns></returns>
        public static GetPermanentCodeResult GetPermanentCode(this ApiHelper helper, string suite_id, string auth_code, string suite_access_token)
        {
            var request = new GetPermanentCodeRequest { suite_id = suite_id, auth_code = auth_code };
            return helper.GetPermanentCode(suite_access_token, request);
        }
        /// <summary>
        /// 获取企业号的永久授权码
        /// 该API用于使用临时授权码换取授权方的永久授权码，并换取授权信息、企业access_token。
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="request"></param>
        /// <param name="suite_access_token"></param>
        /// <returns></returns>
        public static GetPermanentCodeResult GetPermanentCode(this ApiHelper helper, string suite_access_token, GetPermanentCodeRequest request)
        {
            string url = string.Format("{0}service/get_permanent_code?suite_access_token={1}", baseUrl, suite_access_token);
            return HttpHelper.HttpPost.GetJsonResult<GetPermanentCodeRequest, GetPermanentCodeResult>(url, request);
        }

        /// <summary>
        /// 获取企业号的授权信息
        /// 该API用于通过永久授权码换取企业号的授权信息。 永久code的获取，是通过临时授权码使用get_permanent_code 接口获取到的permanent_code。
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="request"></param>
        /// <param name="suite_access_token"></param>
        /// <returns></returns>
        public static GetAuthInfoResult GetAuthInfo(this ApiHelper helper, string suite_access_token, GetAuthInfoRequest request)
        {
            string url = string.Format("{0}service/get_auth_info?suite_access_token={1}", baseUrl, suite_access_token);
            return HttpHelper.HttpPost.GetJsonResult<GetAuthInfoRequest, GetAuthInfoResult>(url, request);
        }

        /// <summary>
        /// 通讯录同步,注意：目前此接口仅支持第三方开发商
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="access_token"></param>
        /// <param name="seq">变更序号，递增32位整型值，表示某次通讯录变更，填上一请求返回的next_seq,seq和offset均填0，表示全量拉取</param>
        /// <param name="offset">变更序号偏移量，填上一请求返回的next_offset</param>
        /// <returns></returns>
        public static SyncGetPageResult SyncGetPage(this ApiHelper helper, string access_token, int seq, int offset)
        {
            string url = string.Format("{0}sync/getpage?access_token={1}", baseUrl, access_token);
            return HttpHelper.HttpPost.GetJsonResult<dynamic, SyncGetPageResult>(url, new { seq = seq, offset = offset });
        }

        /* 2016.06.03 service/set_agent 以及 service/get_agent 接口下线。 by wzx
        /// <summary>
        /// 获取企业号应用
        /// 该API用于获取授权方的企业号某个应用的基本信息，包括头像、昵称、帐号类型、认证类型、可见范围等信息
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="suite_id">套件ID</param>
        /// <param name="auth_corpid">授权方企业ID</param>
        /// <param name="permanent_code">永久授权码</param>
        /// <param name="agentid">授权方应用ID</param>
        /// <param name="suite_access_token"></param>
        /// <returns></returns>
        public static GetAgentResult GetAgent(this ApiHelper helper, string suite_id, string auth_corpid, string permanent_code,
            string agentid, string suite_access_token)
        {
            var request = new GetAgentRequest();
            request.suite_id = suite_id;
            request.auth_corpid = auth_corpid;
            request.permanent_code = permanent_code;
            request.agentid = agentid;
            return helper.GetAgent(suite_access_token, request);
        }
        /// <summary>
        /// 获取企业号应用
        /// 该API用于获取授权方的企业号某个应用的基本信息，包括头像、昵称、帐号类型、认证类型、可见范围等信息
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="request"></param>
        /// <param name="suite_access_token"></param>
        /// <returns></returns>
        public static GetAgentResult GetAgent(this ApiHelper helper, string suite_access_token, GetAgentRequest request)
        {
            string url = string.Format("{0}service/get_agent?suite_access_token={1}", baseUrl, suite_access_token);
            return HttpHelper.HttpPost.GetJsonResult<GetAgentRequest, GetAgentResult>(url, request);
        }
        /// <summary>
        /// 设置企业号应用
        /// 该API用于设置授权方的企业应用的选项设置信息，如：地理位置上报等。注意，获取各项选项设置信息，需要有授权方的授权。
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="request"></param>
        /// <param name="suite_access_token"></param>
        /// <returns></returns>
        public static SetAgentResult SetAgent(this ApiHelper helper, string suite_access_token, SetAgentRequest request)
        {
            string url = string.Format("{0}service/set_agent?suite_access_token={1}", baseUrl, suite_access_token);
            return HttpHelper.HttpPost.GetJsonResult<SetAgentRequest, SetAgentResult>(url, request);
        }*/
        /// <summary>
        /// 获取企业号access_token
        /// 应用提供商在取得企业号的永久授权码并完成对企业号应用的设置之后，便可以开始通过调用企业接口（详见企业接口文档）来运营这些应用。
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="request"></param>
        /// <param name="suite_access_token"></param>
        /// <returns></returns>
        public static GetCorpTokenResult GetCorpToken(this ApiHelper helper, string suite_access_token, GetCorpTokenRequest request)
        {
            string url = string.Format("{0}service/get_corp_token?suite_access_token={1}", baseUrl, suite_access_token);
            return HttpHelper.HttpPost.GetJsonResult<GetCorpTokenRequest, GetCorpTokenResult>(url, request);
        }

        /// <summary>
        /// 设置授权配置
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="suite_access_token"></param>
        /// <param name="pre_auth_code">预授权码</param>
        /// <param name="auth_type">授权类型：0 正式授权， 1 测试授权， 默认值为0</param>
        /// <param name="appid">允许进行授权的应用id，如1、2、3， 不填或者填空数组都表示允许授权套件内所有应用</param>
        /// <returns></returns>
        public static JsonResult SetSessionInfo(this ApiHelper helper, string suite_access_token, string pre_auth_code, int[] appid, int auth_type = 0)
        {
            string url = string.Format("{0}service/set_session_info?suite_access_token={1}", baseUrl, suite_access_token);
            return HttpHelper.HttpPost.GetJsonResult<dynamic, JsonResult>(url, new { pre_auth_code = pre_auth_code, session_info = new { appid = appid, auth_type = auth_type } });
        }
    }

}
