using AirflightsDomain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AirflightsDataAccess.Entities.Configurations
{
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(x => x.Code).IsRequired().HasMaxLength(3);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(30);

            builder.HasData(
                new City[] {
                    new City { Id = 1, Name = "Алматы", Code = "ALA"},
                    new City { Id = 2, Name = "Астана", Code = "AST"},
                    new City { Id = 3, Name = "Токио", Code = "ТОК"},
                    new City { Id = 4, Name = "Сеул", Code = "SEU"}
                });
        }
    }
}
