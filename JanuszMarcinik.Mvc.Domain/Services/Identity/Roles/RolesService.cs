using JanuszMarcinik.Mvc.Domain.Models.Identity;
using Microsoft.AspNet.Identity;

namespace JanuszMarcinik.Mvc.Domain.Services.Identity.Roles
{
    public class RolesService : RoleManager<Role, int>
    {
        public RolesService(RolesRepository repository) : base(repository)
        {
        }
    }
}