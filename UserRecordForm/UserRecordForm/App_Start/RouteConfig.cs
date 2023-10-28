using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace UserRecordForm
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "UserRecord", action = "InsertUser", id = UrlParameter.Optional }
            );
            routes.MapRoute(
              name: "ViewAllUser",
              url: "UserRecord/ViewAll/",
              defaults: new { controller = "UserRecord", action = "ViewAll", id = UrlParameter.Optional }
          );
        }
    }
}
