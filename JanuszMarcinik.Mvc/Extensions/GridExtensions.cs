using JanuszMarcinik.Mvc.DataSource;
using System.Collections.Generic;
using System.Web.Mvc;

namespace JanuszMarcinik.Mvc
{
    public static class GridExtensions
    {
        #region Grid()
        public static MvcHtmlString Grid(this HtmlHelper htmlHelper, UrlHelper urlHelper, List<GridHeader> headers, List<GridRow> rows)
        {
            var table = new TagBuilder("table");
            table.AddCssClass("table");
            table.AddCssClass("table-hover");
            table.AddCssClass("table-bordered");

            #region Headers()
            var thead = new TagBuilder("thead");

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

            thead.InnerHtml = headerRow.ToString();
            #endregion

            #region Rows()
            var tbody = new TagBuilder("tbody");
            tbody.AddCssClass("text-center");

            foreach (var row in rows)
            {
                var tableRow = new TagBuilder("tr");
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

                tbody.InnerHtml += tableRow.ToString();
            }
            #endregion

            table.InnerHtml = thead.ToString() + tbody.ToString();

            return MvcHtmlString.Create(table.ToString());
        }
        #endregion
    }
}