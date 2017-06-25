using JanuszMarcinik.Mvc.Domain.Models.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using JanuszMarcinik.Mvc.Domain.Data;

namespace JanuszMarcinik.Mvc.Domain.Repositories.Identity
{
    public class ApplicationUserStore : UserStore<ApplicationUser, ApplicationRole, int, ApplicationUserLogin, ApplicationUserRole, ApplicationUserClaim>
    {
        public ApplicationUserStore(ApplicationDbContext context) : base(context)
        {
        }
    }
}