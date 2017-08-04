using System.ComponentModel;

namespace JanuszMarcinik.Mvc.DataSource
{
    public enum PageSize
    {
        [Description("2")]
        Two = 2,

        [Description("5")]
        Five = 5,

        [Description("10")]
        Ten = 10,

        [Description("20")]
        Twenty = 20,

        [Description("50")]
        Fifty = 50,

        [Description("100")]
        Hundred = 100,
    }
}