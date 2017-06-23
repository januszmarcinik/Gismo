using System.Collections.Generic;
using System.Web.Routing;

namespace JanuszMarcinik.Mvc.Extensions.SiteMap.Controllers.Account
{
    public class ControllerAccount : ControllerMap
    {
        public ControllerAccount(string area, string name, string description) : base(area, name, description)
        {
        }

        public SiteMapAction Register()
        {
            var siteMapAction = new SiteMapAction(this.Area, this.Name, "Register")
            {
                RouteValues = new RouteValueDictionary(this.RouteValues = new Dictionary<string, object>()
                {
                    { "area", this.Area }
                })
            };

            return siteMapAction;
        }
    }
}