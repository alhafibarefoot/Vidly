using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Vidly
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                 "ReleasedDate",
                "{Movies}/{ReleasedDate}/{year}/{month}",
                new { controller = "Movies", action = "ReleasedDate" },
                new { year = @"\d{4}", month = @"\d{2}" } /*we can put { month="\\d{ 2}" } || { year ={ "2015 | 2016"} }*/
            );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
