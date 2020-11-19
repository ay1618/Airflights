using AirflightsDomain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AirflightsDataAccess.Entities.Configurations
{
    public class FlightConfiguration : IEntityTypeConfiguration<Flight>
    {
        public void Configure(EntityTypeBuilder<Flight> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.FromCityId).IsRequired();
            builder.Property(x => x.ToCityId).IsRequired();
            builder.Property(x => x.ArrivalTime).IsRequired();
            builder.Property(x => x.DepartureTime).IsRequired();
            builder.Property(x => x.Created).IsRequired();
            builder.Property(x => x.UserId).IsRequired();

            builder.HasOne(f => f.ToCity).WithMany(c => c.IncomingFlights).HasForeignKey(f => f.ToCityId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(f => f.FromCity).WithMany(c => c.OutgoingFlights).HasForeignKey(f => f.FromCityId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
