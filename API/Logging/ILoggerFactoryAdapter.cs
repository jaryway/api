using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API.Logging
{
    /// <summary>
    /// 供LoggerFactory使用的适配器接口,适配器用户配置日志记录工具的各项参数
    /// </summary>
    public interface ILoggerFactoryAdapter
    {
        ILogger GetLogger(string loggerName);
    }
}
