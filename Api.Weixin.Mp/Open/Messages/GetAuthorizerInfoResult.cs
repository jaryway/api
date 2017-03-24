using Api.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Api.Weixin.Mp.Open
{
    /// <summary>
    /// 
    /// </summary>
    public class GetAuthorizerInfoResult : JsonResult
    {
        /// <summary>
        /// 
        /// </summary>
        public authorizerInfo authorizer_info { get; set; }

        /// <summary>
        /// 二维码图片的URL，开发者最好自行也进行保存
        /// </summary>
        public string qrcode_url { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public authorizationInfo authorization_info { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public class authorizerInfo
        {
            /// <summary>
            /// 
            /// </summary>
            public string nick_name { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string head_img { get; set; }
            /// <summary>
            /// 授权方公众号类型，0代表订阅号，1代表由历史老帐号升级后的订阅号，2代表服务号
            /// </summary>
            public string service_type_info { get; set; }
            /// <summary>
            /// 授权方认证类型，-1代表未认证，0代表微信认证，1代表新浪微博认证，2代表腾讯微博认证，3代表已资质认证通过但还未通过名称认证，4代表已资质认证通过、还未通过名称认证，但通过了新浪微博认证，5代表已资质认证通过、还未通过名称认证，但通过了腾讯微博认证
            /// </summary>
            public string verify_type_info { get; set; }
            /// <summary>
            /// 授权方公众号的原始ID
            /// </summary>
            public string user_name { get; set; }
            /// <summary>
            /// 授权方公众号所设置的微信号，可能为空
            /// </summary>
            public string alias { get; set; }

        }
        /// <summary>
        /// 授权信息
        /// </summary>
        public class authorizationInfo
        {
            /// <summary>
            /// 授权方appid
            /// </summary>
            public string appid { get; set; }
            /// <summary>
            /// 公众号授权给开发者的权限集列表
            /// </summary>
            public IList<funcscope_category> func_info { get; set; }

        }
        /// <summary>
        /// 授权方公众号类型
        /// </summary>
        public class service_type_info
        {
            /// <summary>
            /// 
            /// </summary>
            public int id { get; set; }
        }

        /// <summary>
        /// 授权方认证类型
        /// </summary>
        public class verify_type_info
        {
            /// <summary>
            /// 
            /// </summary>
            public int id { get; set; }
        }
    }
}
