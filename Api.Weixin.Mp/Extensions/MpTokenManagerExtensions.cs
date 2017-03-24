using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using API.Caching;
using API.Helpers;
using API.Qy;

namespace API.Mp
{
    /// <summary>
    /// 
    /// </summary>
    public static class MpTokenManagerExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="manager"></param>
        /// <returns></returns>
        public static MpTokenManager Mp(this TokenManager manager)
        {
            return MpTokenManager.Instance();
        }
    }
}
