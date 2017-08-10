namespace JanuszMarcinik.Mvc.SiteMap
{
    public abstract class ControllerMap : AreaMap
    {
        public ControllerMap(string areaName, string controllerName) : base (areaName)
        {
            this.ControllerName = controllerName;
        }

        public string ControllerName { get; private set; }

        public ActionMap ActionMapInit()
        {
            return new ActionMap(this.AreaName, this.ControllerName).AddRouteValue("area", this.AreaName);
        }
    }
}