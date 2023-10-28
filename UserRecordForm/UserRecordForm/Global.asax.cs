using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using NLog;
using NLog.Web;

namespace UserRecordForm
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
                /*            Database.SetInitializer<UserRecordForm.Models.UserRecordContext.UserRecordContext >(null);
                 *                LogManager.LoadConfiguration("nlog.config").GetCurrentClassLogger();

            */
            // Initialize NLog

            LogManager.Setup().LoadConfigurationFromFile("nlog1.config").GetCurrentClassLogger();

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            /*var configPath = Server.MapPath("~/nlog1.config");
            NLog.LogManager.Configuration = new NLog.Config.XmlLoggingConfiguration(configPath);*/
        }
    }
}
