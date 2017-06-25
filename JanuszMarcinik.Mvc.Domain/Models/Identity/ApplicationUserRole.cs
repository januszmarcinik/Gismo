using JanuszMarcinik.Mvc.Domain.Data;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace JanuszMarcinik.Mvc.Domain.Models.Identity
{
    [Table("UserRoles", Schema = DbSchemas.Identity)]
    public class ApplicationUserRole : IdentityUserRole<int>
    {
        [Key]
        public int Id { get; set; }
    }

    internal class ApplicationUserRoleEFConfig : EntityTypeConfiguration<ApplicationUserRole>
    {
        public ApplicationUserRoleEFConfig()
        {
            
        }
    }
}