using System.Collections.Generic;
using System.Web.Mvc;

namespace JanuszMarcinik.Mvc.DataSource
{
    public class GridModel
    {
        public string Title { get; set; }
        public List<CustomPropertyInfo> Properties { get; set; }
        public List<GridRow> Rows { get; set; }
        public ActionResult AddAction { get; set; }
        public ActionResult BackAction { get; set; }
        public ActionResult ListAction { get; set; }
    }
}