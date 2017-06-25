using JanuszMarcinik.Mvc.Domain.Models.Examples;
using JanuszMarcinik.Mvc.Domain.Models.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace JanuszMarcinik.Mvc.Domain.Data
{
    public class ApplicationDbContext : IdentityDbContext<User, Role, int, UserLogin, UserRole, UserClaim>
    {
        public ApplicationDbContext() : base("JanuszMarcinikConnection") { }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        #region Example
        public DbSet<ExampleParent> ExampleParents { get; set; }
        public DbSet<ExampleChild> ExampleChildrens { get; set; }
        #endregion

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.AddFromAssembly(GetType().Assembly);
        }
    }
}