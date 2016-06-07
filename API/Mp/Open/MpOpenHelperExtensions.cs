using API.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API.Mp.Open
{
    /// <summary>
    /// 
    /// </summary>
    public static class MpOpenHelperExtensions
    {
        private const string baseurl = "https://api.weixin.qq.com/";

        /// <summary>
        /// 通过code换取网页授权access_token
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="appId"></param>
        /// <param name="appSecret"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public static GetSNSAccessTokenResult GetSNSAccessToken(this MpHelper helper, string appId, string appSecret, string code)
        {
            string url = string.Format("{0}sns/oauth2/access_token?appid={1}&secret={2}&code={3}&grant_type=authorization_code", baseurl, appId, appSecret, code);
            return HttpHelper.HttpGet.GetJsonResult<GetSNSAccessTokenResult>(url);
        }
        /// <summary>
        /// 刷新access_token（如果需要）
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="appid"></param>
        /// <param name="refresh_token"></param>
        /// <returns></returns>
        public static RefreshSNSAccessTokenResult RefreshSNSAccessToken(this MpHelper helper, string appid, string refresh_token)
        {
            string url = string.Format("{0}sns/oauth2/refresh_token?appid={1}&grant_type=refresh_token&refresh_token={2}", baseurl, appid, refresh_token);
            return HttpHelper.HttpGet.GetJsonResult<RefreshSNSAccessTokenResult>(url);
        }
        /// <summary>
        /// 拉取用户信息(需scope为 snsapi_userinfo)
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="access_token"></param>
        /// <param name="openId"></param>
        /// <returns></returns>
        public static GetUserInfoResult GetSNSUserInfo(this MpHelper helper, string access_token, string openId)
        {
            string url = string.Format("{0}sns/userinfo?access_token={1}&openid={2}", baseurl, access_token, openId);
            return HttpHelper.HttpGet.GetJsonResult<GetUserInfoResult>(url);
        }
        /// <summary>
        /// 1、获取第三方平台access_token
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="component_appid">第三方平台appid</param>
        /// <param name="component_appsecret">第三方平台appsecret</param>
        /// <param name="verify_ticket">微信后台推送的ticket，此ticket会定时推送，具体请见本页末尾的推送说明</param>
        /// <returns></returns>
        public static GetComponentAccessTokenResult GetComponentAccessToken(this MpHelper helper, string component_appid, string component_appsecret, string verify_ticket)
        {
            string url = string.Format("{0}cgi-bin/component/api_component_token", baseurl);
            return HttpHelper.HttpPost.GetJsonResult<dynamic, GetComponentAccessTokenResult>(url,
                new
                {
                    component_appid = component_appid,
                    component_appsecret = component_appsecret,
                    verify_ticket = verify_ticket
                });
        }
        /// <summary>
        /// 2、获取预授权码
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="component_access_token"></param>
        /// <param name="component_appid">第三方平台appid</param>
        /// <returns></returns>
        public static GetComponentPreAuthCodeResult GetComponentPreAuthCode(this MpHelper helper, string component_access_token, string component_appid)
        {
            string url = string.Format("{0}cgi-bin/component/api_create_preauthcode?component_access_token={1}", baseurl, component_access_token);
            return HttpHelper.HttpPost.GetJsonResult<dynamic, GetComponentPreAuthCodeResult>(url, new { component_appid = component_appid });
        }
        /// <summary>
        /// 3、使用授权码换取公众号的授权信息
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="component_access_token"></param>
        /// <param name="component_appid">第三方平台appid</param>
        /// <param name="authorization_code">授权code,会在授权成功时返回给第三方平台，详见第三方平台授权流程说明</param>
        /// <returns></returns>
        public static QueryComponentAuthResult QueryComponentAuth(this MpHelper helper, string component_access_token, string component_appid, string authorization_code)
        {
            string url = string.Format("{0}cgi-bin/component/api_query_auth?component_access_token={1}", baseurl, component_access_token);
            return HttpHelper.HttpPost.GetJsonResult<dynamic, QueryComponentAuthResult>(url, new { component_appid = component_appid, authorization_code = authorization_code });
        }
        /// <summary>
        /// 4、获取（刷新）授权公众号的令牌
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="component_access_token"></param>
        /// <param name="component_appid">第三方平台appid</param>
        /// <param name="authorizer_appid">授权方appid</param>
        /// <param name="authorizer_refresh_token">授权方的刷新令牌，刷新令牌主要用于公众号第三方平台获取和刷新已授权用户的access_token，只会在授权时刻提供，请妥善保存。 一旦丢失，只能让用户重新授权，才能再次拿到新的刷新令牌</param>
        /// <returns></returns>
        public static RefreshAuthorizerTokenResult RefreshAuthorizerToken(this MpHelper helper, string component_access_token,
            string component_appid, string authorizer_appid, string authorizer_refresh_token)
        {
            string url = string.Format("{0}cgi-bin/component/api_authorizer_token?component_access_token={1}", baseurl, component_access_token);
            return HttpHelper.HttpPost.GetJsonResult<dynamic, RefreshAuthorizerTokenResult>(url,
                new
                {
                    component_appid = component_appid,
                    authorizer_appid = authorizer_appid,
                    authorizer_refresh_token = authorizer_refresh_token
                });
        }

        /// <summary>
        /// 5、获取授权方信息
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="component_access_token"></param>
        /// <param name="component_appid">服务appid</param>
        /// <param name="authorizer_appid">授权方appid</param>
        /// <returns></returns>
        public static GetAuthorizerInfoResult GetAuthorizerInfo(this MpHelper helper, string component_access_token,
                string component_appid, string authorizer_appid)
        {
            string url = string.Format("{0}cgi-bin/component/api_authorizer_token?component_access_token={1}", baseurl, component_access_token);
            return HttpHelper.HttpPost.GetJsonResult<dynamic, GetAuthorizerInfoResult>(url,
                new
                {
                    component_appid = component_appid,
                    authorizer_appid = authorizer_appid,

                });
        }

        /// <summary>
        /// 6、获取授权方的选项设置信息
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="component_access_token"></param>
        /// <param name="component_appid">第三方平台appid</param>
        /// <param name="authorizer_appid">授权公众号appid</param>
        /// <param name="option_name">选项名称</param>
        /// <returns></returns>
        public static GetAuthorizerOptionResult GetAuthorizerOption(this MpHelper helper, string component_access_token,
                string component_appid, string authorizer_appid, string option_name)
        {
            string url = string.Format("{0}cgi-bin/component/api_get_authorizer_option?component_access_token={1}", baseurl, component_access_token);
            return HttpHelper.HttpPost.GetJsonResult<dynamic, GetAuthorizerOptionResult>(url,
                new
                {
                    component_appid = component_appid,
                    authorizer_appid = authorizer_appid,
                    option_name = option_name
                });
        }

        /// <summary>
        /// 7、设置授权方的选项信息
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="component_access_token"></param>
        /// <param name="component_appid">第三方平台appid</param>
        /// <param name="authorizer_appid">授权公众号appid</param>
        /// <param name="option_name">选项名称</param>
        /// <returns></returns>
        public static MpResult SetAuthorizerOption(this MpHelper helper, string component_access_token,
                string component_appid, string authorizer_appid, string option_name)
        {
            string url = string.Format("{0}cgi-bin/component/api_set_authorizer_option?component_access_token={1}", baseurl, component_access_token);
            return HttpHelper.Send<dynamic, MpResult>(url, new { component_appid = component_appid, authorizer_appid = authorizer_appid, option_name = option_name });
        }
    }
}
