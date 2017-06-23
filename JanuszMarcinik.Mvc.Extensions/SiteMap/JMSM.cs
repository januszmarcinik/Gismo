using JanuszMarcinik.Mvc.Extensions.SiteMap.Areas;

namespace JanuszMarcinik.Mvc.Extensions.SiteMap
{
    /// <summary>
    /// Janusz Marcinik Site Map
    /// </summary>
    public static class JMSM
    {
        public static AreaAccount Account { get; } = new AreaAccount(name: "Account", description: "Konto");
    }
}