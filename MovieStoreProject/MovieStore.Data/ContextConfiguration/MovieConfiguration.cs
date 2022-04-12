using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieStore.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieStore.Data.ContextConfiguration
{
    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id)
                   .UseIdentityColumn();
            builder.Property(m => m.MovieName)
                   .IsRequired()
                   .HasMaxLength(200);
            builder.Property(m => m.Price)
                   .IsRequired()
                   .HasColumnType("decimal(18,2)");
           
        }
    }
}
