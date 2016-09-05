using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Horoscope
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

           // routes.MapRoute(
           //    name: "First",
           //    url: "",
           //    defaults: new { controller = "Home", action = "GetDOB", id = UrlParameter.Optional }
           //);

           // routes.MapRoute(
           //     name: "Render",
           //     url: "DisplayHoroscope",
           //     defaults: new { controller = "Home", action = "DisplayHoroscope", id = UrlParameter.Optional }
           // );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "GetDOB", id = UrlParameter.Optional }
            );
        }
    }
}
