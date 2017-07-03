using JanuszMarcinik.Mvc.Domain.DataSource;
using System.Collections.Generic;

namespace JanuszMarcinik.Mvc.WebUI.Areas.Account.Models.Users
{
    public class UserDataSource : DataSource<UserViewModel>
    {
        public override void Initialize(IEnumerable<UserViewModel> model)
        {
            this.BackAction = MVC.Example.ExampleParents.List();
            this.SetEditActions(MVC.Example.ExampleChildrens.Edit());

            base.Initialize(model);
        }
    }
}