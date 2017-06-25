using JanuszMarcinik.Mvc.Domain.Models.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using JanuszMarcinik.Mvc.Domain.Data;

namespace JanuszMarcinik.Mvc.Domain.Repositories.Identity
{
    public class ApplicationUserStore : UserStore<User, Role, int, UserLogin, UserRole, UserClaim>
    {
        public ApplicationUserStore(ApplicationDbContext context) : base(context)
        {

        }
    }
}