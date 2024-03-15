﻿// <auto-generated />
using System;
using CPRO2211_Assignment_3_Trips_Log_Application.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CPRO2211_Assignment_3_Trips_Log_Application.Migrations
{
    [DbContext(typeof(TripContext))]
    partial class TripContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CPRO2211_Assignment_3_Trips_Log_Application.Models.Trip", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Accommodation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AccommodationEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AccommodationPhone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Destination")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ThingsToDo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Trips");

                    b.HasData(
                        new
                        {
                            Id = -1,
                            Accommodation = "DisneyLand Hotel",
                            AccommodationEmail = "Hotels@DisneyLand.com",
                            AccommodationPhone = "714-781-4636",
                            Destination = "Disney Land",
                            EndDate = new DateTime(2024, 3, 21, 17, 52, 50, 658, DateTimeKind.Local).AddTicks(4604),
                            StartDate = new DateTime(2024, 3, 14, 17, 52, 50, 658, DateTimeKind.Local).AddTicks(4554),
                            ThingsToDo = "[\"Ride the rides\",\"See the mascots\",\"Eat food\"]"
                        },
                        new
                        {
                            Id = -2,
                            Accommodation = "Evil DisneyLand Hotel",
                            AccommodationEmail = "Hotels@EvilDisneyLand.com",
                            AccommodationPhone = "636-418-7417",
                            Destination = "Evil Disney Land",
                            EndDate = new DateTime(2024, 3, 31, 17, 52, 50, 658, DateTimeKind.Local).AddTicks(4626),
                            StartDate = new DateTime(2024, 3, 24, 17, 52, 50, 658, DateTimeKind.Local).AddTicks(4623),
                            ThingsToDo = "[\"Ride the evil rides\",\"See the evil mascots\",\"Eat evil food\"]"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
