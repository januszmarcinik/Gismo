using JanuszMarcinik.Mvc.Domain.Models.Identity;
using Microsoft.AspNet.Identity;

namespace JanuszMarcinik.Mvc.Domain.Repositories.Identity
{
    public class ApplicationRoleManager : RoleManager<Role, int>
    {
        public ApplicationRoleManager(IRoleStore<Role, int> store) : base(store)
        {
            
        }
    }
}