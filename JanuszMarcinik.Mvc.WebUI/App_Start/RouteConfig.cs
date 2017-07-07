using System.Web.Mvc;
using System.Web.Routing;

namespace JanuszMarcinik.Mvc.WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default_route",
                url: "{controller}/{action}/{id}",
                defaults: new { area = "Default", controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}