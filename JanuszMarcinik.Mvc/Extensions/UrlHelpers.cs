using System.Web.Mvc;

namespace JanuszMarcinik.Mvc
{
    public static class UrlHelpers
    {
        #region Action()
        public static string Action(this UrlHelper urlHelper, ActionMap result)
        {
            return urlHelper.Action(result.ActionName, result.ControllerName, result.RouteValues);
        }
        #endregion
    }
}