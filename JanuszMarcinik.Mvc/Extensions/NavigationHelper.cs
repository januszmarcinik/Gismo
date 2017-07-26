using System.Web.Mvc;

namespace JanuszMarcinik.Mvc
{
    public static class NavigationHelper
    {
        #region Breadcrumbs()
        public static MvcHtmlString Breadcrumbs(this HtmlHelper htmlHelper, UrlHelper urlHelper, params ActionMap[] actions)
        {
            var ol = new TagBuilder("ol");
            ol.AddCssClass("breadcrumb");

            ol.InnerHtml = GetBreadCrumbItem(urlHelper, JMap.Default.Home.Index());

            foreach (var action in actions)
            {
                ol.InnerHtml += GetBreadCrumbItem(urlHelper, action);
            }

            return MvcHtmlString.Create(ol.ToString());
        }
        #endregion

        #region GetBreadCrumbItem()
        private static string GetBreadCrumbItem(UrlHelper urlHelper, ActionMap action)
        {
            var breadcrumbItem = new TagBuilder("li");

            var link = new TagBuilder("a");
            link.MergeAttribute("href", urlHelper.Action(action.ActionName, action.ControllerName, new { area = action.AreaName }));
            link.SetInnerText(action.Title);

            breadcrumbItem.InnerHtml = link.ToString();

            return breadcrumbItem.ToString();
        }
        #endregion
    }
}