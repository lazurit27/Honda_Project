





 
using System;
using Honda_Project.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Honda_Project.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20260825135105_AddAdminCustomer")]
    partial class AddAdminCustomer
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "10.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Honda_Project.Models.CarBodyType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IconUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CarBodyTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Classic 4-door body",
                            IconUrl = "/Assets/BodyTypes/Sedan.jpg",
                            Name = "Sedan"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Compact 5-door body",
                            IconUrl = "/Assets/BodyTypes/Hatchback.jpg",
                            Name = "Hatchback"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Compact SUV",
                            IconUrl = "/Assets/BodyTypes/Crossover.jpg",
                            Name = "Crossover"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Two-wheeled sports equipment",
                            IconUrl = "/Assets/BodyTypes/Motocross.jpg",
                            Name = "Motorbike / Motocross"
                        });
                });

            modelBuilder.Entity("Honda_Project.Models.CarBrand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LogoUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CarBrands");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Precision Crafted Performance",
                            LogoUrl = "/Assets/Logos/Acura-motor-logo.jpg",
                            Name = "Acura"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Motorcycles and sports vechical Honda Powersports",
                            LogoUrl = "/Assets/Logos/Honda-motor-wing-logo.jpg",
                            Name = "Honda motocross"
                        },
                        new
                        {
                            Id = 3,
                            Description = "The Power of Dreams",
                            LogoUrl = "/Assets/Logos/Honda-motor-base-logo.jpg",
                            Name = "Honda"
                        });
                });

            modelBuilder.Entity("Honda_Project.Models.CarEngineType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("FuelType")
                        .HasColumnType("int");

                    b.Property<int>("Horsepower")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("Volume")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("CarEngineTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FuelType = 0,
                            Horsepower = 140,
                            Name = "1.8 i-VTEC (R18A)",
                            Volume = 1.8
                        },
                        new
                        {
                            Id = 2,
                            FuelType = 0,
                            Horsepower = 315,
                            Name = "2.0 Turbo VTEC (K20C1)",
                            Volume = 2.0
                        },
                        new
                        {
                            Id = 3,
                            FuelType = 2,
                            Horsepower = 184,
                            Name = "2.0 e:HEV Hybrid",
                            Volume = 2.0
                        },
                        new
                        {
                            Id = 4,
                            FuelType = 0,
                            Horsepower = 55,
                            Name = "450cc Unicam 4-stroke",
                            Volume = 0.45000000000000001
                        });
                });

            modelBuilder.Entity("Honda_Project.Models.CarModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CarBrandId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ModelLogoUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CarBrandId");

                    b.ToTable("CarModels");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CarBrandId = 3,
                            Description = "A light, maneuverable and compact car for the city",
                            ModelLogoUrl = "/Assets/ModelLogos/Civic.jpg",
                            Name = "Civic"
                        },
                        new
                        {
                            Id = 2,
                            CarBrandId = 3,
                            Description = "Mid-size luxury sedan",
                            ModelLogoUrl = "/Assets/ModelLogos/Accord.jpg",
                            Name = "Accord"
                        },
                        new
                        {
                            Id = 3,
                            CarBrandId = 3,
                            Description = "A popular family crossover that won't leave you in trouble.",
                            ModelLogoUrl = "/Assets/ModelLogos/CR-V.jpg",
                            Name = "CR-V"
                        },
                        new
                        {
                            Id = 4,
                            CarBrandId = 1,
                            Description = "Premium sports sedan",
                            ModelLogoUrl = "/Assets/ModelLogos/TLX.jpg",
                            Name = "TLX"
                        },
                        new
                        {
                            Id = 5,
                            CarBrandId = 1,
                            Description = "Acura's flagship crossover",
                            ModelLogoUrl = "/Assets/ModelLogos/MDX.jpg",
                            Name = "MDX"
                        },
                        new
                        {
                            Id = 6,
                            CarBrandId = 2,
                            Description = "Professional motocross bike",
                            ModelLogoUrl = "/Assets/ModelLogos/CRF.jpg",
                            Name = "CRF"
                        });
                });

            modelBuilder.Entity("Honda_Project.Models.CarProduct", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CarBodyTypeId")
                        .HasColumnType("int");

                    b.Property<int>("CarEngineTypeId")
                        .HasColumnType("int");

                    b.Property<int>("CarModelId")
                        .HasColumnType("int");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Drive")
                        .HasColumnType("int");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("bit");

                    b.Property<string>("MainImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Transmission")
                        .HasColumnType("int");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CarBodyTypeId");

                    b.HasIndex("CarEngineTypeId");

                    b.HasIndex("CarModelId");

                    b.ToTable("CarProducts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CarBodyTypeId = 1,
                            CarEngineTypeId = 1,
                            CarModelId = 1,
                            Color = "Черный",
                            Description = "Надежный седан 8-го поколения",
                            Drive = 0,
                            IsAvailable = true,
                            MainImageUrl = "/Assets/CarProductImg/honda-civic-4d.jpg",
                            Price = 14500m,
                            Title = "Honda Civic 1.8 i-VTEC 4D",
                            Transmission = 0,
                            Year = 2008
                        },
                        new
                        {
                            Id = 2,
                            CarBodyTypeId = 2,
                            CarEngineTypeId = 2,
                            CarModelId = 1,
                            Color = "Championship White",
                            Description = "Заряженный хэтчбек с турбомотором",
                            Drive = 0,
                            IsAvailable = true,
                            MainImageUrl = "/Assets/CarProductImg/honda-civic-type-r-2021.jpg",
                            Price = 41000m,
                            Title = "Honda Civic Type R FK8",
                            Transmission = 0,
                            Year = 2021
                        },
                        new
                        {
                            Id = 3,
                            CarBodyTypeId = 1,
                            CarEngineTypeId = 2,
                            CarModelId = 4,
                            Color = "Apex Blue",
                            Description = "Мощный полноприводный седан",
                            Drive = 2,
                            IsAvailable = true,
                            MainImageUrl = "/Assets/CarProductImg/acura-TLX-Type-s.jpg",
                            Price = 49000m,
                            Title = "Acura TLX Type S",
                            Transmission = 1,
                            Year = 2023
                        },
                        new
                        {
                            Id = 4,
                            CarBodyTypeId = 4,
                            CarEngineTypeId = 4,
                            CarModelId = 6,
                            Color = "Extreme Red",
                            Description = "Спортивный байк для трека и заездов",
                            Drive = 1,
                            IsAvailable = true,
                            MainImageUrl = "/Assets/CarProductImg/honda-CRF450R-red.jpg",
                            Price = 9800m,
                            Title = "Honda CRF450R Motocross",
                            Transmission = 0,
                            Year = 2024
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

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                            ConcurrencyStamp = "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "b29cf0d1-bb76-5bf9-ce28-11ce0455f686",
                            ConcurrencyStamp = "b29cf0d1-bb76-5bf9-ce28-11ce0455f686",
                            Name = "Customer",
                            NormalizedName = "CUSTOMER"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
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

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
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

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
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

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Honda_Project.Models.CarModel", b =>
                {
                    b.HasOne("Honda_Project.Models.CarBrand", "CarBrand")
                        .WithMany("CarModels")
                        .HasForeignKey("CarBrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CarBrand");
                });

            modelBuilder.Entity("Honda_Project.Models.CarProduct", b =>
                {
                    b.HasOne("Honda_Project.Models.CarBodyType", "CarBodyType")
                        .WithMany("CarProducts")
                        .HasForeignKey("CarBodyTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Honda_Project.Models.CarEngineType", "CarEngineType")
                        .WithMany("CarProducts")
                        .HasForeignKey("CarEngineTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Honda_Project.Models.CarModel", "CarModel")
                        .WithMany("CarProducts")
                        .HasForeignKey("CarModelId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("CarBodyType");

                    b.Navigation("CarEngineType");

                    b.Navigation("CarModel");
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
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
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

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Honda_Project.Models.CarBodyType", b =>
                {
                    b.Navigation("CarProducts");
                });

            modelBuilder.Entity("Honda_Project.Models.CarBrand", b =>
                {
                    b.Navigation("CarModels");
                });

            modelBuilder.Entity("Honda_Project.Models.CarEngineType", b =>
                {
                    b.Navigation("CarProducts");
                });

            modelBuilder.Entity("Honda_Project.Models.CarModel", b =>
                {
                    b.Navigation("CarProducts");
                });
#pragma warning restore 612, 618
        }
    }
}
