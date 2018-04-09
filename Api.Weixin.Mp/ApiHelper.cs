using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Api.Core.Helpers;
using Api.Core;
using Api.Core.Models;

namespace Api.Weixin.Mp
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
        const string baseUrl = "https://api.weixin.qq.com/";
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

        #region 基础接口
        /// <summary>
        /// 
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="appSecret"></param>
        /// <returns></returns>
        public GetAccessTokenResult GetAccessToken(string appId, string appSecret)
        {
            string url = string.Format("{0}cgi-bin/token?grant_type=client_credential&appid={1}&secret={2}", baseUrl, appId, appSecret);
            return HttpHelper.HttpGet.GetJsonResult<GetAccessTokenResult>(url);
        }

        /// <summary>
        /// 获取微信服务器IP地址
        /// </summary>
        /// <param name="access_token"></param>
        /// <returns></returns>
        public GetCallbackIPResult GetCallbackIP(string access_token)
        {
            string url = string.Format("{0}cgi-bin/getcallbackip?access_token={1}", baseUrl, access_token);
            return HttpHelper.HttpGet.GetJsonResult<GetCallbackIPResult>(url);
        }

        /// <summary>
        /// 上传多媒体文件
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public UploadMediaResult UploadMedia(string access_token, UploadMediaRequest request)
        {
            string url = string.Format("http://file.api.weixin.qq.com/cgi-bin/media/upload?access_token={0}&type={1}", access_token, request.GetMediaType());
            return JsonHelper.Decode<UploadMediaResult>(HttpHelper.HttpPost.GetMediaResult(url, request.AsWeixinMedia()));
        }
        /// <summary>
        /// 获取临时素材
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="media_id">媒体ID</param>
        /// <returns></returns>
        public GetMediaResult GetMedia(string access_token, string media_id)
        {
            string url = string.Format("{0}cgi-bin/media/get?access_token={1}&media_id={2}", baseUrl, access_token, media_id);
            var data = HttpHelper.HttpGet.GetResult(url);
            GetMediaResult result = JsonHelper.Decode<GetMediaResult>(data.Content);
            result.Stream = data.Stream;
            return result;
        }
        #endregion

        #region 发送消息-客服接口

        /// <summary>
        /// 添加客服帐号
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="kf_account">账号 e.g. test@test</param>
        /// <param name="nickname">昵称</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        public JsonResult AddKFAccount(string access_token, string kf_account, string nickname, string password)
        {
            string url = string.Format("{0}cgi-bin/customservice/kfaccount/add?access_token={1}", baseUrl, access_token);
            return HttpHelper.HttpPost.GetJsonResult<dynamic, JsonResult>(url, new { kf_account = kf_account, nickname = nickname, password = password });
        }
        /// <summary>
        /// 修改客服帐号
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="kf_account">账号 e.g. test@test</param>
        /// <param name="nickname">昵称</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        public JsonResult UpdateKFAccount(string access_token, string kf_account, string nickname, string password)
        {
            string url = string.Format("{0}cgi-bin/customservice/kfaccount/update?access_token={1}", baseUrl, access_token);
            return HttpHelper.HttpPost.GetJsonResult<dynamic, JsonResult>(url, new { kf_account = kf_account, nickname = nickname, password = password });
        }
        /// <summary>
        /// 删除客服帐号
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="kf_account">账号 e.g. test@test</param>
        /// <param name="nickname">昵称</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        public JsonResult DeleteKFAccount(string access_token, string kf_account, string nickname, string password)
        {
            string url = string.Format("{0}cgi-bin/customservice/kfaccount/del?access_token={1}", baseUrl, access_token);
            return HttpHelper.HttpPost.GetJsonResult<dynamic, JsonResult>(url, new { kf_account = kf_account, nickname = nickname, password = password });
        }
        /// <summary>
        /// 设置客服帐号的头像
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="kf_account"></param>
        /// <param name="media"></param>
        /// <returns></returns>
        public JsonResult UploadHeadImg(string access_token, string kf_account, PostMedia media)
        {
            string url = string.Format("{0}cgi-bin/customservice/kfaccount/uploadheadimg?access_token={1}&kf_account={2}", baseUrl, access_token, kf_account);
            return JsonHelper.Decode<JsonResult>(HttpHelper.HttpPost.GetMediaResult(url, media));
        }
        /// <summary>
        /// 获取所有客服账号
        /// </summary>
        /// <param name="access_token"></param>
        /// <returns></returns>
        public GetKFListResult GetKFList(string access_token)
        {
            string url = string.Format("{0}cgi-bin/customservice/getkflist?access_token={1}", baseUrl, access_token);
            return HttpHelper.HttpGet.GetJsonResult<GetKFListResult>(url);
        }

        /// <summary>
        /// 发送客服消息
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public JsonResult SendKFMessage(string access_token, SendKFMessageRequest request)
        {
            string url = string.Format("{0}cgi-bin/message/custom/send?access_token={1}", baseUrl, access_token);
            return HttpHelper.HttpPost.GetJsonResult<SendKFMessageRequest, JsonResult>(url, request);
        }

        #endregion

        #region 发送消息-高级群发接口
        /// <summary>
        /// 上传图文消息素材【订阅号与服务号认证后均可用】 
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public JsonResult UploadMediaNews(string access_token, UploadMediaNewsRequest request)
        {
            string url = string.Format("{0}cgi-bin/media/uploadnews?access_token={1}", baseUrl, access_token);
            return HttpHelper.HttpPost.GetJsonResult<UploadMediaNewsRequest, JsonResult>(url, request);
        }
        /// <summary>
        /// 根据分组进行群发【订阅号与服务号认证后均可用】 
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="is_to_all">用于设定是否向全部用户发送，值为true或false，选择true该消息群发给所有用户，选择false可根据group_id发送给指定群组的用户</param>
        /// <param name="group_id">群发到的分组的group_id，参加用户管理中用户分组接口，若is_to_all值为true，可不填写group_id</param>
        /// <param name="content">文本消息内容，仅当msgtype=text时有效</param>
        /// <param name="media_id">用于群发的消息的media_id，需通过基础支持中的上传下载多媒体文件来得到 https://file.api.weixin.qq.com/cgi-bin/media/uploadvideo?access_token=ACCESS_TOKEN </param>
        /// <param name="msgtype">群发的消息类型，图文消息为mpnews，文本消息为text，语音为voice，音乐为music，图片为image，视频为video，卡券为wxcard </param>
        /// <param name="card_id">卡券ID，仅当msgtype=wxcard时有效</param>
        /// <returns></returns>
        public SendMassMessageResult SendMassMessageByGroup(string access_token, bool is_to_all,
            int group_id, string msgtype, string content, string media_id, string card_id)
        {
            string url = string.Format("{0}cgi-bin/message/mass/sendall?access_token={1}", baseUrl, access_token);
            var filter = new { is_to_all = is_to_all, group_id = group_id };
            var media = new { media_id = media_id };
            dynamic model;

            switch (msgtype)
            {
                default:
                case "mpnews":
                    model = new { filter = filter, mpnews = media, msgtype = msgtype };
                    break;
                case "text":
                    model = new { filter = filter, text = new { content = content }, msgtype = msgtype };
                    break;
                case "voice":
                    model = new { filter = filter, voice = media, msgtype = msgtype };
                    break;
                case "music":
                    model = new { filter = filter, music = media, msgtype = msgtype };
                    break;
                case "image":
                    model = new { filter = filter, image = media, msgtype = msgtype };
                    break;
                case "video":
                    model = new { filter = filter, video = media, msgtype = msgtype };
                    break;
                case "wxcard":
                    model = new { filter = filter, wxcard = new { card_id = card_id }, msgtype = msgtype };
                    break;
            }

            return HttpHelper.HttpPost.GetJsonResult<dynamic, SendMassMessageResult>(url, model);
        }

        /// <summary>
        /// 根据OpenID列表群发【订阅号不可用，服务号认证后可用】 
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="openIds">填写图文消息的接收者，一串OpenID列表，OpenID最少2个，最多10000个 </param>
        /// <param name="msgtype">群发的消息类型，图文消息为mpnews，文本消息为text，语音为voice，音乐为music，图片为image，视频为video，卡券为wxcard </param>
        /// <param name="content">文本消息内容，仅当msgtype=text时有效</param>
        /// <param name="media_id">
        /// 用于群发的消息的media_id，
        /// 需通过基础支持中的上传下载多媒体文件来得到
        /// </param>
        /// <param name="card_id">卡券ID，仅当msgtype=wxcard时有效</param>
        /// <returns></returns>
        public SendMassMessageResult SendMassMessageByOpenIds(string access_token,
            string[] openIds, string msgtype, string content, string media_id, string card_id)
        {
            string url = string.Format("{0}cgi-bin/message/mass/sendall?access_token={1}", baseUrl, access_token);
            var media = new { media_id = media_id };
            dynamic model;

            switch (msgtype)
            {
                default:
                case "mpnews":
                    model = new { touser = openIds, mpnews = media, msgtype = msgtype };
                    break;
                case "text":
                    model = new { touser = openIds, text = new { content = content }, msgtype = msgtype };
                    break;
                case "voice":
                    model = new { touser = openIds, voice = media, msgtype = msgtype };
                    break;
                case "music":
                    model = new { touser = openIds, music = media, msgtype = msgtype };
                    break;
                case "image":
                    model = new { touser = openIds, image = media, msgtype = msgtype };
                    break;
                case "video":
                    model = new { touser = openIds, video = media, msgtype = msgtype };
                    break;
                case "wxcard":
                    model = new { touser = openIds, wxcard = new { card_id = card_id }, msgtype = msgtype };
                    break;
            }

            return HttpHelper.HttpPost.GetJsonResult<dynamic, SendMassMessageResult>(url, model);
        }

        /// <summary>
        /// 删除群发【订阅号与服务号认证后均可用】
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="msg_id"></param>
        /// <returns></returns>
        public JsonResult DeleteMassMessage(string access_token, long msg_id)
        {
            string url = string.Format("{0}cgi-bin/message/mass/delete?access_token={1}", baseUrl, access_token);
            return HttpHelper.HttpPost.GetJsonResult<dynamic, JsonResult>(url, new { msg_id = msg_id });
        }

        /// <summary>
        /// 预览接口【订阅号与服务号认证后均可用】 
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="openId">填写图文消息的接收者</param>
        /// <param name="msgtype">群发的消息类型，图文消息为mpnews，文本消息为text，语音为voice，音乐为music，图片为image，视频为video，卡券为wxcard</param>
        /// <param name="content">文本消息内容，仅当msgtype=text时有效</param>
        /// <param name="media_id">
        /// 用于群发的消息的media_id，
        /// 需通过基础支持中的上传下载多媒体文件来得到
        /// </param>
        /// <param name="card_id">卡券ID，仅当msgtype=wxcard时有效</param>
        /// <param name="card_ext"></param>
        /// <returns></returns>
        public SendMassMessageResult PreviewMassMessage(string access_token,
            string openId, string msgtype, string content, string media_id, string card_id, string card_ext)
        {
            string url = string.Format("{0}cgi-bin/message/mass/preview?access_token={1}", baseUrl, access_token);
            var media = new { media_id = media_id };
            dynamic model;

            switch (msgtype)
            {
                default:
                case "mpnews":
                    model = new { touser = openId, mpnews = media, msgtype = msgtype };
                    break;
                case "text":
                    model = new { touser = openId, text = new { content = content }, msgtype = msgtype };
                    break;
                case "voice":
                    model = new { touser = openId, voice = media, msgtype = msgtype };
                    break;
                case "music":
                    model = new { touser = openId, music = media, msgtype = msgtype };
                    break;
                case "image":
                    model = new { touser = openId, image = media, msgtype = msgtype };
                    break;
                case "video":
                    model = new { touser = openId, video = media, msgtype = msgtype };
                    break;
                case "wxcard":
                    model = new { touser = openId, wxcard = new { card_id = card_id, card_ext = card_ext }, msgtype = msgtype };
                    break;
            }

            return HttpHelper.HttpPost.GetJsonResult<dynamic, SendMassMessageResult>(url, model);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="msg_id"></param>
        /// <returns></returns>
        public GetMassMessageResult GetMassMessage(string access_token, long msg_id)
        {
            string url = string.Format("{0}cgi-bin/message/mass/get?access_token={1}", baseUrl, access_token);
            return HttpHelper.HttpPost.GetJsonResult<dynamic, GetMassMessageResult>(url, new { msg_id = msg_id });
        }

        #endregion

        #region 发送消息-模板消息接口
        /// <summary>
        /// 设置所属行业
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="industry_id1"></param>
        /// <param name="industry_id2"></param>
        /// <returns></returns>
        public JsonResult SetIndustry(string access_token, int industry_id1, int industry_id2)
        {
            string url = string.Format("{0}cgi-bin/template/api_set_industry?access_token={1}", baseUrl, access_token);
            return HttpHelper.HttpPost.GetJsonResult<dynamic, JsonResult>(url, new { industry_id1 = industry_id1, industry_id2 = industry_id2 });
        }

        /// <summary>
        /// 获得模板ID
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="template_id_short">模板库中模板的编号，有“TM**”和“OPENTMTM**”等形式 </param>
        /// <returns></returns>
        public AddTemplateResult AddTemplate(string access_token, string template_id_short)
        {
            string url = string.Format("{0}cgi-bin/template/api_set_industry?access_token={1}", baseUrl, access_token);
            return HttpHelper.HttpPost.GetJsonResult<dynamic, AddTemplateResult>(url, new { template_id_short = template_id_short });
        }

        /// <summary>
        /// 发送模板消息
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public SendTemplateMessageResult SendTemplateMessage(string access_token, SendTemplateMessageRequest request)
        {
            string url = string.Format("{0}cgi-bin/template/api_set_industry?access_token={1}", baseUrl, access_token);
            return HttpHelper.HttpPost.GetJsonResult<SendTemplateMessageRequest, SendTemplateMessageResult>(url, request);
        }
        #endregion

        #region 素材管理

        ///// <summary>
        ///// 新增临时素材
        ///// </summary>
        ///// <param name="access_token"></param>
        ///// <param name="type"></param>
        ///// <returns></returns>
        //public UploadMediaResult UploadTempMaterial( string access_token, UploadMediaRequest media)
        //{
        //    string url = string.Format("{0}cgi-bin/media/upload?access_token={1}&type={2}", baseUrl, access_token, media.GetMediaType());
        //    return JsonHelper.Decode<UploadMediaResult>(HttpHelper.HttpPost.GetMediaResult(media.AsWeixinMedia()));
        //}

        ///// <summary>
        ///// 获取临时素材
        ///// </summary>
        ///// <param name="access_token"></param>
        ///// <param name="media_id">媒体ID</param>
        ///// <returns></returns>
        //public GetMediaResult GetTempMaterial( string access_token, string media_id)
        //{
        //    string url = string.Format("{0}cgi-bin/media/get?access_token={1}&media_id={2}}", baseUrl, access_token, media_id);
        //    var data = HttpHelper.HttpGet.GetResult(url);
        //    GetMediaResult result = JsonHelper.Decode<GetMediaResult>(data.Content);
        //    result.Stream = data.Stream;
        //    return result;
        //}

        #endregion

        #region 用户管理-用户分组管理

        /// <summary>
        /// 创建分组
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="name">分组名称</param>
        /// <returns></returns>
        public CreateGroupResult CreateGroup(string access_token, string name)
        {
            string url = string.Format("{0}cgi-bin/groups/create?access_token={1}", baseUrl, access_token);
            return HttpHelper.HttpPost.GetJsonResult<dynamic, CreateGroupResult>(url, new { group = new { name = name } });
        }
        /// <summary>
        /// 修改分组名
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public JsonResult UpdateGroup(string access_token, int id, string name)
        {
            string url = string.Format("{0}cgi-bin/groups/update?access_token={1}", baseUrl, access_token);
            return HttpHelper.HttpPost.GetJsonResult<dynamic, JsonResult>(url, new { group = new { id = id, name = name } });
        }

        /// <summary>
        /// 查询所有分组
        /// </summary>
        /// <param name="access_token"></param>
        /// <returns></returns>
        public GetGroupListResult GetGroupList(string access_token)
        {
            string url = string.Format("{0}cgi-bin/groups/get?access_token={1}", baseUrl, access_token);
            return HttpHelper.HttpGet.GetJsonResult<GetGroupListResult>(url);
        }
        /// <summary>
        /// 查询用户所在分组
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="openId">用户的OpenID </param>
        /// <returns></returns>
        public GetGroupIdByOpenIdResult GetGroupIdByOpenId(string access_token, string openId)
        {
            string url = string.Format("{0}cgi-bin/groups/getid?access_token={1}", baseUrl, access_token);
            return HttpHelper.HttpPost.GetJsonResult<dynamic, GetGroupIdByOpenIdResult>(url, new { openid = openId });
        }

        /// <summary>
        /// 移动用户分组
        /// </summary>
        /// <param name="access_token">调用接口凭证</param>
        /// <param name="openId">用户唯一标识符</param>
        /// <param name="to_groupid">分组id</param>
        /// <returns></returns>
        public JsonResult MoveMemberToGroup(string access_token, string openId, int to_groupid)
        {
            string url = string.Format("{0}cgi-bin/groups/members/update?access_token={1}", baseUrl, access_token);
            return HttpHelper.HttpPost.GetJsonResult<dynamic, JsonResult>(url, new { openid = openId, to_groupid = to_groupid });
        }

        /// <summary>
        /// 批量移动用户分组
        /// </summary>
        /// <param name="access_token">调用接口凭证</param>
        /// <param name="openid_list">用户唯一标识符openid的列表（size不能超过50）</param>
        /// <param name="to_groupid">分组id</param>
        /// <returns></returns>
        public JsonResult MoveMembersToGroup(string access_token, string[] openid_list, int to_groupid)
        {
            string url = string.Format("{0}cgi-bin/groups/members/batchupdate?access_token={1}", baseUrl, access_token);
            return HttpHelper.HttpPost.GetJsonResult<dynamic, JsonResult>(url, new { openid_list = openid_list, to_groupid = to_groupid });
        }
        /// <summary>
        /// 删除分组
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="groupid"></param>
        /// <returns></returns>
        public JsonResult DeleteGroup(string access_token, int groupid)
        {
            string url = string.Format("{0}cgi-bin/groups/delete?access_token={1}", baseUrl, access_token);
            return HttpHelper.HttpPost.GetJsonResult<dynamic, JsonResult>(url, new { group = new { id = groupid } });
        }

        #endregion

        #region 用户管理-设置用户备注名
        /// <summary>
        /// 设置备注名
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="openid"></param>
        /// <param name="remark"></param>
        /// <returns></returns>
        public JsonResult UpdateUserRemark(string access_token, string openid, string remark)
        {
            string url = string.Format("{0}cgi-bin/user/info/updateremark?access_token={1}", baseUrl, access_token);
            return HttpHelper.HttpPost.GetJsonResult<dynamic, JsonResult>(url, new { openid = openid, remark = remark });
        }

        #endregion

        #region 用户管理
        /// <summary>
        /// 获取用户基本信息(UnionID机制)
        /// </summary>
        /// <param name="access_token">调用接口凭证</param>
        /// <param name="openid">普通用户的标识，对当前公众号唯一 </param>
        /// <param name="lang">返回国家地区语言版本，zh_CN 简体，zh_TW 繁体，en 英语</param>
        /// <returns></returns>
        public GetUserInfoResult GetUserInfo(string access_token, string openid, string lang = "zh_CN")
        {
            string url = string.Format("{0}cgi-bin/user/info?access_token={1}&openid={2}&lang={3}", baseUrl, access_token, openid, lang);
            return HttpHelper.HttpGet.GetJsonResult<GetUserInfoResult>(url);
        }

        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="next_openid">拉取列表的后一个用户的OPENID </param>
        /// <returns></returns>
        public GetUserListResult GetUserList(string access_token, string next_openid)
        {
            string url = string.Format("{0}cgi-bin/user/get?access_token={1}&next_openid={2}", baseUrl, access_token, next_openid);
            return HttpHelper.HttpGet.GetJsonResult<GetUserListResult>(url);
        }

        #endregion

        #region 自定义菜单管理

        /// <summary>
        /// 创建自定义菜单
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="menuJsonData">菜单JSON数据</param>
        /// <returns></returns>
        public JsonResult CreateCustomMenu(string access_token, string menuJsonData)
        {
            string url = string.Format("{0}cgi-bin/menu/create?access_token={1}", baseUrl, access_token);
            var result = HttpHelper.HttpPost.GetResult(url, menuJsonData);
            return JsonHelper.Decode<JsonResult>(result);
        }

        /// <summary>
        /// 删除自定义菜单
        /// </summary>
        /// <param name="access_token"></param>
        /// <returns></returns>
        public JsonResult DeleteCustomMenu(string access_token)
        {
            string url = string.Format("{0}cgi-bin/menu/delete?access_token={1}", baseUrl, access_token);
            return HttpHelper.HttpGet.GetJsonResult<JsonResult>(url);
        }

        /// <summary>
        /// 获取自定义菜单
        /// </summary>
        /// <param name="access_token"></param>
        /// <returns></returns>
        public string GetCustomMenu(string access_token)
        {
            string url = string.Format("{0}cgi-bin/menu/get?access_token={1}", baseUrl, access_token);
            var result = HttpHelper.HttpGet.GetResult(url);
            return result.Content;
        }

        #endregion

        #region 账号管理
        /// <summary>
        /// 长链接转短链接接口
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="long_url">需要转换的长链接，支持http://、https://、weixin://wxpay 格式的url</param>
        /// <returns></returns>
        public GetShortUrlResult GetShortUrl(string access_token, string long_url)
        {
            string url = string.Format("{0}cgi-bin/shorturl?access_token={1}", baseUrl, access_token);
            return HttpHelper.Send<dynamic, GetShortUrlResult>(url, new { action = "long2short", long_url = long_url });
        }
        #endregion

        #region 微信网页授权
        /// <summary>
        /// 通过code换取网页授权access_token
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="appSecret"></param>
        /// <param name="code">填写第一步获取的code参数</param>
        /// <param name="grantType">填写为authorization_code</param>
        /// <returns></returns>
        public GetSNSAccessTokenResult GetSNSAccessToken(string appId, string appSecret, string code, string grantType = "authorization_code")
        {
            string url = string.Format("{0}sns/oauth2/access_token?appid={1}&secret={2}&code={3}&grant_type={4}", baseUrl, appId, appSecret, code, grantType);
            return HttpHelper.HttpGet.GetJsonResult<GetSNSAccessTokenResult>(url);
        }

        /// <summary>
        /// 拉取用户信息(需scope为 snsapi_userinfo)
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="openid"></param>
        /// <param name="lang"></param>
        /// <returns></returns>
        public GetSNSUserInfoResult GetSNSUserInfo(string access_token, string openid, string lang = "zh_CN")
        {
            string url = string.Format("{0}sns/userinfo?access_token={1}&openid={2}&lang={3}", baseUrl, access_token, openid, lang);
            return HttpHelper.HttpGet.GetJsonResult<GetSNSUserInfoResult>(url);
        }
        #endregion
    }
}
