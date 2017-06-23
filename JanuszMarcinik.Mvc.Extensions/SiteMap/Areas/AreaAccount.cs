using JanuszMarcinik.Mvc.Extensions.SiteMap.Controllers.Account;

namespace JanuszMarcinik.Mvc.Extensions.SiteMap.Areas
{
    public class AreaAccount : AreaMap
    {
        public AreaAccount(string name, string description) : base(name, description)
        {
            this.Account = new ControllerAccount(area: name, name: "Account", description: "Konto");
        }

        public ControllerAccount Account { get; private set; }
    }
}