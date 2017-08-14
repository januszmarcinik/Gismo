using JanuszMarcinik.Mvc.Domain.Models.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using JanuszMarcinik.Mvc.Domain.Data;

namespace JanuszMarcinik.Mvc.Domain.Services.Identity.Users
{
    public class UsersRepository : UserStore<User, Role, int, UserLogin, UserRole, UserClaim>
    {
        public UsersRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}