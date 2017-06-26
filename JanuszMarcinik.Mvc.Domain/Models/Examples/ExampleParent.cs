using JanuszMarcinik.Mvc.Domain.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;

namespace JanuszMarcinik.Mvc.Domain.Models.Examples
{
    public class ExampleParent : Entity
    {
        public string Text { get; set; }
        public string LongText { get; set; }

        public ICollection<ExampleChild> Childrens { get; set; }
    }

    internal class ExampleParentConfiguration : EntityTypeConfiguration<ExampleParent>
    {
        public ExampleParentConfiguration()
        {
            this.HasMany(x => x.Childrens)
                .WithRequired(x => x.Parent)
                .HasForeignKey(x => x.ParentId)
                .WillCascadeOnDelete(true);

            this.Property(x => x.Text).HasMaxLength(100);
            this.Property(x => x.LongText).IsMaxLength();

            this.ToTable("ExampleParents", DbSchemas.Example);
        }
    }
}