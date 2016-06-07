using API.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API.Qy
{
    /// <summary>
    /// 
    /// </summary>
    public static class QyAPIHelperExtensionsForWeixin
    {
        const string baseurl = "https://qyapi.weixin.qq.com/cgi-bin/";
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
        public static APIJsonResult CreateChat(this IQyHelper helper, string access_token, string chatid, string name, string owner, string[] userlist)
        {
            string url = string.Format("{0}chat/create?access_token={1}", baseurl, access_token);
            var request = new CreateChatRequest();
            request.chatid = chatid;
            request.name = name;
            request.owner = owner;
            request.userlist = userlist;
            return helper.CreateChat(access_token, request);
        }
        /// <summary>
        /// 创建会话
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public static APIJsonResult CreateChat(this IQyHelper helper, string access_token, CreateChatRequest request)
        {
            string url = string.Format("{0}chat/create?access_token={1}", baseurl, access_token);
            return HttpHelper.HttpPost.GetJsonResult<CreateChatRequest, APIJsonResult>(url, request);
        }
        /// <summary>
        /// 获取会话
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="chatid"></param>
        /// <returns></returns>
        public static GetChatResult GetChat(this IQyHelper helper, string access_token, string chatid)
        {
            string url = string.Format("{0}chat/get?access_token={1}&chatid={2}", baseurl, access_token, chatid);
            return HttpHelper.HttpGet.GetJsonResult<GetChatResult>(url);
        }
        /// <summary>
        /// 修改会话信息
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public static APIJsonResult UpdateChat(this IQyHelper helper, string access_token, UpdateChatRequest request)
        {
            string url = string.Format("{0}chat/update?access_token={1}", baseurl, access_token);
            return HttpHelper.HttpPost.GetJsonResult<UpdateChatRequest, GetChatResult>(url, request);
        }
        /// <summary>
        /// 退出会话
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="chatid">会话id </param>
        /// <param name="op_user">操作人userid </param>
        /// <returns></returns>
        public static APIJsonResult QuitChat(this IQyHelper helper, string access_token, string chatid, string op_user)
        {
            string url = string.Format("{0}chat/quit?access_token={1}", baseurl, access_token);
            return HttpHelper.HttpPost.GetJsonResult<dynamic, GetChatResult>(url, new { chatid = chatid, op_user = op_user });
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="chatid_or_userid">type 为single时是userid，否则为chatid</param>
        /// <param name="op_user"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static APIJsonResult ClearNotifyChat(this IQyHelper helper, string access_token, string chatid_or_userid, string op_user, ChatType type)
        {
            string url = string.Format("{0}chat/clearnotify?access_token={1}", baseurl, access_token);
            return HttpHelper.HttpPost.GetJsonResult<dynamic, GetChatResult>(url,
                new
                {
                    op_user = op_user,
                    chat = new
                    {
                        type = type.ToString(),
                        id = chatid_or_userid
                    }
                });
        }
        /// <summary>
        /// 发消息
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public static APIJsonResult SendChat(this IQyHelper helper, string access_token, SendChatRequest request)
        {
            string url = string.Format("{0}chat/send?access_token={1}", baseurl, access_token);
            return HttpHelper.HttpPost.GetJsonResult<SendChatRequest, GetChatResult>(url, request);
        }
        /// <summary>
        /// 设置成员新消息免打扰
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="user_mute_list"></param>
        /// <returns></returns>
        public static SetMuteChatResult SetMuteChat(this IQyHelper helper, string access_token, SetMuteChatInfo[] user_mute_list)
        {
            string url = string.Format("{0}chat/setmute?access_token={1}", baseurl, access_token);
            return HttpHelper.HttpPost.GetJsonResult<dynamic, SetMuteChatResult>(url, new { user_mute_list = user_mute_list });
        }
        #endregion

        #region 管理企业号应用


        #region 获取企业号应用

        /// <summary>
        /// 获取企业号某个应用的基本信息，包括头像、昵称、帐号类型、认证类型、可见范围等信息
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="access_token"></param>
        /// <param name="agentid"></param>
        /// <returns></returns>
        public static GetAgentQyResult GetAgentByAccessToken(this IQyHelper helper, string access_token, int agentid)
        {
            string url = string.Format("{0}agent/get?access_token={1}&agentid={2}", baseurl, access_token, agentid);
            return HttpHelper.Get<GetAgentQyResult>(url);
        }
        #endregion

        #region MyRegion

        /// <summary>
        /// 该API用于设置企业应用的选项设置信息，如：地理位置上报等。第三方服务商不能调用该接口设置授权的主页型应用。
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="access_token"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public static QyResult SetAgentByAccessToken(this IQyHelper helper, string access_token, SetAgentQyRequest request)
        {
            string url = string.Format("{0}agent/set?access_token={1}", baseurl, access_token);
            return HttpHelper.Send<SetAgentQyRequest, QyResult>(url, request);
        }
        #endregion


        #endregion
    }
}
