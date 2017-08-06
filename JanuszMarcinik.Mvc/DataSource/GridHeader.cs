namespace JanuszMarcinik.Mvc.DataSource
{
    public class GridHeader
    {
        public bool IsPrimaryKey { get; set; }
        public bool IsPhotoThumbnailPath { get; set; }

        public string PropertyName { get; set; }
        public string DisplayName { get; set; }
        public int Order { get; set; }
    }
}