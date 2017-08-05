using System;
using JanuszMarcinik.Mvc.DataSource;

namespace JanuszMarcinik.Mvc.WebUI.Areas.Account.Models.Roles
{
    public class RoleDataSource : DataSource<RoleViewModel>
    {
        protected override void Filter()
        {
        }

        protected override void SetEditActions()
        {
            throw new NotImplementedException();
        }
    }
}