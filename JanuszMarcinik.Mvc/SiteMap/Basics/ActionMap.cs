using JanuszMarcinik.Mvc.SiteMap;
using System.Web.Routing;

namespace JanuszMarcinik.Mvc
{
    public class ActionMap : ControllerMap
    {
        public ActionMap(string areaName, string controllerName) : base(areaName, controllerName)
        {
            this.RouteValues = new RouteValueDictionary();
        }

        public string ActionName { get; set; }
        public string Title { get; set; }

        public RouteValueDictionary RouteValues { get; private set; }
    }

    public static class ActionMapExtensions
    {
        #region Title()
        public static ActionMap Title(this ActionMap actionMap, string title)
        {
            actionMap.Title = title;
            return actionMap;
        }
        #endregion

        #region Name()
        public static ActionMap Name(this ActionMap actionMap, string actionName)
        {
            actionMap.ActionName = actionName;
            return actionMap;
        }
        #endregion

        #region AddRouteValue()
        public static ActionMap AddRouteValue(this ActionMap actionMap, string key, object value)
        {
            actionMap.RouteValues.Add(key, value);
            return actionMap;
        }
        #endregion
    }
}