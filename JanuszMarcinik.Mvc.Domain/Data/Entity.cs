using System.ComponentModel.DataAnnotations;

namespace JanuszMarcinik.Mvc.Domain.Data
{
    public class Entity
    {
        /// <summary>
        /// Entity primary key
        /// </summary>
        [Key]
        public int Id { get; set; }
    }
}