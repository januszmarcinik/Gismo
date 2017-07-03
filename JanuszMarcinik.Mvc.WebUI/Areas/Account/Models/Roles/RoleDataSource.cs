using JanuszMarcinik.Mvc.Domain.DataSource;
using System.Collections.Generic;

namespace JanuszMarcinik.Mvc.WebUI.Areas.Account.Models.Roles
{
    public class RoleDataSource : DataSource<RoleViewModel>
    {
        public override void Initialize(IEnumerable<RoleViewModel> model)
        {
            this.AddAction = MVC.Account.Roles.Create();
            this.BackAction = MVC.Account.Users.Index();
            this.SetEditActions(MVC.Account.Roles.Edit());

            base.Initialize(model);
        }
    }
}