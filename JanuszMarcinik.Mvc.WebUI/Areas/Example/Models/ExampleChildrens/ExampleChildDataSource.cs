using JanuszMarcinik.Mvc.Domain.DataSource;
using System.Collections.Generic;

namespace JanuszMarcinik.Mvc.WebUI.Areas.Example.Models.ExampleChildrens
{
    public class ExampleChildDataSource : DataSource<ExampleChildViewModel>
    {
        public int ParentId { get; set; }

        public override void Initialize(IEnumerable<ExampleChildViewModel> model)
        {
            base.Initialize(model);

            this.AddAction = MVC.Example.ExampleChildrens.Create(ParentId);
            this.BackAction = MVC.Example.ExampleParents.List();
            this.SetEditActions(MVC.Example.ExampleChildrens.Edit());

            this.Title = "Chilrens";
        }
    }
}