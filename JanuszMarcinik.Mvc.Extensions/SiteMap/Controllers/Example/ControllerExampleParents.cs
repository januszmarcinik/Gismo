using System.Collections.Generic;
using System.Web.Routing;

namespace JanuszMarcinik.Mvc.Extensions.SiteMap.Controllers.Example
{
    public class ControllerExampleParents : ControllerMap
    {
        public ControllerExampleParents(string area, string name, string description) : base(area, name, description)
        {
        }

        public SiteMapAction List()
        {
            var siteMapAction = new SiteMapAction(this.Area, this.Name, "List")
            {
                RouteValues = new RouteValueDictionary(this.RouteValues = new Dictionary<string, object>()
                {
                    { "area", this.Area }
                })
            };

            return siteMapAction;
        }

        public SiteMapAction Create()
        {
            var siteMapAction = new SiteMapAction(this.Area, this.Name, "Create")
            {
                RouteValues = new RouteValueDictionary(this.RouteValues = new Dictionary<string, object>()
                {
                    { "area", this.Area }
                })
            };

            return siteMapAction;
        }

        public SiteMapAction Edit(int id)
        {
            var siteMapAction = new SiteMapAction(this.Area, this.Name, "Edit")
            {
                RouteValues = new RouteValueDictionary(this.RouteValues = new Dictionary<string, object>()
                {
                    { "area", this.Area },
                    { "id", id }
                })
            };

            return siteMapAction;
        }

        public SiteMapAction Delete(int id)
        {
            var siteMapAction = new SiteMapAction(this.Area, this.Name, "Delete")
            {
                RouteValues = new RouteValueDictionary(this.RouteValues = new Dictionary<string, object>()
                {
                    { "area", this.Area },
                    { "id", id }
                })
            };

            return siteMapAction;
        }
    }
}