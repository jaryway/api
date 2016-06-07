using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;

namespace API
{
    /// <summary>
    /// Token管理器用于获取和缓存用到的Token，e.g. access_token
    /// </summary>
    public class TokenManager
    {
        #region Instance
        private static volatile TokenManager _instance = null;
        private static readonly object lockObject = new object();
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static TokenManager Instance()
        {
            if (_instance == null)
            {
                lock (lockObject)
                {
                    if (_instance == null)
                    {
                        _instance = new TokenManager();
                    }
                }
            }
            return _instance;
        }
        /// <summary>
        /// 
        /// </summary>
        private TokenManager() { }

        #endregion Instance
    }
}
