namespace JanuszMarcinik.Mvc.Domain.DataSource
{
    public class CustomPropertyInfo
    {
        public bool IsPrimaryKey { get; set; } = false;
        public bool IsImagePath { get; set; } = false;

        public string PropertyName { get; set; }
        public string DisplayName { get; set; }
        public int Order { get; set; }
    }
}