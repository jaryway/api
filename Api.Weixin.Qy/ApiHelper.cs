using System;
using Api.Core.Helpers;
using System.IO;
using Api.Core;

namespace Api.Weixin.Qy
{
    /// <summary>
    /// 
    /// </summary>
    public partial class ApiHelper
    {
        #region Private fields
        private static volatile ApiHelper _instance = null;
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
        public static ApiHelper Instance()
        {
            if (_instance == null)
            {
                lock (lockObject)
                {
                    if (_instance == null)
                    {
                        _instance = new ApiHelper();
                    }
                }
            }
            return _instance;
        }
        private ApiHelper() { }
        #endregion

        #region 获取AccessToken
        /// <summary>
        /// 获取AccessToken
        /// </summary>
        /// <param name="corpid"></param>
        /// <param name="corpsecret"></param>
        /// <returns></returns>
        public GetAccessTokenResult GetAccessToken(string corpid, string corpsecret)
        {
            string url = string.Format("{0}gettoken?corpid={1}&corpsecret={2}", baseUrl, corpid, corpsecret);
            var access_token = string.Empty;
            return HttpHelper.HttpGet.GetJsonResult<GetAccessTokenResult>(url);
        }

        #endregion

        #region 管理企业号应用

        /// <summary>
        /// 获取企业号应用
        /// 用于获取企业号某个应用的基本信息，包括头像、昵称、帐号类型、认证类型、可见范围等信息
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="agentid"></param>
        /// <returns></returns>
        public GetAgentResult GetAgent(string access_token, int agentid)
        {
            string url = string.Format("{0}agent/get?access_token={1}&agentid={2}", baseUrl, access_token, agentid);
            return HttpHelper.Get<GetAgentResult>(url);
        }


        /// <summary>
        /// 设置企业号应用
        /// 该API用于设置企业应用的选项设置信息，如：地理位置上报等。第三方服务商不能调用该接口设置授权的主页型应用。
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public JsonResult SetAgent(string access_token, SetAgentRequest request)
        {
            string url = string.Format("{0}agent/set?access_token={1}", baseUrl, access_token);
            return HttpHelper.Send<SetAgentRequest, JsonResult>(url, request);
        }

        /// <summary>
        /// 获取应用概况列表
        /// </summary>
        /// <remarks>该API 用于获取secret所在管理组内的应用概况，会返回管理组内应用的id及名称、头像等信息</remarks>
        /// <param name="access_token"></param>
        /// <returns></returns>
        public static GetAgentListResult GetAgentList(string access_token)
        {
            string url = string.Format("{0}agent/list?access_token={1}", baseUrl, access_token);
            return HttpHelper.Get<GetAgentListResult>(url);
        }
        #endregion

        #region 部门管理
        /// <summary>
        /// 创建部门
        /// </summary>
        /// <param name="request"></param>
        /// <param name="access_token"></param>
        /// <returns></returns>
        public CreateDepartmentResult CreateDepartment(string access_token, CreateDepartmentRequest request)
        {
            string url = string.Format("{0}department/create?access_token={1}", baseUrl, access_token);
            return HttpHelper.HttpPost.GetJsonResult<CreateDepartmentRequest, CreateDepartmentResult>(url, request);
        }

        /// <summary>
        /// 更新部门
        /// </summary>
        /// <param name="request"></param>
        /// <param name="access_token"></param>
        /// <returns></returns>
        public JsonResult UpdateDepartment(string access_token, CreateDepartmentRequest request)
        {
            string url = string.Format("{0}department/update?access_token={1}", baseUrl, access_token);
            var result = HttpHelper.HttpPost.GetJsonResult<CreateDepartmentRequest, JsonResult>(url, request);
            return result;
        }

        /// <summary>
        /// 删除部门
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public JsonResult DeleteDepartment(string access_token, string id)
        {
            string url = string.Format("{0}department/delete?access_token={1}&id={2}", baseUrl, access_token, id);
            return HttpHelper.HttpGet.GetJsonResult<JsonResult>(url);
        }

        /// <summary>
        /// 获取部门列表
        /// </summary>
        /// <param name="access_token">access_token</param>
        public GetDepartmentResult GetDepartmentList(string access_token)
        {
            string url = string.Format("{0}department/list?access_token={1}", baseUrl, access_token);
            return HttpHelper.HttpGet.GetJsonResult<GetDepartmentResult>(url);
        }

        /// <summary>
        /// 获取部门列表
        /// </summary>
        /// <param name="access_token">access_token</param>
        /// <param name="id">部门ID。获取指定部门ID下的子部门 </param>
        public GetDepartmentResult GetDepartmentList(string access_token, string id)
        {
            string url = string.Format("{0}department/list?access_token={1}&id={2}", baseUrl, access_token, id);
            return HttpHelper.HttpGet.GetJsonResult<GetDepartmentResult>(url);
        }

        #endregion

        #region 管理成员

        /// <summary>
        /// 创建成员
        /// </summary>
        /// <param name="request">要添加的用户信息</param>
        /// <param name="access_token">调用接口凭证</param>
        /// <returns></returns>
        public JsonResult CreateUser(string access_token, CreateUserRequest request)
        {
            string url = string.Format("{0}user/create?access_token={1}", baseUrl, access_token);
            return HttpHelper.HttpPost.GetJsonResult<CreateUserRequest, JsonResult>(url, request);
        }

        /// <summary>
        /// 更新成员
        /// </summary>
        /// <param name="request"></param>
        /// <param name="access_token"></param>
        /// <returns></returns>
        public JsonResult UpdateUser(string access_token, UpdateUserRequest request)
        {
            string url = string.Format("{0}user/update?access_token={1}", baseUrl, access_token);
            return HttpHelper.HttpPost.GetJsonResult<UpdateUserRequest, JsonResult>(url, request);
        }

        /// <summary>
        /// 删除成员
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public JsonResult DeleteUser(string access_token, string userId)
        {
            string url = string.Format("{0}user/delete?access_token={1}&userid={2}", baseUrl, access_token, userId);
            return HttpHelper.HttpGet.GetJsonResult<JsonResult>(url);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="userid"></param>
        /// <returns></returns>
        public GetUserResult GetUser(string access_token, string userid)
        {
            string url = string.Format("{0}user/get?access_token={1}&userid={2}", baseUrl, access_token, userid);
            return HttpHelper.HttpGet.GetJsonResult<GetUserResult>(url);
        }

        /// <summary>
        /// 获取部门成员
        /// </summary>
        /// <param name="access_token">调用接口凭证</param>
        /// <param name="deptId">获取的部门id </param>
        /// <param name="fetchChild">1/0：是否递归获取子部门下面的成员 </param>
        /// <param name="status">0获取全部员工，1获取已关注成员列表，2获取禁用成员列表，4获取未关注成员列表。status可叠加</param>
        /// <returns></returns>
        public GetUserSimpleListResult GetUserSimpleList(string access_token, int deptId, bool fetchChild, int status = 1)
        {
            string url = string.Format("{0}user/simplelist?access_token={1}&department_id={2}&fetch_child={3}&status={4}", baseUrl, access_token, deptId, fetchChild ? 1 : 0, status);
            return HttpHelper.HttpGet.GetJsonResult<GetUserSimpleListResult>(url);
        }
        /// <summary>
        /// 获取部门成员
        /// </summary>
        /// <param name="access_token">调用接口凭证</param>
        /// <param name="deptId">获取的部门id </param>
        /// <param name="fetchChild">1/0：是否递归获取子部门下面的成员 </param>
        /// <param name="status">0获取全部员工，1获取已关注成员列表，2获取禁用成员列表，4获取未关注成员列表。status可叠加</param>
        /// <returns></returns>
        public GetUserListResult GetUserList(string access_token, int deptId, bool fetchChild, int status)
        {
            string url = string.Format("{0}user/list?access_token={1}&department_id={2}&fetch_child={3}&status={4}", baseUrl, access_token, deptId, fetchChild ? 1 : 0, status);
            return HttpHelper.HttpGet.GetJsonResult<GetUserListResult>(url);
        }

        /// <summary>
        /// 根据userid 获取openid
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="userId"></param>
        /// <param name="agentId"></param>
        /// <returns></returns>
        public ConvertUserIdToOpenIdResult ConvertUserIdToOpenId(string access_token, string userId, int agentId)
        {
            string url = string.Format("{0}user/convert_openid?access_token={1}&userid={2}&agentid={3}", baseUrl, access_token, userId, agentId);
            return HttpHelper.HttpGet.GetJsonResult<ConvertUserIdToOpenIdResult>(url);
        }
        /// <summary>
        /// 根据openid获取userid
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="openId"></param>
        /// <param name="agentId"></param>
        /// <returns></returns>
        public ConvertOpenIdToUserIdResult ConvertOpenIdToUserId(string access_token, string openId, int agentId)
        {
            string url = string.Format("{0}user/convert_openid?access_token={1}&openid={2}&agentid={3}", baseUrl, access_token, openId, agentId);
            return HttpHelper.HttpGet.GetJsonResult<ConvertOpenIdToUserIdResult>(url);
        }

        #endregion

        #region 管理标签

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tagId"></param>
        /// <param name="tagname"></param>
        /// <param name="access_token"></param>
        /// <returns></returns>
        public CreateTagResult CreateTag(string access_token, int tagId, string tagname)
        {
            var tag = new CreateTagRequest { tagid = tagId, tagname = tagname };
            return CreateTag(access_token, tag);
        }

        /// <summary>
        /// 创建标签
        /// </summary>
        /// <param name="tag"></param>
        /// <param name="access_token"></param>
        /// <returns></returns>
        public CreateTagResult CreateTag(string access_token, CreateTagRequest tag)
        {
            string url = string.Format("{0}tag/create?access_token={1}", baseUrl, access_token);
            return HttpHelper.HttpPost.GetJsonResult<CreateTagRequest, CreateTagResult>(url, tag);
        }


        /// <summary>
        /// 更新标签名字
        /// </summary>
        /// <param name="request"></param>
        /// <param name="access_token"></param>
        /// <returns></returns>
        public JsonResult UpdateTag(string access_token, UploadTagRequest request)
        {
            string url = string.Format("{0}tag/update?access_token={1}", baseUrl, access_token);
            return HttpHelper.HttpPost.GetJsonResult<UploadTagRequest, JsonResult>(url, request);
        }

        /// <summary>
        /// 删除标签
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="tagid"></param>
        /// <returns></returns>
        public JsonResult DeleteTag(string access_token, int tagid)
        {
            string url = string.Format("{0}tag/delete?access_token={1}&tagid={2}", baseUrl, access_token, tagid);
            return HttpHelper.HttpGet.GetJsonResult<JsonResult>(url);
        }

        /// <summary>
        /// 获取标签成员
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="tagId"></param>
        /// <returns></returns>
        public GetTagUserResult GetTagUser(string access_token, int tagId)
        {
            string url = string.Format("{0}tag/get?access_token={1}&tagid={2}", baseUrl, access_token, tagId);
            return HttpHelper.HttpGet.GetJsonResult<GetTagUserResult>(url);
        }

        /// <summary>
        /// 增加标签成员
        /// </summary>
        /// <param name="request"></param>
        /// <param name="access_token"></param>
        /// <returns></returns>
        public AddTagMembersResult AddTagUsers(string access_token, AddTagMembersRequest request)
        {
            string url = string.Format("{0}tag/addtagusers?access_token={1}", baseUrl, access_token);
            return HttpHelper.HttpPost.GetJsonResult<AddTagMembersRequest, AddTagMembersResult>(url, request);
        }

        /// <summary>
        /// 删除标签成员
        /// </summary>
        /// <param name="request"></param>
        /// <param name="access_token"></param>
        /// <returns></returns>
        public DeleteTagUsersResult DeleteTagUsers(string access_token, AddTagMembersRequest request)
        {
            string url = string.Format("{0}tag/deltagusers?access_token={1}", baseUrl, access_token);
            return HttpHelper.HttpPost.GetJsonResult<AddTagMembersRequest, DeleteTagUsersResult>(url, request);
        }

        #endregion

        #region 管理多媒体文件

        /// <summary>
        /// 上传多媒体文件
        /// </summary>
        /// <param name="media"></param>
        /// <param name="access_token"></param>
        /// <returns></returns>
        public UploadMediaResult UploadMedia(string access_token, UploadMediaRequest media)
        {
            string url = string.Format("{0}media/upload?access_token={1}&type={2}", baseUrl, access_token, media.GetMediaType());
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
            string url = string.Format("{0}media/get?access_token={1}&media_id={2}", baseUrl, access_token, media_id);
            var data = HttpHelper.HttpGet.GetResult(url);
            GetMediaResult result = JsonHelper.Decode<GetMediaResult>(data.Content);
            result.Stream = data.Stream;
            return result;
        }

        #endregion

        #region 发送消息

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="message"></param>
        /// <param name="access_token"></param>
        /// <returns></returns>
        public SendMessageResult SendMessage(string access_token, SendMessageRequest message)
        {
            string url = string.Format("{0}message/send?access_token={1}", baseUrl, access_token);
            return HttpHelper.HttpPost.GetJsonResult<SendMessageRequest, SendMessageResult>(url, message);
        }

        #endregion

        #region 生成自定义菜单

        /// <summary>
        /// 生成自定义菜单
        /// </summary>
        /// <param name="menuJsonData"></param>
        /// <param name="access_token"></param>
        /// <param name="agentId"></param>
        /// <returns></returns>
        public JsonResult CreateCustomMenu(string access_token, int agentId, string menuJsonData)
        {
            string url = string.Format("{0}menu/create?access_token={1}&agentid={2}", baseUrl, access_token, agentId);
            var result = HttpHelper.HttpPost.GetResult(url, menuJsonData);
            return JsonHelper.Decode<JsonResult>(result);
        }

        /// <summary>
        /// 删除自定义菜单
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="agentid"></param>
        /// <returns></returns>
        public JsonResult DeleteCustomMenu(string access_token, int agentid)
        {
            string url = string.Format("{0}menu/delete?access_token={1}&agentid={2}", baseUrl, access_token, agentid);
            return HttpHelper.HttpGet.GetJsonResult<JsonResult>(url);
        }

        /// <summary>
        /// 获取自定义菜单
        /// </summary>
        /// <param name="fullFilePath"></param>
        /// <param name="access_token"></param>
        /// <param name="agentid"></param>
        public void GetCustomMenu(string access_token, int agentid, string fullFilePath)
        {
            string url = string.Format("{0}menu/get?access_token={1}&agentid={2}", baseUrl, access_token, agentid);
            if (!System.IO.File.Exists(fullFilePath))
                throw new FileNotFoundException(string.Format("文件{0}不存在！", fullFilePath));

            StreamWriter writer = new StreamWriter(fullFilePath);
            try
            {
                var result = HttpHelper.HttpGet.GetResult(url);
                writer.Write(result.Content);
                writer.Flush();
            }
            catch (Exception) { throw; }
            finally
            { writer.Dispose(); }

        }

        /// <summary>
        /// 获取自定义菜单
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="agentId"></param>
        /// <returns></returns>
        public string GetCustomMenu(string access_token, int agentId)
        {
            string url = string.Format("{0}menu/get?access_token={1}&agentid={2}", baseUrl, access_token, agentId);
            var result = HttpHelper.HttpGet.GetResult(url);
            return result.Content;
        }

        #endregion

        #region OAuth2验证

        /// <summary>
        /// OAuth2验证验证得到code后，在根据code或用户信息
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="code">code</param>
        /// <param name="agentId">agentId应用ID</param>
        /// <returns></returns>
        public OAuthGetUserInfoResult OAuthGetUserInfo(string access_token, string code, int agentId)
        {
            string url = string.Format("{0}user/getuserinfo?access_token={1}&code={2}&agentid={3}", baseUrl, access_token, code, agentId);
            return HttpHelper.HttpGet.GetJsonResult<OAuthGetUserInfoResult>(url);
        }

        #endregion

        #region jsapi
        /// <summary>
        /// 获取jsapi_ticket
        /// </summary>
        /// <param name="access_token"></param>
        /// <returns></returns>
        public GetJsapiTicketResult GetJsapiTicket(string access_token)
        {
            string url = string.Format("{0}get_jsapi_ticket?access_token={1}", baseUrl, access_token);
            return HttpHelper.HttpGet.GetJsonResult<GetJsapiTicketResult>(url);
        }
        #endregion

        #region 企业号登录授权
        /// <summary>
        /// 获取应用提供商凭证
        /// </summary>
        /// <param name="corpid">企业号（提供商）的corpid </param>
        /// <param name="provider_secret">提供商的secret，在提供商管理页面可见</param>
        /// <returns></returns>
        public GetProviderTokenResult GetProviderToken(string corpid, string provider_secret)
        {
            string url = string.Format("{0}service/get_provider_token", baseUrl);
            return HttpHelper.HttpPost.GetJsonResult<dynamic, GetProviderTokenResult>(url, new { corpid = corpid, provider_secret = provider_secret });
        }

        /// <summary>
        /// 获取企业号管理员登录信息
        /// </summary>
        /// <param name="provider_access_token">服务提供商的accesstoken </param>
        /// <param name="auth_code">oauth2.0授权企业号管理员登录产生的code </param>
        /// <returns></returns>
        public GetLoginInfoResult GetLoginInfo(string provider_access_token, string auth_code)
        {
            string url = string.Format("{0}service/get_login_info?provider_access_token={1}", baseUrl, provider_access_token);
            return HttpHelper.HttpPost.GetJsonResult<dynamic, GetLoginInfoResult>(url, new { auth_code = auth_code });
        }

        #endregion
    }
}
