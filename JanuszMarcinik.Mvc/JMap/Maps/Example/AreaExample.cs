namespace JanuszMarcinik.Mvc.JMap.Maps.Example
{
    public class AreaExample : AreaMap
    {
        public AreaExample(string areaName) : base(areaName)
        {
            this.ExampleParents = new ControllerExampleParents(areaName, nameof(this.ExampleParents));
        }

        public ControllerExampleParents ExampleParents { get; private set; }
    }
}