using JanuszMarcinik.Mvc.Domain.DataSource;

namespace JanuszMarcinik.Mvc.WebUI.Areas.Account.Models.Roles
{
    public class RoleDataSource : DataSource<RoleViewModel>
    {
        public RoleDataSource()
        {
            this.AddAction = MVC.Account.Roles.Create();
            this.BackAction = MVC.Account.Users.Index();
            this.EditAction = MVC.Account.Roles.Edit();
        }
    }
}