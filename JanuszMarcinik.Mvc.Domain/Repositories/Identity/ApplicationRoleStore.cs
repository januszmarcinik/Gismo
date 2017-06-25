using JanuszMarcinik.Mvc.Domain.Models.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using JanuszMarcinik.Mvc.Domain.Data;

namespace JanuszMarcinik.Mvc.Domain.Repositories.Identity
{
    public class ApplicationRoleStore : RoleStore<ApplicationRole, int, ApplicationUserRole>
    {
        public ApplicationRoleStore(ApplicationDbContext context) : base(context)
        {
        }
    }
}