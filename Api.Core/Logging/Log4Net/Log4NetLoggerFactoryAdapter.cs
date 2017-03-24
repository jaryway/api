using System;
using System.IO;
using log4net;
using log4net.Config;
using Api.Core.Helpers;

namespace Api.Core.Logging.Log4Net
{
    /// <summary>
    /// 用log4net实现的LoggerFactoryAdapter
    /// </summary>
    public class Log4NetLoggerFactoryAdapter : ILoggerFactoryAdapter
    {
        private static bool IsConfigured;
        private static ILogger logger;

        static Log4NetLoggerFactoryAdapter()
        {
        }

        /// <summary>
        /// 构造函数（默认加载"~/Config/log4net.config"作为log4net配置文件）
        /// </summary>
        public Log4NetLoggerFactoryAdapter()
            : this("~/app_data/log4net.config")
        {

        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="configFilename">
        /// <remarks>
        /// <para>log4net配置文件路径，支持以下格式：</para>
        /// <list type="bullet">
        /// <item> ~/config/log4net.config</item>
        /// <item> ~/web.config</item>
        /// <item>c:\abc\log4net.config</item>
        /// </list>
        /// </remarks>
        /// </param>
        public Log4NetLoggerFactoryAdapter(string configFilename)
        {
            if (Log4NetLoggerFactoryAdapter.IsConfigured)
                return;
            //IRunningEnvironment runningEnvironment = DIContainer.Resolve<IRunningEnvironment>();
            if (string.IsNullOrEmpty(configFilename))
                configFilename = "~/app_data/log4net.config";
            //FileInfo fileInfo = new FileInfo(WebUtility.GetPhysicalFilePath(configFilename));
            FileInfo fileInfo = new FileInfo(configFilename);
            if (!fileInfo.Exists)
                throw new ApplicationException(string.Format("log4net配置文件 {0} 未找到", fileInfo.FullName));
            //if (runningEnvironment.IsFullTrust)
            //    XmlConfigurator.ConfigureAndWatch(fileInfo);
            //else
            //{
            XmlConfigurator.Configure(fileInfo);
            Log4NetLoggerFactoryAdapter.IsConfigured = true;
            //}
        }

        /// <summary>
        /// 依据LoggerName获取
        /// </summary>
        /// <param name="loggerName">日志名称（例如：log4net的logger配置名称）</param>
        /// <returns></returns>
        public ILogger GetLogger(string loggerName)
        {
            if (logger == null)
            {
                logger = (ILogger)new Log4NetLogger(LogManager.GetLogger(loggerName));
            }
            return logger;
        }
    }
}
