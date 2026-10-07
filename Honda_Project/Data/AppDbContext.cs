using Honda_Project.Models;
using Microsoft.EntityFrameworkCore;
using Honda_Project.Enums;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Honda_Project.Data
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<CarBodyType> CarBodyTypes { get; set; }
        public DbSet<CarBrand> CarBrands { get; set; }
        public DbSet<CarEngineType> CarEngineTypes { get; set; }
        public DbSet<CarModel> CarModels { get; set; }
        public DbSet<CarProduct> CarProducts { get; set; }
        public DbSet<Order> Orders { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<CarModel>()
                .HasOne(m => m.CarBrand)
                .WithMany(b => b.CarModels)
                .HasForeignKey(m => m.CarBrandId)
                .OnDelete(DeleteBehavior.Cascade);

         
            modelBuilder.Entity<CarProduct>()
                .HasOne(p => p.CarModel)
                .WithMany(m => m.CarProducts)
                .HasForeignKey(p => p.CarModelId)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<CarProduct>()
                .HasOne(p => p.CarBodyType)
                .WithMany(b => b.CarProducts)
                .HasForeignKey(p => p.CarBodyTypeId)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<CarProduct>()
                .HasOne(p => p.CarEngineType)
                .WithMany(e => e.CarProducts)
                .HasForeignKey(p => p.CarEngineTypeId)
                .OnDelete(DeleteBehavior.Cascade);

            string adminRoleId = "a18be9c0-aa65-4af8-bd17-00bd9344e575";
            string customerRoleId = "b29cf0d1-bb76-5bf9-ce28-11ce0455f686";

            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = adminRoleId,
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                    ConcurrencyStamp = "a18be9c0-aa65-4af8-bd17-00bd9344e575"
                },
                new IdentityRole
                {
                    Id = customerRoleId,
                    Name = "Customer",
                    NormalizedName = "CUSTOMER",
                    ConcurrencyStamp = "b29cf0d1-bb76-5bf9-ce28-11ce0455f686"
                }
                );
    


                modelBuilder.Entity<CarBrand>().HasData(
                new CarBrand
                {
                    Id = 1,
                    Name = "Acura",
                    LogoUrl = "/Assets/Logos/Acura-motor-logo.jpg",
                    Description = "Precision Crafted Performance"
                },
                new CarBrand
                {
                    Id = 2,
                    Name = "Honda motocross",
                    LogoUrl = "/Assets/Logos/Honda-motor-wing-logo.jpg",
                    Description = "Motorcycles and sports vechical Honda Powersports"
                },
                new CarBrand
                {
                    Id = 3,
                    Name = "Honda",
                    LogoUrl = "/Assets/Logos/Honda-motor-base-logo.jpg",
                    Description = "The Power of Dreams"
                }
            );


            modelBuilder.Entity<CarBodyType>().HasData(
                new CarBodyType { Id = 1, Name = "Sedan", IconUrl = "/Assets/BodyTypes/Sedan.jpg", Description = "Classic 4-door body" },
                new CarBodyType { Id = 2, Name = "Hatchback", IconUrl = "/Assets/BodyTypes/Hatchback.jpg", Description = "Compact 5-door body" },
                new CarBodyType { Id = 3, Name = "Crossover", IconUrl = "/Assets/BodyTypes/Crossover.jpg", Description = "Compact SUV" },
                new CarBodyType { Id = 4, Name = "Motorbike / Motocross", IconUrl = "/Assets/BodyTypes/Motocross.jpg", Description = "Two-wheeled sports equipment" }
            );

            modelBuilder.Entity<CarEngineType>().HasData(
                new CarEngineType
                {
                    Id = 1,
                    Name = "1.8 i-VTEC (R18A)",
                    Volume = 1.8,
                    Horsepower = 140,
                    FuelType = FuelType.Petrol
                },
                new CarEngineType
                {
                    Id = 2,
                    Name = "2.0 Turbo VTEC (K20C1)",
                    Volume = 2.0,
                    Horsepower = 315,
                    FuelType = FuelType.Petrol
                },
                new CarEngineType
                {
                    Id = 3,
                    Name = "2.0 e:HEV Hybrid",
                    Volume = 2.0,
                    Horsepower = 184,
                    FuelType = FuelType.Hybrid
                },
                new CarEngineType
                {
                    Id = 4,
                    Name = "450cc Unicam 4-stroke",
                    Volume = 0.45,
                    Horsepower = 55,
                    FuelType = FuelType.Petrol
                }
            );


            modelBuilder.Entity<CarModel>().HasData(
                new CarModel { Id = 1, Name = "Civic", Description = "A light, maneuverable and compact car for the city", ModelLogoUrl = "/Assets/ModelLogos/Civic.jpg", CarBrandId = 3 },
                new CarModel { Id = 2, Name = "Accord", Description = "Mid-size luxury sedan", ModelLogoUrl = "/Assets/ModelLogos/Accord.jpg", CarBrandId = 3 },
                new CarModel { Id = 3, Name = "CR-V", Description = "A popular family crossover that won't leave you in trouble.", ModelLogoUrl = "/Assets/ModelLogos/CR-V.jpg", CarBrandId = 3 },

                new CarModel { Id = 4, Name = "TLX", Description = "Premium sports sedan", ModelLogoUrl = "/Assets/ModelLogos/TLX.jpg", CarBrandId = 1 },
                new CarModel { Id = 5, Name = "MDX", Description = "Acura's flagship crossover", ModelLogoUrl = "/Assets/ModelLogos/MDX.jpg", CarBrandId = 1 },

  
                new CarModel { Id = 6, Name = "CRF", Description = "Professional motocross bike", ModelLogoUrl = "/Assets/ModelLogos/CRF.jpg", CarBrandId = 2 }
            );

            modelBuilder.Entity<CarProduct>().HasData(
                new CarProduct
                {
                    Id = 1,
                    Title = "Honda Civic 1.8 i-VTEC 4D",
                    Description = "Надежный седан 8-го поколения",
                    Price = 14500m,
                    Year = 2008,
                    Color = "Черный",
                    MainImageUrl = "/Assets/CarProductImg/honda-civic-4d.jpg",
                    IsAvailable = true,
                    CarModelId = 1,        
                    CarBodyTypeId = 1,    
                    CarEngineTypeId = 1,  
                    Transmission = TransmissionType.Manual,
                    Drive = CarDriveType.FWD
                },
                new CarProduct
                {
                    Id = 2,
                    Title = "Honda Civic Type R FK8",
                    Description = "Заряженный хэтчбек с турбомотором",
                    Price = 41000m,
                    Year = 2021,
                    Color = "Championship White",
                    MainImageUrl = "/Assets/CarProductImg/honda-civic-type-r-2021.jpg",
                    IsAvailable = true,
                    CarModelId = 1,       
                    CarBodyTypeId = 2,     
                    CarEngineTypeId = 2,  
                    Transmission = TransmissionType.Manual,
                    Drive = CarDriveType.FWD
                },
                new CarProduct
                {
                    Id = 3,
                    Title = "Acura TLX Type S",
                    Description = "Мощный полноприводный седан",
                    Price = 49000m,
                    Year = 2023,
                    Color = "Apex Blue",
                    MainImageUrl = "/Assets/CarProductImg/acura-TLX-Type-s.jpg",
                    IsAvailable = true,
                    CarModelId = 4,       
                    CarBodyTypeId = 1,   
                    CarEngineTypeId = 2, 
                    Transmission = TransmissionType.Automatic,
                    Drive = CarDriveType.AWD
                },
                new CarProduct
                {
                    Id = 4,
                    Title = "Honda CRF450R Motocross",
                    Description = "Спортивный байк для трека и заездов",
                    Price = 9800m,
                    Year = 2024,
                    Color = "Extreme Red",
                    MainImageUrl = "/Assets/CarProductImg/honda-CRF450R-red.jpg",
                    IsAvailable = true,
                    CarModelId = 6,       
                    CarBodyTypeId = 4,     
                    CarEngineTypeId = 4,   
                    Transmission = TransmissionType.Manual,
                    Drive = CarDriveType.RWD
                }
            );
        }
    }
}
