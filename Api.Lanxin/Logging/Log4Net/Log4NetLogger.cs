using log4net;
using System;

namespace Api.Lanxin.Logging.Log4Net
{
    /// <summary>
    /// 
    /// </summary>
    public class Log4NetLogger : ILogger
    {
        private ILog _logger;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="log"></param>
        internal Log4NetLogger(ILog log)
        {
            _logger = log;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="level"></param>
        /// <returns></returns>
        public bool IsEnabled(LogLevel level)
        {

            switch (level)
            {
                case LogLevel.Debug:
                    return _logger.IsDebugEnabled;

                case LogLevel.Information:
                    return _logger.IsInfoEnabled;

                case LogLevel.Warning:
                    return _logger.IsWarnEnabled;

                case LogLevel.Error:
                    return _logger.IsErrorEnabled;

                case LogLevel.Fatal:
                    return _logger.IsFatalEnabled;
                default:
                    return false;
            }
        }

        /// <summary>
        /// 记录level级别的日志
        /// </summary>
        /// <param name="level">日志级别</param>
        /// <param name="message">需记录的内容</param>
        public void Log(LogLevel level, object message)
        {
            if (!IsEnabled(level))
                return;

            switch (level)
            {
                case LogLevel.Debug:
                    _logger.Debug(message);
                    return;

                case LogLevel.Information:
                    _logger.Info(message);
                    return;

                case LogLevel.Warning:
                    _logger.Warn(message);
                    return;

                case LogLevel.Error:
                    _logger.Error(message);
                    return;

                case LogLevel.Fatal:
                    _logger.Fatal(message);
                    return;
            }
        }

        /// <summary>
        /// 记录level级别的日志
        /// </summary>
        /// <param name="level">日志级别</param>
        /// <param name="exception">异常</param>
        /// <param name="message">需记录的内容</param>
        public void Log(LogLevel level, Exception exception, object message)
        {
            if (!IsEnabled(level))
                return;

            switch (level)
            {
                case LogLevel.Debug:
                    _logger.Debug(message, exception);
                    return;
                case LogLevel.Information:
                    _logger.Info(message, exception);
                    return;
                case LogLevel.Warning:
                    _logger.Warn(message, exception);
                    return;
                case LogLevel.Error:
                    _logger.Error(message, exception);
                    return;
                case LogLevel.Fatal:
                    _logger.Fatal(message, exception);
                    return;
                default:
                    return;
            }
        }

        /// <summary>
        /// 记录level级别的日志
        /// </summary>
        /// <param name="level">日志级别</param>
        /// <param name="format">需记录的内容格式<see cref="M:System.String.Format(System.String,System.Object[])"/></param>
        /// <param name="args">替换format占位符的参数</param>
        public void Log(LogLevel level, string format, params object[] args)
        {
            if (!IsEnabled(level))
                return;
            switch (level)
            {
                case LogLevel.Debug:
                    _logger.DebugFormat(format, args);
                    return;
                case LogLevel.Information:
                    _logger.InfoFormat(format, args);
                    return;
                case LogLevel.Warning:
                    _logger.WarnFormat(format, args);
                    return;
                case LogLevel.Error:
                    _logger.ErrorFormat(format, args);
                    return;
                case LogLevel.Fatal:
                    _logger.FatalFormat(format, args);
                    return;
                default:
                    return;
            }
        }
    }
}

