namespace JanuszMarcinik.Mvc.SiteMap.Maps.Account
{
    public class AreaAccount : AreaMap
    {
        public AreaAccount(string areaName) : base(areaName)
        {
            this.Account = new ControllerAccount(areaName, nameof(this.Account));
            this.Manage = new ControllerManage(areaName, nameof(this.Manage));
        }

        public ControllerAccount Account { get; private set; }
        public ControllerManage Manage { get; private set; }
    }
}