﻿// <auto-generated />
using System;
using AirflightsDataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AirflightsDataAccess.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20201116105553_CitiesAndFKs")]
    partial class CitiesAndFKs
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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
