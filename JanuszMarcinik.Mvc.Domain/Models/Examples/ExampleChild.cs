using JanuszMarcinik.Mvc.Domain.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JanuszMarcinik.Mvc.Domain.Models.Examples
{
    public class ExampleChild : Entity
    {
        public string Name { get; set; }

        public int ParentId { get; set; }
        public ExampleParent Parent { get; set; }
    }

    internal class ExampleChildConfiguration : EntityTypeConfiguration<ExampleChild>
    {
        public ExampleChildConfiguration()
        {
            this.Property(x => x.Name).HasMaxLength(100);

            this.ToTable("ExampleChildrens", DbSchemas.Example);
        }
    }
}