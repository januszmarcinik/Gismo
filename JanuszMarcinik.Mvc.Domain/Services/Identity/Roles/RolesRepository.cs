using JanuszMarcinik.Mvc.Domain.Models.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using JanuszMarcinik.Mvc.Domain.Data;

namespace JanuszMarcinik.Mvc.Domain.Services.Identity.Roles
{
    public class RolesRepository : RoleStore<Role, int, UserRole>
    {
        public RolesRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}