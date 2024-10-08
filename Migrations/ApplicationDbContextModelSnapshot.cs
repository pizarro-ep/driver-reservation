﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Transport.Models;

#nullable disable

namespace Transport.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.7");

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Transport.Models.ApplicationRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Transport.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<TimeSpan>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Transport.Models.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<float>("Amount")
                        .HasColumnType("REAL");

                    b.Property<TimeSpan>("PaymentDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("PaymentMethod")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ReservationID")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ReservationID")
                        .IsUnique();

                    b.ToTable("Tbl_Payments", (string)null);
                });

            modelBuilder.Entity("Transport.Models.Person", b =>
                {
                    b.Property<string>("Dni")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Surnames")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("UserID")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Dni");

                    b.HasIndex("UserID")
                        .IsUnique();

                    b.ToTable("Tbl_Persons", (string)null);
                });

            modelBuilder.Entity("Transport.Models.Reservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClientID")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<TimeSpan>("ReservationDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("ScheduleID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SeatNumber")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ClientID");

                    b.HasIndex("ScheduleID");

                    b.ToTable("Tbl_Reservations", (string)null);
                });

            modelBuilder.Entity("Transport.Models.Road", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<float>("Distance")
                        .HasColumnType("REAL");

                    b.Property<string>("EndLocation")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<TimeSpan>("EstimatedDuration")
                        .HasColumnType("TEXT");

                    b.Property<string>("StartLocation")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Tbl_Roads", (string)null);
                });

            modelBuilder.Entity("Transport.Models.Schedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<TimeSpan>("ArrivalTime")
                        .HasColumnType("TEXT");

                    b.Property<TimeSpan>("DepartureTime")
                        .HasColumnType("TEXT");

                    b.Property<int>("RoadID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("VehicleID")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("RoadID");

                    b.HasIndex("VehicleID");

                    b.ToTable("Tbl_Schedules", (string)null);
                });

            modelBuilder.Entity("Transport.Models.Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Capacity")
                        .HasColumnType("INTEGER");

                    b.Property<string>("DriverID")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("License")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("DriverID");

                    b.ToTable("Tbl_Vehicles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Transport.Models.ApplicationRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Transport.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Transport.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Transport.Models.ApplicationRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Transport.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Transport.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Transport.Models.Payment", b =>
                {
                    b.HasOne("Transport.Models.Reservation", "Reservations")
                        .WithOne("Payment")
                        .HasForeignKey("Transport.Models.Payment", "ReservationID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("Transport.Models.Person", b =>
                {
                    b.HasOne("Transport.Models.ApplicationUser", "Users")
                        .WithOne("Persons")
                        .HasForeignKey("Transport.Models.Person", "UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Users");
                });

            modelBuilder.Entity("Transport.Models.Reservation", b =>
                {
                    b.HasOne("Transport.Models.Person", "Clients")
                        .WithMany("Reservations")
                        .HasForeignKey("ClientID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Transport.Models.Schedule", "Schedules")
                        .WithMany("Reservations")
                        .HasForeignKey("ScheduleID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Clients");

                    b.Navigation("Schedules");
                });

            modelBuilder.Entity("Transport.Models.Schedule", b =>
                {
                    b.HasOne("Transport.Models.Road", "Roads")
                        .WithMany("Schedules")
                        .HasForeignKey("RoadID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Transport.Models.Vehicle", "Vehicles")
                        .WithMany("Schedules")
                        .HasForeignKey("VehicleID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Roads");

                    b.Navigation("Vehicles");
                });

            modelBuilder.Entity("Transport.Models.Vehicle", b =>
                {
                    b.HasOne("Transport.Models.Person", "Drivers")
                        .WithMany("Vehicles")
                        .HasForeignKey("DriverID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Drivers");
                });

            modelBuilder.Entity("Transport.Models.ApplicationUser", b =>
                {
                    b.Navigation("Persons");
                });

            modelBuilder.Entity("Transport.Models.Person", b =>
                {
                    b.Navigation("Reservations");

                    b.Navigation("Vehicles");
                });

            modelBuilder.Entity("Transport.Models.Reservation", b =>
                {
                    b.Navigation("Payment");
                });

            modelBuilder.Entity("Transport.Models.Road", b =>
                {
                    b.Navigation("Schedules");
                });

            modelBuilder.Entity("Transport.Models.Schedule", b =>
                {
                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("Transport.Models.Vehicle", b =>
                {
                    b.Navigation("Schedules");
                });
#pragma warning restore 612, 618
        }
    }
}
