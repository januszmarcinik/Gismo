using JanuszMarcinik.Mvc.Domain.Data;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace JanuszMarcinik.Mvc.Domain.Models.Identity
{
    [Table("UserLogins", Schema = DbSchemas.Identity)]
    public class UserLogin : IdentityUserLogin<int>
    {
        [Key]
        public int Id { get; set; }
    }

    internal class ApplicationUserLoginEFConfig : EntityTypeConfiguration<UserLogin>
    {
        public ApplicationUserLoginEFConfig()
        {

        }
    }
}