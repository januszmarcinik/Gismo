using JanuszMarcinik.Mvc.Domain.DataSource.Grid;
using System.Collections.Generic;
using System.Linq;

namespace JanuszMarcinik.Mvc.Domain.DataSource
{
    public class CustomPropertyInfo
    {
        public bool IsPrimaryKey { get; set; } = false;
        public bool IsImagePath { get; set; } = false;

        public string PropertyName { get; set; }
        public string DisplayName { get; set; }
        public int Order { get; set; }

        public bool IsOrderByAsc { get; set; }
        public bool IsOrderByDesc { get; set; }
    }

    public static class CustomPropertyInfoExtensions
    {
        public static void SetSorting(this List<CustomPropertyInfo> properties, string orderBy, GridSortOrder sortOrder)
        {
            var propertyOrderBy = properties.FirstOrDefault(x => x.PropertyName == orderBy);
            if (sortOrder == GridSortOrder.ASC)
            {
                propertyOrderBy.IsOrderByAsc = true;
            }
            else
            {
                propertyOrderBy.IsOrderByDesc = true;
            }
        }
    }
}