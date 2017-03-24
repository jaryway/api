
using System;

namespace Api.Core.Logging
{
    /// <summary>
    /// 系统日志接口(日志记录的API)
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// 检查level级别的日志是否启用
        /// </summary>
        /// <param name="level">日志级别<seealso cref="Api.Core.Logging.LogLevel"/></param>
        /// <returns>如果启用返回true，否则返回false</returns>
        bool IsEnabled(LogLevel level);
        /// <summary>
        /// 记录level级别的日志
        /// </summary>
        /// <param name="level">日志级别<seealso cref="Api.Core.Logging.LogLevel"/></param>
        /// <param name="message">需记录的内容</param>
        void Log(LogLevel level, object message);
        /// <summary>
        /// 记录level级别的日志
        /// </summary>
        /// <param name="level">日志级别<seealso cref="Api.Core.Logging.LogLevel"/></param>
        /// <param name="exception">异常</param>
        /// <param name="message">需记录的内容</param>
        void Log(LogLevel level, Exception exception, object message);
        /// <summary>
        /// 记录level级别的日志
        /// </summary>
        /// <param name="level">日志级别<seealso cref="Api.Core.Logging.LogLevel"/></param>
        /// <param name="format">需记录的内容格式<see cref="M:System.String.Format(System.String,System.Object[])"/></param>
        /// <param name="args">替换format占位符的参数</param>
        void Log(LogLevel level, string format, params object[] args);
    }
}

