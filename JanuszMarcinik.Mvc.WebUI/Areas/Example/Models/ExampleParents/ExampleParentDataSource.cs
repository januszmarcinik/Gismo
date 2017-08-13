using System;
using JanuszMarcinik.Mvc.DataSource;
using System.Linq;

namespace JanuszMarcinik.Mvc.WebUI.Areas.Example.Models.ExampleParents
{
    public class ExampleParentDataSource : DataSource<ExampleParentViewModel>
    {
        public string Text { get; set; }
        public string LongText { get; set; }

        protected override void SetEditActions()
        {
            foreach (var item in this.Rows)
            {
                item.EditAction = JMap.Example.ExampleParents.Edit(item.PrimaryKey);
            }
        }

        protected override void Filter()
        {
            if (this.Text.IsNotNullOrEmpty())
            {
                this.Data = this.Data
                    .Where(x => x.Text.IsNotNullOrEmpty())
                    .Where(x => x.Text.ToLower().Contains(this.Text.ToLower()));
            }

            if (this.LongText.IsNotNullOrEmpty())
            {
                this.Data = this.Data
                    .Where(x => x.LongText.IsNotNullOrEmpty())
                    .Where(x => x.LongText.ToLower().Contains(this.LongText.ToLower()));
            }
        }
    }
}