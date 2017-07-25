namespace JanuszMarcinik.Mvc.JMap
{
    public abstract class AreaMap
    {
        public AreaMap(string areaName)
        {
            this.AreaName = areaName;
        }

        public string AreaName { get; private set; }
    }
}