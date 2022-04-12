using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieStore.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieStore.Data.ContextConfiguration
{
    public class ActorConfiguration : IEntityTypeConfiguration<Actor>
    {

        public void Configure(EntityTypeBuilder<Actor> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id)
                   .UseIdentityColumn();
            builder.Property(a => a.Name)
                   .IsRequired()
                   .HasMaxLength(50);
            builder.Property(a => a.LastName)
                   .IsRequired()
                   .HasMaxLength(50);

        }
    }
}
