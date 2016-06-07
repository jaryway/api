using API.Qy.ThirdAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Qy
{
    /// <summary>
    /// 
    /// </summary>
    public partial interface IQyHelper
    {
        #region 获取AccessToken
        /// <summary>
        /// 获取AccessToken
        /// </summary>
        /// <param name="corpId"></param>
        /// <param name="corpSecret"></param>
        /// <returns></returns>
        GetAccessTokenResult GetAccessToken(string corpId, string corpSecret);

        #endregion

        #region 部门管理
        /// <summary>
        /// 创建部门
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="request"></param>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        CreateDepartmentResult CreateDepartment(CreateDepartmentRequest request, string accessToken);

        /// <summary>
        /// 更新部门
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="request"></param>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        QyResult UpdateDepartment(CreateDepartmentRequest request, string accessToken);

        /// <summary>
        /// 删除部门
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="accessToken"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        QyResult DeleteDepartment(string accessToken, string id);

        /// <summary>
        /// 获取部门列表
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="accessToken">accessToken</param>
        GetDepartmentResult GetDepartmentList(string accessToken);

        /// <summary>
        /// 获取部门列表
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="accessToken">accessToken</param>
        /// <param name="id">部门ID。获取指定部门ID下的子部门 </param>
        GetDepartmentResult GetDepartmentList(string accessToken, string id);

        #endregion

        #region 管理成员

        /// <summary>
        /// 创建成员
        /// </summary>
        /// <param name="user">要添加的用户信息 <see cref="API.Qy.CreateUserRequest"/></param>
        /// <param name="accessToken">调用接口凭证</param>
        /// <returns></returns>
        QyResult CreateUser(CreateUserRequest user, string accessToken);

        /// <summary>
        /// 更新成员
        /// </summary>
        /// <param name="user"></param>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        QyResult UpdateUser(UpdateUserRequest user, string accessToken);

        /// <summary>
        /// 删除成员
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        QyResult DeleteUser(string accessToken, string userId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        GetUserResult GetUser(string accessToken, string userId);

        /// <summary>
        /// 获取部门成员
        /// </summary>
        /// <param name="accessToken">调用接口凭证</param>
        /// <param name="deptId">获取的部门id </param>
        /// <param name="fetchChild">1/0：是否递归获取子部门下面的成员 </param>
        /// <param name="status">0获取全部员工，1获取已关注成员列表，2获取禁用成员列表，4获取未关注成员列表。status可叠加</param>
        /// <returns></returns>
        GetUserSimpleListResult GetUserSimpleList(string accessToken, int deptId, bool fetchChild, int status);

        /// <summary>
        /// 获取部门成员(详情)
        /// </summary>
        /// <param name="accessToken">调用接口凭证</param>
        /// <param name="deptId">获取的部门id </param>
        /// <param name="fetchChild">1/0：是否递归获取子部门下面的成员 </param>
        /// <param name="status">0获取全部员工，1获取已关注成员列表，2获取禁用成员列表，4获取未关注成员列表。status可叠加</param>
        /// <returns></returns>
        GetUserListResult GetUserList(string accessToken, int deptId, bool fetchChild, int status);

        /// <summary>
        /// 根据userid 获取openid
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="userId"></param>
        /// <param name="agentId"></param>
        /// <returns></returns>
        ConvertUserIdToOpenIdResult ConvertUserIdToOpenId(string access_token, string userId, int agentId);
        /// <summary>
        /// 根据openid获取userid
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="openId"></param>
        /// <param name="agentId"></param>
        /// <returns></returns>
        ConvertOpenIdToUserIdResult ConvertOpenIdToUserId(string access_token, string openId, int agentId);
        #endregion

        #region 管理标签

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tagId"></param>
        /// <param name="tagname"></param>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        CreateTagResult CreateTag(int tagId, string tagname, string accessToken);

        /// <summary>
        /// 创建标签
        /// </summary>
        /// <param name="tag"></param>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        CreateTagResult CreateTag(CreateTagRequest tag, string accessToken);

        /// <summary>
        /// 更新标签名字
        /// </summary>
        /// <param name="request"></param>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        QyResult UpdateTag(UploadTagRequest request, string accessToken);

        /// <summary>
        /// 删除标签
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="tagId"></param>
        /// <returns></returns>
        QyResult DeleteTag(string accessToken, int tagId);

        /// <summary>
        /// 获取标签成员
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="tagId"></param>
        /// <returns></returns>
        GetTagUserResult GetTagUser(string accessToken, int tagId);

        /// <summary>
        /// 增加标签成员
        /// </summary>
        /// <param name="model"></param>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        AddTagUsersResult AddTagUsers(AddTagUsersRequest model, string accessToken);

        /// <summary>
        /// 删除标签成员
        /// </summary>
        /// <param name="model"></param>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        DeleteTagUsersResult DeleteTagUsers(AddTagUsersRequest model, string accessToken);

        #endregion

        #region 管理多媒体文件

        /// <summary>
        /// 上传多媒体文件
        /// </summary>
        /// <param name="media"></param>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        UploadMediaResult UploadMedia(UploadMediaRequest media, string accessToken);

        /// <summary>
        /// 获取媒体文件
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="media_id">媒体ID</param>
        /// <returns></returns>
        GetMediaResult GetMedia(string access_token, string media_id);

        //string UploadMediaFromOA(string fileName, string filePath, string accessToken, string filetype = "file");

        #endregion

        #region 发送消息

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="message"></param>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        SendMessageResult SendMessage(SendMessageRequest message, string accessToken);

        #endregion

        #region 生成自定义菜单

        /// <summary>
        /// 生成自定义菜单
        /// </summary>
        /// <param name="menuJsonData"></param>
        /// <param name="accessToken"></param>
        /// <param name="agentId"></param>
        /// <returns></returns>
        QyResult CreateCustomMenu(string menuJsonData, string accessToken, int agentId);

        /// <summary>
        /// 删除自定义菜单
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="agentId"></param>
        /// <returns></returns>
        QyResult DeleteCustomMenu(string accessToken, int agentId);

        /// <summary>
        /// 获取自定义菜单
        /// </summary>
        /// <param name="url"></param>
        /// <param name="fullFilePath"></param>
        /// <param name="accessToken"></param>
        /// <param name="agentId"></param>
        void GetCustomMenu(string url, string fullFilePath, string accessToken, int agentId);

        /// <summary>
        /// 获取自定义菜单
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="agentId"></param>
        /// <returns></returns>
        string GetCustomMenu(string accessToken, int agentId);

        #endregion

        #region OAuth2验证

        /// <summary>
        /// OAuth2验证验证得到code后，在根据code或用户信息
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="code">code</param>
        /// <param name="agentId">agentId应用ID</param>
        /// <returns></returns>
        OAuthGetUserInfoResult OAuthGetUserInfo(string accessToken, string code, int agentId);

        #endregion

        #region jsapi
        /// <summary>
        /// 获取jsapi_ticket
        /// </summary>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        GetJsapiTicketResult GetJsapiTicket(string accessToken);
        #endregion

        #region 企业号登录授权
        /// <summary>
        /// 获取应用提供商凭证
        /// </summary>
        /// <param name="corpid">企业号（提供商）的corpid </param>
        /// <param name="provider_secret">提供商的secret，在提供商管理页面可见</param>
        /// <returns></returns>
        GetProviderTokenResult GetProviderToken(string corpid, string provider_secret);

        /// <summary>
        /// 获取企业号管理员登录信息
        /// </summary>
        /// <param name="provider_access_token">服务提供商的accesstoken </param>
        /// <param name="auth_code">oauth2.0授权企业号管理员登录产生的code </param>
        /// <returns></returns>
        GetLoginInfoResult GetLoginInfo(string provider_access_token, string auth_code);
        #endregion

        /*
        #region 第三方授权
        /// <summary>
        /// 获取应用套件令牌
        /// </summary>
        /// <param name="suite_id"></param>
        /// <param name="suite_secret"></param>
        /// <param name="suite_ticket"></param>
        /// <returns></returns>
        GetSuiteTokenResult GetSuiteToken(string suite_id, string suite_secret, string suite_ticket);
        /// <summary>
        /// 获取应用套件令牌
        /// 该API用于获取应用套件令牌（suite_access_token）。
        /// 注1：由于应用提供商可能托管了大量的企业号，其安全问题造成的影响会更加严重，故API中除了合法来源IP校验之外，还额外增加了1项安全策略：
        /// 获取suite_access_token时，还额外需要suite_ticket参数（请永远使用最新接收到的suite_ticket）。suite_ticket由企业号后台定时推送给应用套件，并定时更新。
        /// 注2：通过本接口获取的accesstoken不会自动续期，每次获取都会自动更新。
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        GetSuiteTokenResult GetSuiteToken(GetSuiteTokenRequest request);
        /// <summary>
        /// 获取预授权码
        /// 该API用于获取预授权码。预授权码用于企业号授权时的应用提供商安全验证。
        /// </summary>
        /// <param name="request"></param>
        /// <param name="suiteAccessToken"></param>
        /// <returns></returns>
        GetPreAuthCodeResult GetPreAuthCode(GetPreAuthCodeReqeust request, string suiteAccessToken);
        /// <summary>
        /// 获取企业号的永久授权码
        /// 该API用于使用临时授权码换取授权方的永久授权码，并换取授权信息、企业access_token。
        /// </summary>
        /// <param name="suite_id"></param>
        /// <param name="auth_code"></param>
        /// <param name="suiteAccessToken"></param>
        /// <returns></returns>
        GetPermanentCodeResult GetPermanentCode(string suite_id, string auth_code, string suiteAccessToken);
        /// <summary>
        /// 获取企业号的永久授权码
        /// 该API用于使用临时授权码换取授权方的永久授权码，并换取授权信息、企业access_token。
        /// </summary>
        /// <param name="request"></param>
        /// <param name="suiteAccessToken"></param>
        /// <returns></returns>
        GetPermanentCodeResult GetPermanentCode(GetPermanentCodeRequest request, string suiteAccessToken);
        /// <summary>
        /// 获取企业号的授权信息
        /// 该API用于通过永久授权码换取企业号的授权信息。 永久code的获取，是通过临时授权码使用get_permanent_code 接口获取到的permanent_code。
        /// </summary>
        /// <param name="request"></param>
        /// <param name="suiteAccessToken"></param>
        /// <returns></returns>
        GetAuthInfoResult GetAuthInfo(GetAuthInfoRequest request, string suiteAccessToken);
        /// <summary>
        /// 获取企业号应用
        /// 该API用于获取授权方的企业号某个应用的基本信息，包括头像、昵称、帐号类型、认证类型、可见范围等信息
        /// </summary>
        /// <param name="suite_id">套件ID</param>
        /// <param name="auth_corpid">授权方企业ID</param>
        /// <param name="permanent_code">永久授权码</param>
        /// <param name="agentid">授权方应用ID</param>
        /// <param name="suiteAccessToken"></param>
        /// <returns></returns>
        GetAgentResult GetAgent(string suite_id, string auth_corpid,
            string permanent_code, string agentid, string suiteAccessToken);
        /// <summary>
        /// 获取企业号应用
        /// 该API用于获取授权方的企业号某个应用的基本信息，包括头像、昵称、帐号类型、认证类型、可见范围等信息
        /// </summary>
        /// <param name="request"></param>
        /// <param name="suiteAccessToken"></param>
        /// <returns></returns>
        GetAgentResult GetAgent(GetAgentRequest request, string suiteAccessToken);
        /// <summary>
        /// 设置企业号应用
        /// 该API用于设置授权方的企业应用的选项设置信息，如：地理位置上报等。注意，获取各项选项设置信息，需要有授权方的授权。
        /// </summary>
        /// <param name="request"></param>
        /// <param name="suiteAccessToken"></param>
        /// <returns></returns>
        SetAgentResult SetAgent(SetAgentRequest request, string suiteAccessToken);
        /// <summary>
        /// 获取企业号access_token
        /// 应用提供商在取得企业号的永久授权码并完成对企业号应用的设置之后，便可以开始通过调用企业接口（详见企业接口文档）来运营这些应用。
        /// </summary>
        /// <param name="request"></param>
        /// <param name="suiteAccessToken"></param>
        /// <returns></returns>
        GetCorpTokenResult GetCorpToken(GetCorpTokenRequest request, string suiteAccessToken);
        #endregion
        */

        /*
         * 已经移到微信特有扩展中
        #region 消息接口
        /// <summary>
        /// 创建会话
        /// </summary>
        /// <param name="chatid">
        /// 回话ID,字符串类型，最长32个字符。只允许字符0-9及字母a-zA-Z,如果值内容为64bit无符号整型：要求值范围在[1, 2^63)之间，[2^63, 2^64)为系统分配会话id区间 
        /// </param>
        /// <param name="access_token"></param>
        /// <param name="name">会话标题</param>
        /// <param name="owner">管理员userid，必须是该会话userlist的成员之一</param>
        /// <param name="userlist">会话成员列表，成员用userid来标识。会话成员必须在3人或以上，1000人以下</param>
        /// <returns></returns>
        APIJsonResult CreateChat(string access_token, string chatid, string name, string owner, string[] userlist);
        /// <summary>
        /// 创建会话
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        APIJsonResult CreateChat(string access_token, CreateChatRequest request);
        /// <summary>
        /// 获取会话
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="chatid"></param>
        /// <returns></returns>
        GetChatResult GetChat(string access_token, string chatid);
        /// <summary>
        /// 修改会话信息
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        APIJsonResult UpdateChat(string access_token, UpdateChatRequest request);
        /// <summary>
        /// 退出会话
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="chatid">会话id </param>
        /// <param name="op_user">操作人userid </param>
        /// <returns></returns>
        APIJsonResult QuitChat(string access_token, string chatid, string op_user);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="chatid_or_userid">type 为single时是userid，否则为chatid</param>
        /// <param name="op_user"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        APIJsonResult ClearNotifyChat(string access_token, string chatid_or_userid, string op_user, ChatType type);
        /// <summary>
        /// 发消息
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        APIJsonResult SendChat(string access_token, SendChatRequest request);
        /// <summary>
        /// 设置成员新消息免打扰
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="user_mute_list"></param>
        /// <returns></returns>
        SetMuteChatResult SetMuteChat(string access_token, SetMuteChatInfo[] user_mute_list);
        #endregion
         */
    }
}
