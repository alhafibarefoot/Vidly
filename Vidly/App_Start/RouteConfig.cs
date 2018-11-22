using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Vidly.Controllers;

namespace Vidly
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");  //this ignore routering anything in debug /obj

            #region NotedRotering
            //routes.MapRoute("Home","",new { controller = "Movies", action = "Index" });  this if you need default http://localhost go to moveie controller and action index method
            //routes.MapRoute("Home","movie",new { controller = "Movies", action = "Index" });  this if you need default http://localhost/movie  

            // var namespacesMovie = new[] { typeof(MoviesController) };  //I used this var if i have same name of controller in different area of project
            // routes.MapRoute("Home", "movie", new { controller = "Movies", action = "Index" },namespacesMovie ); this if you need default http://localhost/movie I used var namespacesMovie

            //routes.MapRoute(
            //     "ReleasedDate",
            //    "{Movies}/{ReleasedDate}/{year}/{month}",
            //    new { controller = "Movies", action = "ReleasedDate" },
            //    new { year = @"\d{4}", month = @"\d{2}" } /*we can put { month="\\d{ 2}" } || { year ={ "2015 | 2016"} }*/
            //);
            #endregion NotedRotering


            routes.MapMvcAttributeRoutes();





            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
