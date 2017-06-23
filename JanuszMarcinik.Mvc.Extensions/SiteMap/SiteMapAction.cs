using System.Web.Routing;

namespace JanuszMarcinik.Mvc.Extensions.SiteMap
{
    public class SiteMapAction
    {
        public SiteMapAction(string area, string controller, string action)
        {
            this.Area = area;
            this.Controller = controller;
            this.Action = action;
        }

        public string Area { get; private set; }
        public string Controller { get; private set; }
        public string Action { get; private set; }

        public RouteValueDictionary RouteValues { get; set; }
    }
}