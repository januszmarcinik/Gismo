using JanuszMarcinik.Mvc.SiteMap.Maps.Default;
using JanuszMarcinik.Mvc.SiteMap.Maps.Example;
using JanuszMarcinik.Mvc.SiteMap.Maps.Identity;

namespace JanuszMarcinik.Mvc
{
    public static class JMap
    {
        public static AreaIdentity Identity { get; } = new AreaIdentity(nameof(Identity));
        public static AreaExample Example { get; } = new AreaExample(nameof(Example));
        public static AreaDefault Default { get; } = new AreaDefault(nameof(Default));
    }
}