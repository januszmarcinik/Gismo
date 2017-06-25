using JanuszMarcinik.Mvc.Domain.Models.Identity;
using Microsoft.AspNet.Identity;

namespace JanuszMarcinik.Mvc.Domain.Repositories.Identity
{
    public class ApplicationRoleManager : RoleManager<ApplicationRole, int>
    {
        public ApplicationRoleManager(IRoleStore<ApplicationRole, int> store) : base(store)
        {
        }
    }
}