using AutoMapper;
using JanuszMarcinik.Mvc.Domain.Models.Identity;
using JanuszMarcinik.Mvc.WebUI.Areas.Identity.Models.Roles;
using JanuszMarcinik.Mvc.WebUI.Areas.Identity.Models.Users;

namespace JanuszMarcinik.Mvc.WebUI.Areas.Identity
{
    public class IdentityProfile : Profile
    {
        #region ProfileName
        public override string ProfileName
        {
            get { return this.GetType().FullName; }
        }
        #endregion

        #region IdentityProfile()
        public IdentityProfile()
        {
            CreateMap<Role, RoleViewModel>();

            CreateMap<User, UserViewModel>()
                .Ignore(p => p.SelectedRoles)
                .Ignore(p => p.AllRoles);
        }
        #endregion
    }
}