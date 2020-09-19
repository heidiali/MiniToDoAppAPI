using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace MiniProjekti2
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //config.Routes.MapHttpRoute(
            //    name: "ProperApi",
            //    //routeTemplate: "api/{userid}/{task}/{id}",
            //    //defaults: new { userid = "User", action = "Get", id = RouteParameter.Optional }
            //    routeTemplate: "api/taskit/{userid}/{id}",
            //    defaults: new { controller = "Task", action = "Get" }
            //    //defaults: new { id = RouteParameter.Optional }
            //);
        }
    }
}
