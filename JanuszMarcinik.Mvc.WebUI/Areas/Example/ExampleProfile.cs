using AutoMapper;
using JanuszMarcinik.Mvc.Domain.Models.Examples;
using JanuszMarcinik.Mvc.WebUI.Areas.Example.Models.ExampleChildrens;
using JanuszMarcinik.Mvc.WebUI.Areas.Example.Models.ExampleParents;

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
            CreateMap<ExampleParent, ExampleParentViewModel>()
                .Ignore(x => x.RemovePhoto)
                .Ignore(x => x.Upload);

            CreateMap<ExampleChild, ExampleChildViewModel>();
        }
        #endregion
    }
}