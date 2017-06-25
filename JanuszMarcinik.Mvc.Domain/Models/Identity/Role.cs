using JanuszMarcinik.Mvc.Domain.Data;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations.Schema;

namespace JanuszMarcinik.Mvc.Domain.Models.Identity
{
    [Table("Roles", Schema = DbSchemas.Identity)]
    public class Role : IdentityRole<int, UserRole>
    {
    }
}