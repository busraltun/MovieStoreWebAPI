using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieStore.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieStore.Data.ContextConfiguration
{
    public class DirectorConfiguration : IEntityTypeConfiguration<Director>
    {
        public void Configure(EntityTypeBuilder<Director> builder)
        {
            builder.HasKey(d => d.Id);
            builder.Property(d => d.Id)
                   .UseIdentityColumn();
            builder.Property(d => d.Name)
                   .IsRequired()
                   .HasMaxLength(50);
            builder.Property(a => a.LastName)
                   .IsRequired()
                   .HasMaxLength(50);
        }
    }
}
