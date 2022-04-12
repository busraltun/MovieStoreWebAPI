using Microsoft.EntityFrameworkCore;
using MovieStore.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace MovieStore.Data.ContextConfiguration
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {        
            //Configuration ları haberdar ediyorum
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            /*
              Tek bir tane configuration dosyasını çalıştırmak için;
             modelBuilder.ApplyConfigurationsFromAssembly(new BookConfiguration());
             */
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Movie> Movies {get; set;}
        public DbSet<Director> Directors {get; set;}
        public DbSet<Actor> Actors {get; set;}
        public DbSet<Customer> Customers {get; set;}
        public DbSet<Genre> Genres {get; set;}
        public DbSet<Order> Orders {get; set;}
    }
}
