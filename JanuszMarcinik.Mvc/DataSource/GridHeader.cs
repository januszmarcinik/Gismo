namespace JanuszMarcinik.Mvc.DataSource
{
    public class GridHeader
    {
        public bool IsPrimaryKey { get; set; } = false;
        public bool IsImagePath { get; set; } = false;

        public string PropertyName { get; set; }
        public string DisplayName { get; set; }
        public int Order { get; set; }
    }
}