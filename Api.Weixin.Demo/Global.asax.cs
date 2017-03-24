using Api.Core.Logging;
using Api.Core.Logging.Log4Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Api.Weixin.Demo
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            //为了调试方便加入日志，否则启用NullLogger
            LoggerFactory.InitializeLogFactory(new Log4NetLoggerFactoryAdapter(Server.MapPath("~/app_data/log4net.config")));
            LoggerFactory.GetLogger().Debug("站点启动");
        }
    }
}
