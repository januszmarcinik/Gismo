using System;
using JanuszMarcinik.Mvc.DataSource;

namespace JanuszMarcinik.Mvc.WebUI.Areas.Example.Models.ExampleChildrens
{
    public class ExampleChildDataSource : DataSource<ExampleChildViewModel>
    {
        protected override void SetEditActions()
        {
            foreach (var item in this.Rows)
            {
                item.EditAction = JMap.Example.ExampleChildrens.Edit(item.PrimaryKey);
            }
        }

        protected override void Filter()
        {
        }
    }
}