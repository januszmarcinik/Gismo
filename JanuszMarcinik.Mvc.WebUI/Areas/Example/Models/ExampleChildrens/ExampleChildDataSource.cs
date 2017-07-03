using JanuszMarcinik.Mvc.Domain.DataSource;

namespace JanuszMarcinik.Mvc.WebUI.Areas.Example.Models.ExampleChildrens
{
    public class ExampleChildDataSource : DataSource<ExampleChildViewModel>
    {
        public ExampleChildDataSource(int parentId)
        {
            this.AddAction = MVC.Example.ExampleChildrens.Create(parentId);
            this.BackAction = MVC.Example.ExampleParents.List();
            this.EditAction = MVC.Example.ExampleChildrens.Edit();

            this.Title = "Chilrens";
        }
    }
}