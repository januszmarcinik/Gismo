using JanuszMarcinik.Mvc.DataSource;

namespace JanuszMarcinik.Mvc.WebUI.Areas.Example.Models.ExampleParents
{
    public class ExampleParentDataSource : DataSource<ExampleParentViewModel>
    {
        public ExampleParentDataSource()
        {
            this.AddAction = MVC.Example.ExampleParents.Create();
            this.BackAction = MVC.Example.ExampleParents.List();
            this.ListAction = MVC.Example.ExampleParents.List();
            this.EditAction = MVC.Example.ExampleParents.Edit();

            this.Title = "Parents";
        }

        public string Text { get; set; }
    }
}