using System;
using System.IO;
using log4net;
using log4net.Config;
using API.Helpers;

namespace API.Logging.Null
{
    /// <summary>
    /// 用log4net实现的LoggerFactoryAdapter
    /// </summary>
    public class NullLoggerFactoryAdapter : ILoggerFactoryAdapter
    {
        //private static bool IsConfigured;
        private static ILogger logger;
        public ILogger GetLogger(string loggerName)
        {
            if (logger == null)
            {
                logger = (ILogger)new NullLogger();
            }
            return logger;
        }
    }
}
