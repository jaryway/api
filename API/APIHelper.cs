using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API
{
    public class APIHelper : IAPIHelper
    {

        #region Private fields
        private static volatile APIHelper _instance = null;
        private static readonly object lockObject = new object();
        #endregion

        #region Instance
        /// <summary>
        /// 获取单例对象
        /// </summary>
        /// <returns></returns>
        public static APIHelper Instance()
        {
            if (_instance == null)
            {
                lock (lockObject)
                {
                    if (_instance == null)
                    {
                        _instance = new APIHelper();
                    }
                }
            }
            return _instance;
        }
        /// <summary>
        /// 
        /// </summary>
        private APIHelper()
        {
        }

        #endregion Instance
    }
}
