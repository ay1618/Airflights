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
            builder.Property(x => x.RegNum).IsRequired().HasMaxLength(20);
            builder.HasIndex(x => x.RegNum).IsUnique();
            builder.Property(x => x.FromCityId).IsRequired();
            builder.Property(x => x.ToCityId).IsRequired();
            builder.Property(x => x.ArrivalTime).IsRequired();
            builder.Property(x => x.DepartureTime).IsRequired();
            builder.Property(x => x.Created).IsRequired();
            builder.Property(x => x.UserId).IsRequired();
        }
    }
}
