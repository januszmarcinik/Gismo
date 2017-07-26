using JanuszMarcinik.Mvc.SiteMap;
using System.Web.Mvc;

namespace JanuszMarcinik.Mvc.WebUI
{
    public class ApplicationController : Controller
    {
        public RedirectToRouteResult RedirectToAction(ActionMap result)
        {
            return RedirectToAction(result.ActionName, result.ControllerName, result.RouteValues);
        }
    }
}