using System.Collections.Generic;

namespace JanuszMarcinik.Mvc.DataSource
{
    public class GridRow
    {
        public GridRow()
        {
            this.Values = new List<string>();
        }

        public int PrimaryKeyId { get; set; }
        public string PhotoThumbnailPath { get; set; }
        public List<string> Values { get; set; }
        public ActionMap EditAction { get; set; }
    }
}