using System.Collections.Generic;

namespace JanuszMarcinik.Mvc.Extensions.SiteMap
{
    public abstract class ControllerMap
    {
        protected string Area { get; private set; }
        protected string Name { get; private set; }
        protected string Description { get; private set; }

        protected Dictionary<string, object> RouteValues { get; set; }

        public ControllerMap(string area, string name, string description)
        {
            this.Area = area;
            this.Name = name;
            this.Description = description;

            this.RouteValues = new Dictionary<string, object>();
        }
    }
}