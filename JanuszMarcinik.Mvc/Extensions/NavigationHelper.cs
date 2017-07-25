using JanuszMarcinik.Mvc.JMap;
using System.Text;
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

            var elements = new StringBuilder();

            foreach (var action in actions)
            {
                var breadcrumbItem = new TagBuilder("li");

                var link = new TagBuilder("a");
                link.MergeAttribute("href", urlHelper.Action(action.ActionName, action.ControllerName, new { area = action.AreaName }));
                link.SetInnerText(action.Title);

                breadcrumbItem.InnerHtml = link.ToString();

                elements.AppendLine(breadcrumbItem.ToString());
            }

            ol.InnerHtml = elements.ToString();

            return MvcHtmlString.Create(ol.ToString());
        }
        #endregion
    }
}