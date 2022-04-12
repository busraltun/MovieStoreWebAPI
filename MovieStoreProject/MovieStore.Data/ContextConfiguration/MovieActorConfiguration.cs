using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieStore.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieStore.Data.ContextConfiguration
{
    public class MovieActorConfiguration : IEntityTypeConfiguration<MovieActor>
    {
        public void Configure(EntityTypeBuilder<MovieActor> builder)
        {
            builder.HasKey(ma => new { ma.MovieId, ma.ActorId });
            builder.HasOne(ma => ma.Movie)
                    .WithMany(m => m.Actors)
                    .HasForeignKey(ma => ma.MovieId);
            builder.HasOne(ma => ma.Actor)
                    .WithMany(a => a.Movies)
                    .HasForeignKey(ma => ma.ActorId);

        }
    }
}
