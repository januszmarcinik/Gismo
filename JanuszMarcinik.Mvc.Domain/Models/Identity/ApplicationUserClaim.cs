using JanuszMarcinik.Mvc.Domain.Data;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations.Schema;

namespace JanuszMarcinik.Mvc.Domain.Models.Identity
{
    [Table("UserClaims", Schema = DbSchemas.Identity)]
    public class ApplicationUserClaim : IdentityUserClaim<int>
    {
    }
}