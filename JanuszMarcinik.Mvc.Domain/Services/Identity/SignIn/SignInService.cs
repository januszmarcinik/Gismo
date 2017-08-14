using JanuszMarcinik.Mvc.Domain.Models.Identity;
using JanuszMarcinik.Mvc.Domain.Services.Identity.Users;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using System.Security.Claims;
using System.Threading.Tasks;

namespace JanuszMarcinik.Mvc.Domain.Services.Identity.SignIn
{
    public class SignInService : SignInManager<User, int>
    {
        public SignInService(UsersService userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(User user)
        {
            return user.GenerateUserIdentityAsync((UsersService)UserManager);
        }

        public static SignInService Create(IdentityFactoryOptions<SignInService> options, IOwinContext context)
        {
            return new SignInService(context.GetUserManager<UsersService>(), context.Authentication);
        }
    }
}