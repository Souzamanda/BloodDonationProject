﻿// <auto-generated />
using System;
using BloodDonationProject.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BloodDonationProject.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20220330192725_AddedDefaultRoles")]
    partial class AddedDefaultRoles
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.15")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BloodDonationProject.Data.ApiUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("BloodDonationProject.Data.Donation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BloodType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Date")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HospitalId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HospitalId");

                    b.HasIndex("UserId");

                    b.ToTable("Donations");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BloodType = "O-",
                            Date = "21-Mar-2022",
                            HospitalId = 10,
                            Status = "Available",
                            UserId = 2
                        },
                        new
                        {
                            Id = 2,
                            BloodType = "O+",
                            Date = "15-Mar-2022",
                            HospitalId = 9,
                            Status = "Not Available",
                            UserId = 4
                        },
                        new
                        {
                            Id = 3,
                            BloodType = "A-",
                            Date = "22-Mar-2022",
                            HospitalId = 8,
                            Status = "Available",
                            UserId = 6
                        },
                        new
                        {
                            Id = 4,
                            BloodType = "A+",
                            Date = "15-Mar-2022",
                            HospitalId = 7,
                            Status = "Not Available",
                            UserId = 8
                        },
                        new
                        {
                            Id = 5,
                            BloodType = "B-",
                            Date = "15-Mar-2022",
                            HospitalId = 6,
                            Status = "Not Available",
                            UserId = 10
                        },
                        new
                        {
                            Id = 6,
                            BloodType = "B+",
                            Date = "13-Mar-2022",
                            HospitalId = 5,
                            Status = "Not Available",
                            UserId = 1
                        },
                        new
                        {
                            Id = 7,
                            BloodType = "AB-",
                            Date = "22-Mar-2022",
                            HospitalId = 4,
                            Status = "Available",
                            UserId = 3
                        },
                        new
                        {
                            Id = 8,
                            BloodType = "AB+",
                            Date = "21-Mar-2022",
                            HospitalId = 3,
                            Status = "Available",
                            UserId = 5
                        },
                        new
                        {
                            Id = 9,
                            BloodType = "AB+",
                            Date = "19-Mar-2022",
                            HospitalId = 2,
                            Status = "Available",
                            UserId = 7
                        },
                        new
                        {
                            Id = 10,
                            BloodType = "O-",
                            Date = "15-Mar-2022",
                            HospitalId = 1,
                            Status = "Not Available",
                            UserId = 9
                        });
                });

            modelBuilder.Entity("BloodDonationProject.Data.Hospital", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Hospitals");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "200 Elizabeth St.",
                            Name = "Toronto General Hospital",
                            Phone = "(416)340-3131"
                        },
                        new
                        {
                            Id = 2,
                            Address = "399 Bathurst St.",
                            Name = "Toronto Western Hospital",
                            Phone = "(416)603-2591"
                        },
                        new
                        {
                            Id = 3,
                            Address = "2075 Bayview Ave.",
                            Name = "Sunnybrook Health Sciences Centre",
                            Phone = "(416)480-6100"
                        },
                        new
                        {
                            Id = 4,
                            Address = "600 University Ave.",
                            Name = "Mount Sinai Hospital",
                            Phone = "(416)596-4200"
                        },
                        new
                        {
                            Id = 5,
                            Address = "36 Queen St. E",
                            Name = "Saint Michael's Hospital",
                            Phone = "(416)360-4000"
                        },
                        new
                        {
                            Id = 6,
                            Address = "76 Grenville St.",
                            Name = "Women's College Hospital",
                            Phone = "(416)323-6400"
                        },
                        new
                        {
                            Id = 7,
                            Address = "555 University Ave.",
                            Name = "The Hospital for Sick Children",
                            Phone = "(416)813-1500"
                        },
                        new
                        {
                            Id = 8,
                            Address = "36 Grenville St.",
                            Name = "St Regis Hospital",
                            Phone = "(647)491-0642"
                        },
                        new
                        {
                            Id = 9,
                            Address = "1 Bridgepoint Dr.",
                            Name = "Bridgepoint Hospital",
                            Phone = "(416)461-8252"
                        },
                        new
                        {
                            Id = 10,
                            Address = "610 University Ave.",
                            Name = "Princess Margaret Cancer Centre",
                            Phone = "(416)946-2000"
                        });
                });

            modelBuilder.Entity("BloodDonationProject.Data.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("age")
                        .HasColumnType("int");

                    b.Property<string>("firstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("sex")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            address = "3578 Yonge St.",
                            age = 34,
                            firstName = "Toby",
                            lastName = "Rau",
                            phone = "(647)872-3645",
                            sex = "Female"
                        },
                        new
                        {
                            Id = 2,
                            address = "30 Township Road",
                            age = 79,
                            firstName = "Christoper",
                            lastName = "Cummings",
                            phone = "(647)758-2598",
                            sex = "Female"
                        },
                        new
                        {
                            Id = 3,
                            address = "5 Beaver Street",
                            age = 56,
                            firstName = "Lavelle",
                            lastName = "Koch",
                            phone = "(647)836-0594",
                            sex = "Male"
                        },
                        new
                        {
                            Id = 4,
                            address = "12 Brooke Drive",
                            age = 54,
                            firstName = "Lorrie",
                            lastName = "Kiehn",
                            phone = "(647)782-2351",
                            sex = "Female"
                        },
                        new
                        {
                            Id = 5,
                            address = "24 Rue Perreault",
                            age = 71,
                            firstName = "Helene",
                            lastName = "Harvey",
                            phone = "(647)323-9547",
                            sex = "Male"
                        },
                        new
                        {
                            Id = 6,
                            address = "25 Rupert Street",
                            age = 58,
                            firstName = "Landon",
                            lastName = "Krajcik",
                            phone = "(416)861-0795",
                            sex = "Male"
                        },
                        new
                        {
                            Id = 7,
                            address = "354 Highway",
                            age = 34,
                            firstName = "Brain",
                            lastName = "Kirlin",
                            phone = "(416)743-3774",
                            sex = "Female"
                        },
                        new
                        {
                            Id = 8,
                            address = "51 Avenue",
                            age = 60,
                            firstName = "Nicolas",
                            lastName = "Torp",
                            phone = "(647)773-3315",
                            sex = "Male"
                        },
                        new
                        {
                            Id = 9,
                            address = "15 Richard Place",
                            age = 68,
                            firstName = "Ariel",
                            lastName = "Spencer",
                            phone = "(416)232-9525",
                            sex = "Female"
                        },
                        new
                        {
                            Id = 10,
                            address = "30 Golburn Road",
                            age = 22,
                            firstName = "Justine",
                            lastName = "Mraz",
                            phone = "(416)456-7356",
                            sex = "Female"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");

                    b.HasData(
                        new
                        {
                            Id = "5e49b3c0-eff2-4147-8507-4912c38cb4de",
                            ConcurrencyStamp = "2584f26b-54ab-4be6-8323-7523d8c2d115",
                            Name = "user",
                            NormalizedName = "USER"
                        },
                        new
                        {
                            Id = "f6008a39-63b9-4d4e-b314-70aeff910ce1",
                            ConcurrencyStamp = "74212b04-d6ce-427b-8840-89a18ad09b64",
                            Name = "admin",
                            NormalizedName = "ADMINISTRATOR"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("BloodDonationProject.Data.Donation", b =>
                {
                    b.HasOne("BloodDonationProject.Data.Hospital", "Hospital")
                        .WithMany("Donations")
                        .HasForeignKey("HospitalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BloodDonationProject.Data.User", "User")
                        .WithMany("Donations")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hospital");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("BloodDonationProject.Data.ApiUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("BloodDonationProject.Data.ApiUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BloodDonationProject.Data.ApiUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("BloodDonationProject.Data.ApiUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BloodDonationProject.Data.Hospital", b =>
                {
                    b.Navigation("Donations");
                });

            modelBuilder.Entity("BloodDonationProject.Data.User", b =>
                {
                    b.Navigation("Donations");
                });
#pragma warning restore 612, 618
        }
    }
}
