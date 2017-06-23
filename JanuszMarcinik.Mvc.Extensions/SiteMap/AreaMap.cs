namespace JanuszMarcinik.Mvc.Extensions.SiteMap
{
    public abstract class AreaMap
    {
        public string Name { get; private set; }
        public string Description { get; private set; }

        public AreaMap(string name, string description)
        {
            this.Name = name;
            this.Description = description;
        }
    }
}