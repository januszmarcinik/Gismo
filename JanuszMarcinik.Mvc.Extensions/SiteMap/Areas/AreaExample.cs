using JanuszMarcinik.Mvc.Extensions.SiteMap.Controllers.Example;

namespace JanuszMarcinik.Mvc.Extensions.SiteMap.Areas
{
    public class AreaExample : AreaMap
    {
        public AreaExample(string name, string description) : base(name, description)
        {
            this.ExampleParents = new ControllerExampleParents(area: name, name: "ExampleParents", description: "ExampleParents");
        }

        public ControllerExampleParents ExampleParents { get; private set; }
    }
}