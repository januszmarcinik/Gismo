namespace JanuszMarcinik.Mvc.SiteMap.Maps.Example
{
    public class AreaExample : AreaMap
    {
        public AreaExample(string areaName) : base(areaName)
        {
            this.ExampleParents = new ControllerExampleParents(areaName, nameof(this.ExampleParents));
            this.ExampleChildrens = new ControllerExampleChildrens(areaName, nameof(this.ExampleChildrens));
        }

        public ControllerExampleParents ExampleParents { get; private set; }
        public ControllerExampleChildrens ExampleChildrens { get; private set; }
    }
}