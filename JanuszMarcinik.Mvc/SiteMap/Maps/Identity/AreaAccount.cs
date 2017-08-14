namespace JanuszMarcinik.Mvc.SiteMap.Maps.Identity
{
    public class AreaIdentity : AreaMap
    {
        public AreaIdentity(string areaName) : base(areaName)
        {
            this.Account = new ControllerAccount(areaName, nameof(this.Account));
            this.Manage = new ControllerManage(areaName, nameof(this.Manage));
        }

        public ControllerAccount Account { get; private set; }
        public ControllerManage Manage { get; private set; }
    }
}