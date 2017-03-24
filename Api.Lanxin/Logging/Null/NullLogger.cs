using log4net;
using System;

namespace Api.Lanxin.Logging.Null
{
    /// <summary>
    /// 
    /// </summary>
    public class NullLogger : ILogger
    {
        //private ILog _logger;
        /// <summary>
        /// 
        /// </summary>
        internal NullLogger()
        {
            //_logger = log;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="level"></param>
        /// <returns></returns>
        public bool IsEnabled(LogLevel level)
        {
            return false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="level"></param>
        /// <param name="message"></param>
        public void Log(LogLevel level, object message)
        { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="level"></param>
        /// <param name="exception"></param>
        /// <param name="message"></param>
        public void Log(LogLevel level, Exception exception, object message)
        { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="level"></param>
        /// <param name="format"></param>
        /// <param name="args"></param>
        public void Log(LogLevel level, string format, params object[] args)
        { }
    }
}

