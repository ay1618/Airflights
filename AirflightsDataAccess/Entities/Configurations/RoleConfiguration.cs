using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AirflightsDataAccess.Entities.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(h => h.Id);
            builder.Property(h => h.Code).IsRequired().HasMaxLength(30);
            builder.HasIndex(h => h.Code).IsUnique();
            builder.Property(h => h.Name).IsRequired().HasMaxLength(200);

            builder.HasData(
                new Role[] {
                    new Role { Id = 1, Name = "Admin", Code = "ADM"},
                    new Role { Id = 2, Name = "Moderator", Code = "MOD"},
                    new Role { Id = 3, Name = "User", Code = "USR"}
                });
        }
    }
}
