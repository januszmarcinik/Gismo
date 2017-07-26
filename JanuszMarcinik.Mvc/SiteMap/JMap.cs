using JanuszMarcinik.Mvc.SiteMap.Maps.Default;
using JanuszMarcinik.Mvc.SiteMap.Maps.Example;

namespace JanuszMarcinik.Mvc
{
    public static class JMap
    {
        public static AreaExample Example { get; } = new AreaExample(nameof(Example));
        public static AreaDefault Default { get; } = new AreaDefault(nameof(Default));
    }
}