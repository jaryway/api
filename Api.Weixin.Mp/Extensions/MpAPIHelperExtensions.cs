using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using API.Helpers;

namespace API.Mp
{
    /// <summary>
    /// 
    /// </summary>
    public static class MpAPIHelperExtensions
    {
        /// <summary>
        /// 获取MpHelper，MpHelper是关于公众号的方法，避免方法名称冲突
        /// </summary>
        /// <param name="helper"></param>
        /// <returns></returns>
        public static MpHelper Mp(this APIHelper helper)
        {
            return MpHelper.Instance();
        }
    }
}
