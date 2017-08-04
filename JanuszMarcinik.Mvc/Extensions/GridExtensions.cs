using JanuszMarcinik.Mvc.DataSource;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using TwitterBootstrap3;
using TwitterBootstrapMVC.BootstrapMethods;

namespace JanuszMarcinik.Mvc
{
    public static class GridExtensions
    {
        #region GridHeaders()
        public static MvcHtmlString GridHeaders(this HtmlHelper htmlHelper, List<GridHeader> headers)
        {
            var headerRow = new TagBuilder("tr");
            headerRow.AddCssClass("bg-info");

            var enumeratorHead = new TagBuilder("th");
            enumeratorHead.AddCssClass("text-center");
            enumeratorHead.SetInnerText("L/p");

            headerRow.InnerHtml = enumeratorHead.ToString();

            foreach (var header in headers)
            {
                if (header.PropertyName == "Id")
                {
                    continue;
                }

                var propertyHead = new TagBuilder("th");
                propertyHead.AddCssClass("text-center");
                propertyHead.SetInnerText(header.DisplayName);

                headerRow.InnerHtml += propertyHead.ToString();
            }

            return MvcHtmlString.Create(headerRow.ToString());
        }
        #endregion

        #region GridData()
        public static MvcHtmlString GridData(this HtmlHelper htmlHelper, UrlHelper urlHelper, List<GridRow> rows)
        {
            var tableRows = new StringBuilder();

            foreach (var row in rows)
            {
                var tableRow = new TagBuilder("tr");
                tableRow.AddCssClass("text-center");
                tableRow.AddCssClass("clicable-action");
                tableRow.MergeAttribute("data-href", urlHelper.Action(row.EditAction));

                var enumeratorRowData = new TagBuilder("td");
                enumeratorRowData.SetInnerText((rows.IndexOf(row) + 1).ToString());

                tableRow.InnerHtml = enumeratorRowData.ToString();

                foreach (var value in row.Values)
                {
                    var tableRowData = new TagBuilder("td");
                    tableRowData.SetInnerText(value);

                    tableRow.InnerHtml += tableRowData.ToString();
                }

                tableRows.AppendLine(tableRow.ToString());
            }

            return MvcHtmlString.Create(tableRows.ToString());
        }
        #endregion

        #region GridPager()
        public static MvcHtmlString GridPager<TModel>(this HtmlHelper<TModel> htmlHelper, int pageIndex, PageSize pageSize, int totalRows)
        {
            var btnGroup = new TagBuilder("div");
            btnGroup.AddCssClass("btn-group");
            var pagerBuilder = new StringBuilder();
            var bootstrap = new BootstrapBase<TModel>(htmlHelper);

            var pagesCount = (totalRows + (int)pageSize - 1) / (int)pageSize;
            var maxPagerSize = 10;
            if (maxPagerSize > pagesCount)
            {
                maxPagerSize = pagesCount;
            }

            var pages = Enumerable.Range(1, pagesCount).ToList();
            while (pages.Count() > maxPagerSize)
            {
                var activeIndex = pages.IndexOf(pageIndex);

                var startDistance = 0 + activeIndex;
                var endDistance = pages.Count - 1 - activeIndex;
                if (startDistance > endDistance)
                {
                    pages.RemoveAt(0);
                }
                else
                {
                    pages.RemoveAt(pages.Count - 1);
                }
            }

            // First
            pagerBuilder.AppendLine((
                bootstrap.Button()
                    .Text(string.Empty)
                    .PrependIcon(FontAwesome.angle_double_left)
                    .Style(ButtonStyle.Info)
                    .Class("BtnPageIndex")
                    .Value("1")
                    .Disabled(pageIndex == 1)
                as IHtmlString).ToString());

            // Previous
            pagerBuilder.AppendLine((
                bootstrap.Button()
                    .Text(string.Empty)
                    .PrependIcon(FontAwesome.angle_left)
                    .Style(ButtonStyle.Warning)
                    .Class("BtnPageIndex")
                    .Value((pageIndex - 1).ToString())
                    .Disabled(pageIndex == 1)
                as IHtmlString).ToString());

            // Pages
            foreach (var page in pages)
            {
                var buttonStyle = page == pageIndex ? ButtonStyle.Primary : ButtonStyle.Default;

                pagerBuilder.AppendLine((
                    bootstrap.Button()
                    .Text(page.ToString())
                    .Class("BtnPageIndex")
                    .Value(page.ToString())
                    .Style(buttonStyle)
                as IHtmlString).ToString());
            }

            // Next
            pagerBuilder.AppendLine((
                bootstrap.Button()
                    .Text(string.Empty)
                    .PrependIcon(FontAwesome.angle_right)
                    .Style(ButtonStyle.Warning)
                    .Class("BtnPageIndex")
                    .Value((pageIndex + 1).ToString())
                    .Disabled(pageIndex == pagesCount)
                as IHtmlString).ToString());

            // Last
            pagerBuilder.AppendLine((
                bootstrap.Button()
                    .Text(string.Empty)
                    .PrependIcon(FontAwesome.angle_double_right)
                    .Style(ButtonStyle.Info)
                    .Class("BtnPageIndex")
                    .Value(pagesCount.ToString())
                    .Disabled(pageIndex == pagesCount)
                as IHtmlString).ToString());

            btnGroup.InnerHtml = pagerBuilder.ToString();

            return MvcHtmlString.Create(btnGroup.ToString());
        }
        #endregion
    }
}