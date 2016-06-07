using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API.Mp.Open
{
    /// <summary>
    /// 
    /// </summary>
    public class ComponentHelper
    {
        #region Private fields
        private static volatile ComponentHelper _instance = null;
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
        internal static ComponentHelper Instance()
        {
            if (_instance == null)
            {
                lock (lockObject)
                {
                    if (_instance == null)
                    {
                        _instance = new ComponentHelper();
                    }
                }
            }
            return _instance;
        }
        private ComponentHelper() { }
        #endregion
    }
}
