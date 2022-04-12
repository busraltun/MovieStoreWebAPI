using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieStore.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieStore.Data.ContextConfiguration
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>

    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id)
                   .UseIdentityColumn();
            builder.Property(c => c.CustomerName)
                   .IsRequired()
                   .HasMaxLength(50);
            builder.Property(c => c.CustomerLastName)
                   .IsRequired()
                   .HasMaxLength(50);

        }
    }
}
