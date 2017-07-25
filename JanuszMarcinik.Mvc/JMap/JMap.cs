using JanuszMarcinik.Mvc.JMap.Maps.Default;
using JanuszMarcinik.Mvc.JMap.Maps.Example;

namespace JanuszMarcinik.Mvc.JMap
{
    public static class JMap
    {
        public static AreaExample Example { get; } = new AreaExample(nameof(Example));
        public static AreaDefault Default { get; } = new AreaDefault(nameof(Default));
    }
}