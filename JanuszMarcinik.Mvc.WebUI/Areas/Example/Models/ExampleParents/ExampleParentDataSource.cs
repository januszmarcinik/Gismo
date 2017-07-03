using JanuszMarcinik.Mvc.Domain.DataSource;
using System.Collections.Generic;

namespace JanuszMarcinik.Mvc.WebUI.Areas.Example.Models.ExampleParents
{
    public class ExampleParentDataSource : DataSource<ExampleParentViewModel>
    {
        public override void Initialize(IEnumerable<ExampleParentViewModel> model)
        {
            base.Initialize(model);

            this.AddAction = MVC.Example.ExampleParents.Create();
            this.BackAction = MVC.Example.ExampleParents.List();
            this.SetEditActions(MVC.Example.ExampleParents.Edit());

            this.Title = "Parents";
        }
    }
}