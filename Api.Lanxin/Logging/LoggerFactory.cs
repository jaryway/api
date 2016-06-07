
using Api.Lanxin.Logging.Null;

namespace Api.Lanxin.Logging
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
        /// 获取logger
        /// </summary>
        /// <returns>/</returns>
        public static ILogger GetLogger()
        {
            return LoggerFactory.GetLogger("logger");
        }

        /// <summary>
        /// 依据LoggerName获取
        /// </summary>
        /// <param name="loggerName">日志名称（例如：log4net的logger配置名称）</param>
        /// <returns>/</returns>
        public static ILogger GetLogger(string loggerName)
        {
            if (_loggerFactoryAdapter == null)
                _loggerFactoryAdapter = new NullLoggerFactoryAdapter();
            return _loggerFactoryAdapter.GetLogger(loggerName);
        }
    }
}
