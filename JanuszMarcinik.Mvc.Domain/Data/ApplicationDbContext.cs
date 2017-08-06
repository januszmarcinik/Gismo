using JanuszMarcinik.Mvc.Domain.Migrations;
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

        public TEntity Get<TEntity>(int id) where TEntity : Entity
        {
            return this.Set<TEntity>().Find(id);
        }

        public void Create<TEntity>(TEntity entity) where TEntity : Entity
        {
            this.Set<TEntity>().Add(entity);
        }

        public void Update<TEntity>(TEntity entity) where TEntity : Entity
        {
            this.Entry(entity).State = EntityState.Modified;
        }

        public void Delete<TEntity>(int id) where TEntity : Entity
        {
            var entity = this.Get<TEntity>(id);
            this.Set<TEntity>().Remove(entity);
        }

        public void Delete<TEntity>(TEntity entity) where TEntity : Entity
        {
            this.Set<TEntity>().Remove(entity);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.AddFromAssembly(GetType().Assembly);
        }
    }
}