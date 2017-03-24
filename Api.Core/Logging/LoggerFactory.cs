
using Api.Core.Logging.Null;

namespace Api.Core.Logging
{
    /// <summary>
    /// 
    /// </summary>
    public static class LoggerFactory
    {
        private static ILoggerFactoryAdapter _loggerFactoryAdapter;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="loggerFactoryAdapter"></param>
        public static void InitializeLogFactory(ILoggerFactoryAdapter loggerFactoryAdapter)
        {
            _loggerFactoryAdapter = loggerFactoryAdapter;
        }

        /// <summary>
        /// 获取logger name为tunynet的 <see cref="Api.Core.Logging.ILogger"/>
        /// </summary>
        /// <returns><see cref="Api.Core.Logging.ILogger"/></returns>
        public static ILogger GetLogger()
        {
            return LoggerFactory.GetLogger("logger");
        }

        /// <summary>
        /// 依据LoggerName获取<see cref="Api.Core.Logging.ILogger"/>
        /// </summary>
        /// <param name="loggerName">日志名称（例如：log4net的logger配置名称）</param>
        /// <returns><see cref="Api.Core.Logging.ILogger"/></returns>
        public static ILogger GetLogger(string loggerName)
        {
            if (_loggerFactoryAdapter == null)
                _loggerFactoryAdapter = new NullLoggerFactoryAdapter();
            return _loggerFactoryAdapter.GetLogger(loggerName);
        }
    }
}
