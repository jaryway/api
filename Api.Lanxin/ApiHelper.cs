using Api.Lanxin;
using Api.Lanxin.Helpers;
using Api.Lanxin.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Lanxin
{
    /// <summary>
    ///  
    /// </summary>
    public class ApiHelper
    {
        #region Private fields
        //private static volatile ApiHelper _instance = null;
        //private static readonly object lockObject = new object();
        //private string m_baseurl = System.Configuration.ConfigurationManager.AppSettings["ApiBaseUrl"];
        #endregion
        /// <summary>
        /// 基础URL e.g.: http://ip:端口
        /// </summary>
        public string BaseUrl { get; private set; }

        #region Ctor and Instance
        /// <summary>
        /// 
        /// </summary>
        /// <param name="baseurl"></param>
        public ApiHelper(string baseurl)
        {
            this.BaseUrl = baseurl;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="baseurl"></param>
        /// <returns></returns>
        public static ApiHelper Instance(string baseurl)
        {
            return new ApiHelper(baseurl);
        }

        #endregion

        #region 获取access_token
        /// <summary>
        /// 获取access_token
        /// </summary>
        /// <param name="appid">第三方用户唯一凭证</param>
        /// <param name="appsecret">开发者密钥</param>
        /// <param name="grant_type">获取access_token填写client_credential</param>
        /// <returns></returns>
        public GetAccessTokenResult GetAccessToken(int appid, string appsecret, string grant_type = "client_credential")
        {
            var url = string.Format("{0}/cgi-bin/token?grant_type={1}&appid={2}&secret={3}", BaseUrl, grant_type, appid, appsecret);
            return HttpHelper.Get<GetAccessTokenResult>(url);
        }

        #endregion

        #region 上传下载多媒体文件

        /// <summary>
        /// 上传多媒体文件
        /// </summary>
        /// <param name="media"></param>
        /// <param name="access_token"></param>
        /// <returns></returns>
        public UploadMediaResult UploadMedia(string access_token, UploadMediaRequest media)
        {
            string url = string.Format("{0}/cgi-bin/media/upload?access_token={1}&type={2}", BaseUrl, access_token, media.GetMediaType());
            return JsonHelper.Decode<UploadMediaResult>(HttpHelper.HttpPost.GetMediaResult(url, media.AsPostMedia()));
        }

        /// <summary>
        /// 获取临时素材
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="media_id">媒体ID</param>
        /// <returns></returns>
        public GetMediaResult GetMedia(string access_token, string media_id)
        {
            string url = string.Format("{0}/cgi-bin/media/get?access_token={1}&media_id={2}", BaseUrl, access_token, media_id);
            var data = HttpHelper.HttpGet.GetResult(url);
            GetMediaResult result = JsonHelper.Decode<GetMediaResult>(data.Content);
            result.Stream = data.Stream;
            return result;
        }

        #endregion

        #region 消息接口
        /// <summary>
        /// 发送客服消息
        /// </summary>
        /// <param name="request"></param>
        /// <param name="access_token"></param>
        /// <returns></returns>
        public SendMessageResult SendCustomMessage(string access_token, SendCustomMessageRequest request)
        {
            string url = string.Format("{0}/cgi-bin/message/custom/send?access_token={1}", BaseUrl, access_token);
            return HttpHelper.Send<SendCustomMessageRequest, SendMessageResult>(url, request);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="access_token"></param>
        /// <returns></returns>
        public SendMessageResult SendMassMessage(string access_token, SendMassMessageRequest request)
        {
            string url = string.Format("{0}/cgi-bin/message/mass/send?access_token={1}", BaseUrl, access_token);
            return HttpHelper.Send<SendMassMessageRequest, SendMessageResult>(url, request);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="msgid"></param>
        /// <returns></returns>
        public ControlMessageResult ControlMessage(string access_token, string msgid)
        {
            string url = string.Format("{0}/cgi-bin/message/control?access_token={1}&msgid={2}", BaseUrl, access_token, msgid);
            return HttpHelper.Get<ControlMessageResult>(url);
        }

        #endregion

        #region 组织查询
        /// <summary>
        /// 查询组织成员数据 注：mobile和email填写一个即可，优先取mobile进行查询
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="orgId">组织ID</param>
        /// <param name="mobile">待查询成员手机号</param>
        /// <param name="email">待查询成员email</param>
        /// <returns></returns>
        public GetMemberResult GetMember(string access_token, int orgId, string mobile, string email)
        {
            string url = string.Format("{0}/cgi-bin/member/get?access_token={1}&orgid={2}&mobile={3}&email={4}",
                BaseUrl, access_token, orgId, mobile, email);
            return HttpHelper.Get<GetMemberResult>(url);
        }
        /// <summary>
        /// 分级查询组织数据
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="orgId">组织ID</param>
        /// <param name="structId">分支ID，为0时表示从根节点查询</param>
        /// <param name="queryType">0:分支节点;1:成员节点;-1:全部节点</param>
        /// <returns></returns>
        public GetParentStructResult GetParentStruct(string access_token, int orgId, int structId, int queryType)
        {
            string url = string.Format("{0}/cgi-bin/org/struct/parent/get?access_token={1}&orgid={2}&structid={3}&querytype={4}",
                BaseUrl, access_token, orgId, structId, queryType);
            return HttpHelper.Get<GetParentStructResult>(url);
        }

        #endregion

        #region 自定义菜单接口

        /// <summary>
        /// 创建自定义菜单
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="menuJson"></param>
        /// <returns></returns>
        public JsonResult CreateMenu(string access_token, string menuJson)
        {
            string url = string.Format("{0}/cgi-bin/menu/create?access_token={1}", BaseUrl, access_token);
            var result = HttpHelper.HttpPost.GetResult(url, menuJson);
            return JsonHelper.Decode<JsonResult>(result);
        }

        /// <summary>
        /// 获取自定义菜单
        /// </summary>
        /// <param name="access_token"></param>
        /// <returns></returns>
        public string GetMenu(string access_token)
        {
            string url = string.Format("{0}/cgi-bin/menu/get?access_token={1}", BaseUrl, access_token);
            var result = HttpHelper.HttpGet.GetResult(url);
            return result.Content;
        }

        /// <summary>
        /// 删除自定义菜单
        /// </summary>
        /// <param name="access_token"></param>
        /// <returns></returns>
        public JsonResult DeleteMenu(string access_token)
        {
            string url = string.Format("{0}/cgi-bin/menu/delete?access_token={1}", BaseUrl, access_token);
            var result = HttpHelper.HttpPost.GetResult(url, "");
            return JsonHelper.Decode<JsonResult>(result);
        }

        #endregion

        #region sns OAuth2.0
        /// <summary>
        /// OAuth2.0登录授权
        /// </summary>
        /// <param name="code"></param>
        /// <param name="appid"></param>
        /// <param name="grant_type"></param>
        public GetSnsOAuthAccessTokenResult GetSnsOAuthAccessToken(string code, int appid, string grant_type = "authorization_code")
        {
            var url = string.Format("{0}/sns/oauth2/access_token?code={1}&appid={2}&grant_type={3}", BaseUrl, code, appid, grant_type);
            return HttpHelper.Get<GetSnsOAuthAccessTokenResult>(url);
        }

        /// <summary>
        /// OAuth2.0获取用户信息
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="mobile">用户的唯一标识（openid ）</param>
        /// <returns></returns>
        public GetSnsUserInfoResult GetSnsUserInfo(string access_token, string mobile)
        {
            var url = string.Format("{0}/sns/userinfo?access_token={1}&mobile={2}", BaseUrl, access_token, mobile);
            return HttpHelper.Get<GetSnsUserInfoResult>(url);
        }

        ///// <summary>
        ///// OAuth2.0获取用户信息
        ///// </summary>
        ///// <param name="access_token"></param>
        ///// <param name="mobile">用户的唯一标识（openid ）</param>
        ///// <returns></returns>
        //public GetSnsUserInfoResult GetSnsUserInfo(string access_token, string mobile)
        //{
        //    var url = string.Format("{0}/lop/photo/res/show? access_token=ACCESS_TOKEN", BaseUrl, access_token, mobile);
        //    return HttpHelper.Get<GetSnsUserInfoResult>(url);
        //}
        #endregion

    }
}
