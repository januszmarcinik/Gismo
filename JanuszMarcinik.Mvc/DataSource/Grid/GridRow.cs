using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace JanuszMarcinik.Mvc.DataSource
{
    public class GridRow
    {
        public GridRow()
        {
            this.Values = new List<string>();
        }

        public int PrimaryKeyId { get; set; }
        public string ImagePath { get; set; }

        public List<string> Values { get; set; }
        
        public ActionResult GetImageAction { get; set; }

        public string PrimaryKeyName { get; set; }
        public Task<ActionResult> EditActionAsync { get; set; }
    }
}