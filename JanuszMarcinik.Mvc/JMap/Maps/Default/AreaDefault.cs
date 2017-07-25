namespace JanuszMarcinik.Mvc.JMap.Maps.Default
{
    public class AreaDefault : AreaMap
    {
        public AreaDefault(string areaName) : base(areaName)
        {
            this.Home = new ControllerHome(areaName, nameof(this.Home));
        }

        public ControllerHome Home { get; private set; }
    }
}