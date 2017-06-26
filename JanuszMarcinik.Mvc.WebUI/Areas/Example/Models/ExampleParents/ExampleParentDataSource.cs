using JanuszMarcinik.Mvc.Domain.Application.DataSource;
using JanuszMarcinik.Mvc.Extensions.SiteMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JanuszMarcinik.Mvc.WebUI.Areas.Example.Models.ExampleParents
{
    public class ExampleParentDataSource : DataSource<ExampleParentViewModel>
    {
        public ExampleParentDataSource() : base(new ExampleParentViewModel()) { }

        public List<ExampleParentViewModel> ExampleParents { get; set; }

        public override void SetActions()
        {
            base.PrepareData(this.ExampleParents);

            foreach (var row in this.Data)
            {
                row.EditAction = MVC.Account.Roles.Edit(row.PrimaryKeyId);
                row.DeleteAction = MVC.Account.Roles.Delete(row.PrimaryKeyId);
            }

            this.AddAction = MVC.Account.Roles.Create();
            this.BackAction = MVC.Account.Users.Index();
            this.Title = "Role użytkowników";
        }
    }
}