﻿// <auto-generated />
using System;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230303143312_Add Restroom column")]
    partial class AddRestroomcolumn
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.CarModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Capacity")
                        .HasColumnType("float");

                    b.Property<DateTime>("LastChanged")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastChangedBy")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<double>("RealRange")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("CarModels");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Capacity = 57.5,
                            LastChanged = new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastChangedBy = "DataSeed",
                            Name = "Tesla Model 3",
                            RealRange = 380.0
                        },
                        new
                        {
                            Id = 2,
                            Capacity = 54.0,
                            LastChanged = new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastChangedBy = "DataSeed",
                            Name = "Kia EV6",
                            RealRange = 305.0
                        },
                        new
                        {
                            Id = 3,
                            Capacity = 51.0,
                            LastChanged = new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastChangedBy = "DataSeed",
                            Name = "MG 4",
                            RealRange = 300.0
                        },
                        new
                        {
                            Id = 4,
                            Capacity = 45.0,
                            LastChanged = new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastChangedBy = "DataSeed",
                            Name = "Opel Corsa-e",
                            RealRange = 285.0
                        });
                });

            modelBuilder.Entity("Domain.Entities.Charger", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ChargerSpeedId")
                        .HasColumnType("int");

                    b.Property<int>("StationId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "ChargerSpeedId" }, "IX_Chargers_ChargerSpeedId");

                    b.HasIndex(new[] { "Id" }, "IX_Chargers_Id");

                    b.HasIndex(new[] { "StationId" }, "IX_Chargers_StationId");

                    b.ToTable("Chargers");
                });

            modelBuilder.Entity("Domain.Entities.ChargerSpeed", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Kilowatt")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ChargerSpeeds");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Kilowatt = 11
                        },
                        new
                        {
                            Id = 2,
                            Kilowatt = 22
                        },
                        new
                        {
                            Id = 3,
                            Kilowatt = 50
                        });
                });

            modelBuilder.Entity("Domain.Entities.Reservation", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("ChargerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<decimal?>("TotalAmount")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("UserId", "ChargerId");

                    b.HasIndex(new[] { "ChargerId" }, "IX_Reservations_ChargerId");

                    b.HasIndex(new[] { "Id" }, "IX_Reservations_Id");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("Domain.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("LastChanged")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastChangedBy")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            LastChanged = new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastChangedBy = "DataSeed",
                            Name = "Reader"
                        },
                        new
                        {
                            Id = 2,
                            LastChanged = new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastChangedBy = "DataSeed",
                            Name = "Admin"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Station", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("City")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<TimeSpan?>("CloseTime")
                        .HasColumnType("time");

                    b.Property<bool?>("HasConference")
                        .HasColumnType("bit");

                    b.Property<bool?>("HasPersonel")
                        .HasColumnType("bit");

                    b.Property<bool?>("HasRestaurant")
                        .HasColumnType("bit");

                    b.Property<bool?>("HasRestroom")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastChanged")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastChangedBy")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Latitude")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Longitude")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<TimeSpan?>("OpenTime")
                        .HasColumnType("time");

                    b.Property<string>("ZipCode")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Id" }, "IX_Stations_Id");

                    b.ToTable("Stations");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            LastChanged = new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastChangedBy = "DataSeed",
                            Name = "Stockholm"
                        },
                        new
                        {
                            Id = 2,
                            LastChanged = new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastChangedBy = "DataSeed",
                            Name = "Linköping"
                        },
                        new
                        {
                            Id = 3,
                            LastChanged = new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastChangedBy = "DataSeed",
                            Name = "Jönköping"
                        },
                        new
                        {
                            Id = 4,
                            LastChanged = new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastChangedBy = "DataSeed",
                            Name = "Ljungby"
                        },
                        new
                        {
                            Id = 5,
                            LastChanged = new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastChangedBy = "DataSeed",
                            Name = "Halmstad"
                        });
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("ChangePassword")
                        .HasColumnType("bit");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<byte>("FailedLogins")
                        .HasColumnType("tinyint");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime>("LastChanged")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastChangedBy")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime?>("LockedUntil")
                        .HasColumnType("datetime2");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Email" }, "IX_Users_Email")
                        .IsUnique();

                    b.HasIndex(new[] { "Id" }, "IX_Users_Id")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Domain.Entities.UserCar", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("UserId", "CarId");

                    b.HasIndex(new[] { "CarId" }, "IX_UserCars_CarId");

                    b.ToTable("UserCars");
                });

            modelBuilder.Entity("Domain.Entities.UserRole", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex(new[] { "RoleId" }, "IX_UserRoles_RoleId");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("Domain.Entities.Charger", b =>
                {
                    b.HasOne("Domain.Entities.ChargerSpeed", "ChargerSpeed")
                        .WithMany("Chargers")
                        .HasForeignKey("ChargerSpeedId")
                        .IsRequired();

                    b.HasOne("Domain.Entities.Station", "Station")
                        .WithMany("Chargers")
                        .HasForeignKey("StationId")
                        .IsRequired();

                    b.Navigation("ChargerSpeed");

                    b.Navigation("Station");
                });

            modelBuilder.Entity("Domain.Entities.Reservation", b =>
                {
                    b.HasOne("Domain.Entities.Charger", "Charger")
                        .WithMany("Reservations")
                        .HasForeignKey("ChargerId")
                        .IsRequired();

                    b.HasOne("Domain.Entities.User", "User")
                        .WithMany("Reservations")
                        .HasForeignKey("UserId")
                        .IsRequired();

                    b.Navigation("Charger");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.UserCar", b =>
                {
                    b.HasOne("Domain.Entities.CarModel", "Car")
                        .WithMany("UserCars")
                        .HasForeignKey("CarId")
                        .IsRequired();

                    b.HasOne("Domain.Entities.User", "User")
                        .WithMany("UserCars")
                        .HasForeignKey("UserId")
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.UserRole", b =>
                {
                    b.HasOne("Domain.Entities.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .IsRequired();

                    b.HasOne("Domain.Entities.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.CarModel", b =>
                {
                    b.Navigation("UserCars");
                });

            modelBuilder.Entity("Domain.Entities.Charger", b =>
                {
                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("Domain.Entities.ChargerSpeed", b =>
                {
                    b.Navigation("Chargers");
                });

            modelBuilder.Entity("Domain.Entities.Role", b =>
                {
                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("Domain.Entities.Station", b =>
                {
                    b.Navigation("Chargers");
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Navigation("Reservations");

                    b.Navigation("UserCars");

                    b.Navigation("UserRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
