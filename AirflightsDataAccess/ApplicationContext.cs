using AirflightsDataAccess.Entities;
using AirflightsDataAccess.Entities.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AirflightsDataAccess
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options)
            : base(options)
        {
            Database.Migrate();
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder builder)
        //{
        //    builder.UseNpgsql("Host=localhost;Port=5432;Database=firstEfDb;Username=postgres;Password=Zere707Z");
        //}

        protected override void OnModelCreating(ModelBuilder mBuilder)
        {
            //base.OnModelCreating(mBuilder);
            mBuilder.ApplyConfiguration(new FlightConfiguration());
            mBuilder.ApplyConfiguration(new CityConfiguration());
        }

        public DbSet<Flight> Flights { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
