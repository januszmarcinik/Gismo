﻿using System;
using JanuszMarcinik.Mvc.DataSource;

namespace JanuszMarcinik.Mvc.WebUI.Areas.Account.Models.Users
{
    public class UserDataSource : DataSource<UserViewModel>
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