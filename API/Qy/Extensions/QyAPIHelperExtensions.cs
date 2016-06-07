using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Qy
{
    public static class QyAPIHelperExtensions
    {
        /// <summary>
        /// 获取MpHelper，MpHelper是关于公众号的方法，避免方法名称冲突
        /// </summary>
        /// <param name="helper"></param>
        /// <returns></returns>
        public static IQyHelper Qy(this IAPIHelper helper, APIType type = APIType.Weixin)
        {
            switch (type)
            {
                case APIType.Weixin:
                default:
                    return WeixinQyAPIHelper.Instance();
                case APIType.Dingtalk:
                    return DingtalkQyAPIHelper.Instance();
            }
        }
    }
}
