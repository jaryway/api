using API.Helpers;
using API.Qy.ThirdAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Qy
{
    public class DingtalkQyAPIHelper : IQyHelper
    {
        #region Private fields
        private static volatile DingtalkQyAPIHelper _instance = null;
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
        internal static DingtalkQyAPIHelper Instance()
        {
            if (_instance == null)
            {
                lock (lockObject)
                {
                    if (_instance == null)
                    {
                        _instance = new DingtalkQyAPIHelper();
                    }
                }
            }
            return _instance;
        }
        private DingtalkQyAPIHelper() { }
        #endregion

        #region 获取AccessToken
        /// <summary>
        /// 
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="appSecret"></param>
        /// <returns></returns>
        public GetAccessTokenResult GetAccessToken(string corpid, string secret)
        {
            string url = string.Format("{0}gettoken?corpid={1}&corpsecret={2}", baseUrl, corpid, secret);
            return HttpHelper.HttpGet.GetJsonResult<GetAccessTokenResult>(url);
        }
        #endregion

        #region 获取部门列表
        /// <summary>
        /// 获取部门列表
        /// </summary>
        /// <param name="access_token"></param>
        /// <returns></returns>
        public GetDepartmentResult GetDepartmentList(string access_token)
        {
            string url = string.Format("{0}department/list?access_token={1}", baseUrl, access_token);
            return HttpHelper.HttpGet.GetJsonResult<GetDepartmentResult>(url);
        }

        /// <summary>
        /// 获取部门列表,钉钉没有
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public GetDepartmentResult GetDepartmentList(string access_token, string id)
        {
            var result = GetDepartmentList(access_token);
            result.department = result.department.Where(p => p.parentid == int.Parse(id));

            return result;
        }

        /// <summary>
        /// 创建部门
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="request"></param>
        /// <param name="access_token"></param>
        /// <returns></returns>
        public CreateDepartmentResult CreateDepartment(string access_token, string name, int parentid, int order)
        {
            string url = string.Format("{0}/department/create?access_token={1}", baseUrl, access_token);
            return HttpHelper.HttpPost.GetJsonResult<dynamic, CreateDepartmentResult>(url, new { name = name, parentid = parentid, order = order });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="access_token"></param>
        /// <returns></returns>
        public CreateDepartmentResult CreateDepartment(CreateDepartmentRequest request, string access_token)
        {
            string url = string.Format("{0}/department/create?access_token={1}", baseUrl, access_token);
            return HttpHelper.HttpPost.GetJsonResult<dynamic, CreateDepartmentResult>(url, request);
        }

        /// <summary>
        /// 更新部门
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="request"></param>
        /// <param name="access_token"></param>
        /// <returns></returns>
        public QyResult UpdateDepartment(string access_token, int id, string name, int parentid, int order)
        {
            string url = string.Format("{0}/department/update?access_token={1}", baseUrl, access_token);
            return HttpHelper.HttpPost.GetJsonResult<dynamic, QyResult>(url, new { id = id, name = name, parentid = parentid, order = order });
        }

        public QyResult UpdateDepartment(CreateDepartmentRequest request, string access_token)
        {
            string url = string.Format("{0}/department/update?access_token={1}", baseUrl, access_token);
            return HttpHelper.HttpPost.GetJsonResult<dynamic, QyResult>(url, request);
        }

        /// <summary>
        /// 删除部门
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="access_token"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public QyResult DeleteDepartment(string access_token, string id)
        {
            string url = string.Format("{0}department/delete?access_token={1}&id={2}", baseUrl, access_token, id);
            return HttpHelper.HttpGet.GetJsonResult<QyResult>(url);
        }

        #endregion

        #region 管理成员

        /// <summary>
        /// 创建成员
        /// </summary>
        /// <param name="helper">被扩展的对象</param>
        /// <param name="user">要添加的用户信息 <see cref="DTalk.API.Qy.CreateUserRequest"/></param>
        /// <param name="access_token">调用接口凭证</param>
        /// <returns></returns>
        public QyResult CreateUser(CreateUserRequest user, string access_token)
        {
            string url = string.Format("{0}user/create?access_token={0}", access_token);
            return HttpHelper.HttpPost.GetJsonResult<CreateUserRequest, QyResult>(url, user);
        }

        /// <summary>
        /// 更新成员
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="user"></param>
        /// <param name="access_token"></param>
        /// <returns></returns>
        public QyResult UpdateUser(UpdateUserRequest user, string access_token)
        {
            string url = string.Format("{0}user/update?access_token={1}", baseUrl, access_token);
            return HttpHelper.HttpPost.GetJsonResult<UpdateUserRequest, QyResult>(url, user);
        }

        /// <summary>
        /// 删除成员
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="access_token"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public QyResult DeleteUser(string access_token, string userId)
        {
            string url = string.Format("{0}user/delete?access_token={1}&userid={2}", baseUrl, access_token, userId);
            return HttpHelper.HttpGet.GetJsonResult<QyResult>(url);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="access_token"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public GetUserResult GetUser(string access_token, string userId)
        {
            string url = string.Format("{0}user/get?access_token={1}&userid={2}", baseUrl, access_token, userId);
            return HttpHelper.HttpGet.GetJsonResult<GetUserResult>(url);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="userId"></param>
        /// <param name="agentId"></param>
        /// <returns></returns>
        public ConvertUserIdToOpenIdResult ConvertUserIdToOpenId(string access_token, string userId, int agentId)
        {
            throw new NotImplementedException("钉钉没有这个接口");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="openId"></param>
        /// <param name="agentId"></param>
        /// <returns></returns>
        public ConvertOpenIdToUserIdResult ConvertOpenIdToUserId(string access_token, string openId, int agentId)
        {
            throw new NotImplementedException("钉钉没有这个接口");
        }
        /// <summary>
        /// 获取部门成员
        /// </summary>
        /// <param name="helper"></param>
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
        /// 获取部门成员（详情）
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="deptId"></param>
        /// <param name="fetchChild"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public GetUserListResult GetUserList(string access_token, int deptId, bool fetchChild, int status = 1)
        {
            string url = string.Format("{0}user/list?access_token={1}&department_id={2}&fetch_child={3}&status={4}", baseUrl, access_token, deptId, fetchChild ? 1 : 0);
            return HttpHelper.HttpGet.GetJsonResult<GetUserListResult>(url);
        }
        #endregion

        #region 发送消息

        /// <summary>
        /// 
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="touser">员工ID列表（消息接收者，多个接收者用’ | ‘分隔）。特殊情况：指定为@all，则向该企业应用的全部成员发送</param>
        /// <param name="toparty">部门ID列表，多个接收者用’ | '分隔。当touser为@all时忽略本参数</param>
        /// <param name="agentid">企业应用id，这个值代表以哪个应用的名义发送消息，如果不填，则以当前获取accesstoken的应用作为发消息的应用</param>
        /// <param name="content"></param>
        /// <returns></returns>
        public SendMessageResult SendMessageText(string access_token, string touser, string toparty, int agentid, string content)
        {
            string url = string.Format("{0}message/send?access_token={1}", baseUrl, access_token);
            return HttpHelper.HttpPost.GetJsonResult<dynamic, SendMessageResult>(url,
                new
                {
                    touser = touser,
                    toparty = toparty,
                    agentid = agentid,
                    msgtype = "text",
                    text = new { content = content }
                });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="touser"></param>
        /// <param name="toparty"></param>
        /// <param name="agentid"></param>
        /// <param name="media_id"></param>
        /// <returns></returns>
        public SendMessageResult SendMessageImage(string access_token, string touser, string toparty, int agentid, string media_id)
        {
            string url = string.Format("{0}message/send?access_token={1}", baseUrl, access_token);
            return HttpHelper.HttpPost.GetJsonResult<dynamic, SendMessageResult>(url,
                new
                {
                    touser = touser,
                    toparty = toparty,
                    agentid = agentid,
                    msgtype = "image",
                    image = new { media_id = media_id }
                });
        }

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="message"></param>
        /// <param name="access_token"></param>
        /// <returns></returns>
        public SendMessageResult SendMessage(SendMessageRequest message, string access_token)
        {
            string url = string.Format("{0}message/send?access_token={1}", baseUrl, access_token);
            return HttpHelper.HttpPost.GetJsonResult<SendMessageRequest, SendMessageResult>(url, message);
        }

        #endregion

        #region 管理标签
        public CreateTagResult CreateTag(int tagId, string tagname, string accessToken)
        {
            throw new NotImplementedException("钉钉没有这个接口");
        }

        public CreateTagResult CreateTag(CreateTagRequest tag, string accessToken)
        {
            throw new NotImplementedException("钉钉没有这个接口");
        }

        public QyResult UpdateTag(UploadTagRequest request, string accessToken)
        {
            throw new NotImplementedException("钉钉没有这个接口");
        }

        public QyResult DeleteTag(string accessToken, int tagId)
        {
            throw new NotImplementedException();
        }

        public GetTagUserResult GetTagUser(string accessToken, int tagId)
        {
            throw new NotImplementedException();
        }

        public AddTagUsersResult AddTagUsers(AddTagUsersRequest model, string accessToken)
        {
            throw new NotImplementedException();
        }

        public DeleteTagUsersResult DeleteTagUsers(AddTagUsersRequest model, string accessToken)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region 管理多媒体文件
        //// <summary>
        /// 上传多媒体文件
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="media"></param>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        public UploadMediaResult UploadMedia(UploadMediaRequest media, string accessToken)
        {
            string url = string.Format("{0}media/upload?access_token={1}&type={2}", baseUrl, accessToken, media.GetMediaType());
            return JsonHelper.Decode<UploadMediaResult>(HttpHelper.HttpPost.GetMediaResult(url, media.AsPostMedia()));
        }

        /// <summary>
        /// 获取媒体文件
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
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="fileName"></param>
        ///// <param name="filePath"></param>
        ///// <param name="accessToken"></param>
        ///// <param name="filetype"></param>
        ///// <returns></returns>
        //public string UploadMediaFromOA(string fileName, string filePath, string accessToken, string filetype = "file")
        //{
        //    string url = string.Format("{0}media/upload?access_token={1}&type={2}", baseUrl, accessToken, filetype);
        //    return HttpHelper.HttpPost.PostOAFileToUrl(fileName, filePath, url);
        //}
        #endregion

        #region 生成自定义菜单
        /// <summary>
        /// 
        /// </summary>
        /// <param name="menuJsonData"></param>
        /// <param name="accessToken"></param>
        /// <param name="agentId"></param>
        /// <returns></returns>
        public QyResult CreateCustomMenu(string menuJsonData, string accessToken, int agentId)
        {
            throw new NotImplementedException("没有接口");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="agentId"></param>
        /// <returns></returns>
        public QyResult DeleteCustomMenu(string accessToken, int agentId)
        {
            throw new NotImplementedException("没有接口");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <param name="fullFilePath"></param>
        /// <param name="accessToken"></param>
        /// <param name="agentId"></param>
        public void GetCustomMenu(string url, string fullFilePath, string accessToken, int agentId)
        {
            throw new NotImplementedException("没有接口");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="agentId"></param>
        /// <returns></returns>
        public string GetCustomMenu(string accessToken, int agentId)
        {
            throw new NotImplementedException("没有接口");
        }
        #endregion

        #region OAuth2验证

        /// <summary>
        /// OAuth2验证验证得到code后，在根据code或用户信息
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="accessToken"></param>
        /// <param name="code">code</param>
        /// <param name="agentId">agentId应用ID</param>
        /// <returns></returns>
        public OAuthGetUserInfoResult OAuthGetUserInfo(string accessToken, string code, int agentId)
        {
            string url = string.Format("{0}user/getuserinfo?access_token={1}&code={2}&agentid={3}", baseUrl, accessToken, code, agentId);
            return HttpHelper.HttpGet.GetJsonResult<OAuthGetUserInfoResult>(url);
        }

        #endregion

        #region jsapi
        /// <summary>
        /// 获取jsapi_ticket
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        public GetJsapiTicketResult GetJsapiTicket(string accessToken)
        {
            string url = string.Format("{0}get_jsapi_ticket?access_token={1}", baseUrl, accessToken);
            return HttpHelper.HttpGet.GetJsonResult<GetJsapiTicketResult>(url);
        }
        #endregion

        #region 企业号登录授权
        /// <summary>
        /// 获取应用提供商凭证
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="corpid">企业号（提供商）的corpid </param>
        /// <param name="provider_secret">提供商的secret，在提供商管理页面可见</param>
        /// <returns></returns>
        public GetProviderTokenResult GetProviderToken(string corpid, string provider_secret)
        {
            throw new NotImplementedException("没有接口");
        }

        /// <summary>
        /// 获取企业号管理员登录信息
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="provider_access_token">服务提供商的accesstoken </param>
        /// <param name="auth_code">oauth2.0授权企业号管理员登录产生的code </param>
        /// <returns></returns>
        public GetLoginInfoResult GetLoginInfo(string provider_access_token, string auth_code)
        {
            throw new NotImplementedException("没有接口");
        }
        #endregion

        #region 第三方应用

        /// <summary>
        /// 获取应用套件令牌
        /// </summary>
        /// <param name="suite_id"></param>
        /// <param name="suite_secret"></param>
        /// <param name="suite_ticket"></param>
        /// <returns></returns>
        public GetSuiteTokenResult GetSuiteToken(string suite_id, string suite_secret, string suite_ticket)
        {
            GetSuiteTokenRequest request = new GetSuiteTokenRequest();
            request.suite_id = suite_id;
            request.suite_secret = suite_secret;
            request.suite_ticket = suite_ticket;
            return GetSuiteToken(request);
        }

        /// <summary>
        /// 获取应用套件令牌
        /// 该API用于获取应用套件令牌（suite_access_token）。
        /// 注1：由于应用提供商可能托管了大量的企业号，其安全问题造成的影响会更加严重，故API中除了合法来源IP校验之外，还额外增加了1项安全策略：
        /// 获取suite_access_token时，还额外需要suite_ticket参数（请永远使用最新接收到的suite_ticket）。suite_ticket由企业号后台定时推送给应用套件，并定时更新。
        /// 注2：通过本接口获取的accesstoken不会自动续期，每次获取都会自动更新。
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public GetSuiteTokenResult GetSuiteToken(GetSuiteTokenRequest request)
        {
            string url = string.Format("{0}service/get_suite_token", baseUrl);
            return HttpHelper.HttpPost.GetJsonResult<GetSuiteTokenRequest, GetSuiteTokenResult>(url, request);
        }
        /// <summary>
        /// 获取预授权码
        /// 该API用于获取预授权码。预授权码用于企业号授权时的应用提供商安全验证。
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="request"></param>
        /// <param name="suiteAccessToken"></param>
        /// <returns></returns>
        public GetPreAuthCodeResult GetPreAuthCode(GetPreAuthCodeReqeust request, string suiteAccessToken)
        {
            string url = string.Format("{0}service/get_pre_auth_code?suite_access_token={1}", baseUrl, suiteAccessToken);
            return HttpHelper.HttpPost.GetJsonResult<GetPreAuthCodeReqeust, GetPreAuthCodeResult>(url, request);
        }
        /// <summary>
        /// 获取企业号的永久授权码
        /// 该API用于使用临时授权码换取授权方的永久授权码，并换取授权信息、企业access_token。
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="suite_id"></param>
        /// <param name="auth_code"></param>
        /// <param name="suiteAccessToken"></param>
        /// <returns></returns>
        public GetPermanentCodeResult GetPermanentCode(string suite_id, string auth_code, string suiteAccessToken)
        {
            var request = new GetPermanentCodeRequest { suite_id = suite_id, auth_code = auth_code };
            return GetPermanentCode(request, suiteAccessToken);
        }
        /// <summary>
        /// 获取企业号的永久授权码
        /// 该API用于使用临时授权码换取授权方的永久授权码，并换取授权信息、企业access_token。
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public GetPermanentCodeResult GetPermanentCode(GetPermanentCodeRequest request, string suiteAccessToken)
        {
            string url = string.Format("{0}service/get_permanent_code?suite_access_token={1}", baseUrl, suiteAccessToken);
            /*
                "permanent_code": "xxxx",
                "auth_corp_info":
                {
                    "corpid": "xxxx",
                    "corp_name": "name"
                },
                "auth_user_info":
                {
                    "userId":""
                }
             */
            return HttpHelper.HttpPost.GetJsonResult<dynamic, GetPermanentCodeResult>(url, new { tmp_auth_code = request.auth_code });
        }

        /// <summary>
        /// 获取企业号的授权信息
        /// 该API用于通过永久授权码换取企业号的授权信息。 永久code的获取，是通过临时授权码使用get_permanent_code 接口获取到的permanent_code。
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public GetAuthInfoResult GetAuthInfo(GetAuthInfoRequest request, string suiteAccessToken)
        {
            string url = string.Format("{0}service/get_auth_info?suite_access_token={1}", baseUrl, suiteAccessToken);
            return HttpHelper.HttpPost.GetJsonResult<GetAuthInfoRequest, GetAuthInfoResult>(url, request);
        }
        /// <summary>
        /// 获取企业号应用
        /// 该API用于获取授权方的企业号某个应用的基本信息，包括头像、昵称、帐号类型、认证类型、可见范围等信息
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="suite_id">套件ID</param>
        /// <param name="auth_corpid">授权方企业ID</param>
        /// <param name="permanent_code">永久授权码</param>
        /// <param name="agentid">授权方应用ID</param>
        /// <param name="suiteAccessToken"></param>
        /// <returns></returns>
        public GetAgentResult GetAgent(string suite_id, string auth_corpid, string permanent_code,
            string agentid, string suiteAccessToken)
        {
            var request = new GetAgentRequest();
            request.suite_id = suite_id;
            request.auth_corpid = auth_corpid;
            request.permanent_code = permanent_code;
            request.agentid = agentid;
            return GetAgent(request, suiteAccessToken);
        }
        /// <summary>
        /// 获取企业号应用
        /// 该API用于获取授权方的企业号某个应用的基本信息，包括头像、昵称、帐号类型、认证类型、可见范围等信息
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public GetAgentResult GetAgent(GetAgentRequest request, string suiteAccessToken)
        {
            string url = string.Format("{0}service/get_agent?suite_access_token={1}", baseUrl, suiteAccessToken);
            return HttpHelper.HttpPost.GetJsonResult<GetAgentRequest, GetAgentResult>(url, request);
        }
        /// <summary>
        /// 设置企业号应用
        /// 该API用于设置授权方的企业应用的选项设置信息，如：地理位置上报等。注意，获取各项选项设置信息，需要有授权方的授权。
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public SetAgentResult SetAgent(SetAgentRequest request, string suiteAccessToken)
        {
            string url = string.Format("{0}service/set_agent?suite_access_token={1}", baseUrl, suiteAccessToken);
            return HttpHelper.HttpPost.GetJsonResult<SetAgentRequest, SetAgentResult>(url, request);
        }
        /// <summary>
        /// 获取企业号access_token
        /// 应用提供商在取得企业号的永久授权码并完成对企业号应用的设置之后，便可以开始通过调用企业接口（详见企业接口文档）来运营这些应用。
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public GetCorpTokenResult GetCorpToken(GetCorpTokenRequest request, string suiteAccessToken)
        {
            string url = string.Format("{0}service/get_corp_token?suite_access_token={1}", baseUrl, suiteAccessToken);
            return HttpHelper.HttpPost.GetJsonResult<GetCorpTokenRequest, GetCorpTokenResult>(url, request);
        }
        #endregion

        #region 消息接口
        /// <summary>
        /// 创建会话
        /// </summary>
        /// <param name="chatid">
        /// 回话ID,字符串类型，最长32个字符。只允许字符0-9及字母a-zA-Z,如果值内容为64bit无符号整型：要求值范围在[1, 2^63)之间，[2^63, 2^64)为系统分配会话id区间 
        /// </param>
        /// <param name="name">会话标题</param>
        /// <param name="owner">管理员userid，必须是该会话userlist的成员之一</param>
        /// <param name="userlist">会话成员列表，成员用userid来标识。会话成员必须在3人或以上，1000人以下</param>
        /// <returns></returns>
        public APIJsonResult CreateChat(string access_token, string chatid, string name, string owner, string[] userlist)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 创建会话
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public APIJsonResult CreateChat(string access_token, CreateChatRequest request)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 获取会话
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="chatid"></param>
        /// <returns></returns>
        public GetChatResult GetChat(string access_token, string chatid)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 修改会话信息
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public APIJsonResult UpdateChat(string access_token, UpdateChatRequest request)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 退出会话
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="chatid">会话id </param>
        /// <param name="op_user">操作人userid </param>
        /// <returns></returns>
        public APIJsonResult QuitChat(string access_token, string chatid, string op_user)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="chatid_or_userid">type 为single时是userid，否则为chatid</param>
        /// <param name="op_user"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public APIJsonResult ClearNotifyChat(string access_token, string chatid_or_userid, string op_user, ChatType type)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 发消息
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public APIJsonResult SendChat(string access_token, SendChatRequest request)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 设置成员新消息免打扰
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="user_mute_list"></param>
        /// <returns></returns>
        public SetMuteChatResult SetMuteChat(string access_token, SetMuteChatInfo[] user_mute_list)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
