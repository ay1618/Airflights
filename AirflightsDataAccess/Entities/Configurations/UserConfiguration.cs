using AirflightsDomain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AirflightsDataAccess.Entities.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Login).IsRequired().HasMaxLength(20);
            builder.Property(u => u.Password).IsRequired().HasMaxLength(200);
            builder.Property(u => u.Name).HasMaxLength(50);
            builder.HasIndex(u => u.Login).IsUnique();

            //init admin user (only for test presentation)
            builder.HasData(
                new User[] {
                    new User {
                        Id = 1,
                        Name = "Admin",
                        Login = "admin",
                        Password = "AQAAAAEAACcQAAAAEBMDOiXZl57nI8xcAYWpxLzBRP8OlfGCf+EnL9QzPZMpFXt2aLpcO+7ZHhh+hJpusw=="
                    },
                    new User {
                        Id = 2,
                        Name = "Moderator",
                        Login = "moderator",
                        Password = "AQAAAAEAACcQAAAAEIkwxfF9NSVv3tltY7ATSH6RVnrgkm5WpK5WXCjGT2hOopo3t1T41U5gJe62ic/WWQ=="
                    }
                });
        }
    }
}
