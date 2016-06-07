using log4net;
using System;

namespace API.Logging.Null
{
    public class NullLogger : ILogger
    {
        //private ILog _logger;

        internal NullLogger()
        {
            //_logger = log;
        }

        public bool IsEnabled(LogLevel level)
        {
            return false;
        }

        public void Log(LogLevel level, object message)
        { }

        public void Log(LogLevel level, Exception exception, object message)
        { }

        public void Log(LogLevel level, string format, params object[] args)
        { }
    }
}

