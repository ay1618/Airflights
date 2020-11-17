﻿// <auto-generated />
using System;
using AirflightsDataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AirflightsDataAccess.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("AirflightsDataAccess.Entities.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Cities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Code = "ALA",
                            Name = "Алматы"
                        },
                        new
                        {
                            Id = 2,
                            Code = "AST",
                            Name = "Астана"
                        },
                        new
                        {
                            Id = 3,
                            Code = "ТОК",
                            Name = "Токио"
                        });
                });

            modelBuilder.Entity("AirflightsDataAccess.Entities.Flight", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("ArrivalTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<long>("Delay")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("DepartureTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("FromCityId")
                        .HasColumnType("int");

                    b.Property<bool>("IsArchive")
                        .HasColumnType("bit");

                    b.Property<string>("RegNum")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("ToCityId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FromCityId");

                    b.HasIndex("RegNum")
                        .IsUnique();

                    b.HasIndex("ToCityId");

                    b.ToTable("Flights");
                });

            modelBuilder.Entity("AirflightsDataAccess.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Login")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("AirflightsDataAccess.Entities.Flight", b =>
                {
                    b.HasOne("AirflightsDataAccess.Entities.City", "FromCity")
                        .WithMany("OutgoingFlights")
                        .HasForeignKey("FromCityId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("AirflightsDataAccess.Entities.City", "ToCity")
                        .WithMany("IncomingFlights")
                        .HasForeignKey("ToCityId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("FromCity");

                    b.Navigation("ToCity");
                });

            modelBuilder.Entity("AirflightsDataAccess.Entities.City", b =>
                {
                    b.Navigation("IncomingFlights");

                    b.Navigation("OutgoingFlights");
                });
#pragma warning restore 612, 618
        }
    }
}
