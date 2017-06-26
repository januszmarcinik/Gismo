using AutoMapper;
using JanuszMarcinik.Mvc.Domain.Models.Examples;
using JanuszMarcinik.Mvc.WebUI.Areas.Example.Models.ExampleParents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JanuszMarcinik.Mvc.WebUI.Areas.Example
{
    public class ExampleProfile : Profile
    {
        #region ProfileName
        public override string ProfileName
        {
            get { return this.GetType().FullName; }
        }
        #endregion

        #region ExampleProfile()
        public ExampleProfile()
        {
            CreateMap<ExampleParent, ExampleParentViewModel>();
        }
        #endregion
    }
}