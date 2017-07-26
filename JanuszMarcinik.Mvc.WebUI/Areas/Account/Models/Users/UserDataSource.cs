using System;
using JanuszMarcinik.Mvc.DataSource;

namespace JanuszMarcinik.Mvc.WebUI.Areas.Account.Models.Users
{
    public class UserDataSource : DataSource<UserViewModel>
    {
        public UserDataSource()
        {
            //this.BackAction = MVC.Example.ExampleParents.List();
            //this.EditAction = MVC.Example.ExampleChildrens.Edit();
        }

        protected override void SetEditActions()
        {
            throw new NotImplementedException();
        }
    }
}