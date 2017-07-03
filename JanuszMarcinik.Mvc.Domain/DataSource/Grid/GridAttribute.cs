using System;

namespace JanuszMarcinik.Mvc.Domain.DataSource
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class GridAttribute : Attribute
    {
        public int Order { get; set; }
        public bool IsImage { get; set; }
    }
}