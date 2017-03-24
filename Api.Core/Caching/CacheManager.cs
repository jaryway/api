using System;
using System.Runtime.Caching;

namespace Api.Core.Caching
{
    /// <summary>
    /// /
    /// </summary>
    public class CacheManager
    {
        #region Instance
        private static volatile CacheManager _instance = null;
        private static readonly object lockObject = new object();
        private static ObjectCache _cache;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static CacheManager Instance()
        {
            if (_instance == null)
            {
                lock (lockObject)
                {
                    if (_instance == null)
                    {
                        _instance = new CacheManager();
                    }
                }
            }
            return _instance;
        }
        /// <summary>
        /// 
        /// </summary>
        private CacheManager()
        {
        }

        #endregion Instance
        /// <summary>
        /// 
        /// </summary>
        protected ObjectCache Cache
        {
            get
            {
                if (_cache == null)
                {
                    lock (lockObject)
                    {
                        if (_cache == null)
                            _cache = MemoryCache.Default;
                    }
                }
                return _cache;
            }
        }

        /// <summary>
        /// Gets or sets the value associated with the specified key.
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="key">The key of the value to get.</param>
        /// <returns>The value associated with the specified key.</returns>
        public T Get<T>(string key)
        {
            return (T)Cache[key];
        }

        /// <summary>
        /// Adds the specified key and object to the cache.
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="data">Data</param>
        /// <param name="cacheTime">Cache time in Seconds</param>
        public void Set(string key, object data, int cacheTime)
        {
            if (data == null)
                return;

            var policy = new CacheItemPolicy();//绝对过期时间
            policy.AbsoluteExpiration = DateTime.Now + TimeSpan.FromSeconds(cacheTime);
            Cache.Add(new CacheItem(key, data), policy);
        }

        /// <summary>
        /// Removes the value with the specified key from the cache
        /// </summary>
        /// <param name="key">/key</param>
        public void Remove(string key)
        {
            Cache.Remove(key);
        }

    }
}
