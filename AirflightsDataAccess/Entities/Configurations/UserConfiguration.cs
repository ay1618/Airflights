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
            builder.Property(u => u.Name).HasMaxLength(50);
            builder.Property(u => u.Type).IsRequired();
            builder.HasIndex(u => u.Login).IsUnique();
        }
    }
}
