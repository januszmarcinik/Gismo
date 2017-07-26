using JanuszMarcinik.Mvc.DataSource;

namespace JanuszMarcinik.Mvc.WebUI.Areas.Example.Models.ExampleParents
{
    public class ExampleParentDataSource : DataSource<ExampleParentViewModel>
    {
        public string Text { get; set; }

        protected override void SetEditActions()
        {
            foreach (var item in this.Rows)
            {
                item.EditAction = JMap.Example.ExampleParents.Edit(item.PrimaryKeyId);
            }
        }
    }
}