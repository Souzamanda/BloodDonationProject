using BloodDonationProject.Configurations.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloodDonationProject.Data
{
    public class DatabaseContext : IdentityDbContext<ApiUser>
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Hospital> Hospitals { get; set; }
        public DbSet<Donation> Donations { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new RoleConfiguration());

            builder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    firstName = "Toby",
                    lastName = "Rau",
                    sex = "Female",
                    age = 34,
                    address = "3578 Yonge St.",
                    phone = "(647)872-3645"
                },
                new User
                {
                    Id = 2,
                    firstName = "Christoper",
                    lastName = "Cummings",
                    sex = "Female",
                    age = 79,
                    address = "30 Township Road",
                    phone = "(647)758-2598"
                },
                new User
                {
                    Id = 3,
                    firstName = "Lavelle",
                    lastName = "Koch",
                    sex = "Male",
                    age = 56,
                    address = "5 Beaver Street",
                    phone = "(647)836-0594"
                },
                new User
                {
                    Id = 4,
                    firstName = "Lorrie",
                    lastName = "Kiehn",
                    sex = "Female",
                    age = 54,
                    address = "12 Brooke Drive",
                    phone = "(647)782-2351"
                },
                new User
                {
                    Id = 5,
                    firstName = "Helene",
                    lastName = "Harvey",
                    sex = "Male",
                    age = 71,
                    address = "24 Rue Perreault",
                    phone = "(647)323-9547"
                },
                new User
                {
                    Id = 6,
                    firstName = "Landon",
                    lastName = "Krajcik",
                    sex = "Male",
                    age = 58,
                    address = "25 Rupert Street",
                    phone = "(416)861-0795"
                },
                new User
                {
                    Id = 7,
                    firstName = "Brain",
                    lastName = "Kirlin",
                    sex = "Female",
                    age = 34,
                    address = "354 Highway",
                    phone = "(416)743-3774"
                },
                new User
                {
                    Id = 8,
                    firstName = "Nicolas",
                    lastName = "Torp",
                    sex = "Male",
                    age = 60,
                    address = "51 Avenue",
                    phone = "(647)773-3315"
                },
                new User
                {
                    Id = 9,
                    firstName = "Ariel",
                    lastName = "Spencer",
                    sex = "Female",
                    age = 68,
                    address = "15 Richard Place",
                    phone = "(416)232-9525"
                },
                new User
                {
                    Id = 10,
                    firstName = "Justine",
                    lastName = "Mraz",
                    sex = "Female",
                    age = 22,
                    address = "30 Golburn Road",
                    phone = "(416)456-7356"
                }
                );

            builder.Entity<Hospital>().HasData(
                new Hospital
                {
                    Id = 1,
                    Name = "Toronto General Hospital",
                    Address = "200 Elizabeth St.",
                    Phone = "(416)340-3131"
                },
                new Hospital
                {
                    Id = 2,
                    Name = "Toronto Western Hospital",
                    Address = "399 Bathurst St.",
                    Phone = "(416)603-2591"
                },
                new Hospital
                {
                    Id = 3,
                    Name = "Sunnybrook Health Sciences Centre",
                    Address = "2075 Bayview Ave.",
                    Phone = "(416)480-6100"
                },
                new Hospital
                {
                    Id = 4,
                    Name = "Mount Sinai Hospital",
                    Address = "600 University Ave.",
                    Phone = "(416)596-4200"
                },
                new Hospital
                {
                    Id = 5,
                    Name = "Saint Michael's Hospital",
                    Address = "36 Queen St. E",
                    Phone = "(416)360-4000"
                },
                new Hospital
                {
                    Id = 6,
                    Name = "Women's College Hospital",
                    Address = "76 Grenville St.",
                    Phone = "(416)323-6400"
                },
                new Hospital
                {
                    Id = 7,
                    Name = "The Hospital for Sick Children",
                    Address = "555 University Ave.",
                    Phone = "(416)813-1500"
                },
                new Hospital
                {
                    Id = 8,
                    Name = "St Regis Hospital",
                    Address = "36 Grenville St.",
                    Phone = "(647)491-0642"
                },
                new Hospital
                {
                    Id = 9,
                    Name = "Bridgepoint Hospital",
                    Address = "1 Bridgepoint Dr.",
                    Phone = "(416)461-8252"
                },
                new Hospital
                {
                    Id = 10,
                    Name = "Princess Margaret Cancer Centre",
                    Address = "610 University Ave.",
                    Phone = "(416)946-2000"
                }
                );

            builder.Entity<Donation>().HasData(
                new Donation
                {
                    Id = 1,
                    BloodType = "O-",
                    Date = "21-Mar-2022",
                    Status = "Available",
                    UserId = 2,
                    HospitalId = 10
                },
                new Donation
                {
                    Id = 2,
                    BloodType = "O+",
                    Date = "15-Mar-2022",
                    Status = "Not Available",
                    UserId = 4,
                    HospitalId = 9
                },
                new Donation
                {
                    Id = 3,
                    BloodType = "A-",
                    Date = "22-Mar-2022",
                    Status = "Available",
                    UserId = 6,
                    HospitalId = 8
                },
                new Donation
                {
                    Id = 4,
                    BloodType = "A+",
                    Date = "15-Mar-2022",
                    Status = "Not Available",
                    UserId = 8,
                    HospitalId = 7
                },
                new Donation
                {
                    Id = 5,
                    BloodType = "B-",
                    Date = "15-Mar-2022",
                    Status = "Not Available",
                    UserId = 10,
                    HospitalId = 6
                },
                new Donation
                {
                    Id = 6,
                    BloodType = "B+",
                    Date = "13-Mar-2022",
                    Status = "Not Available",
                    UserId = 1,
                    HospitalId = 5
                },
                new Donation
                {
                    Id = 7,
                    BloodType = "AB-",
                    Date = "22-Mar-2022",
                    Status = "Available",
                    UserId = 3,
                    HospitalId = 4
                },
                new Donation
                {
                    Id = 8,
                    BloodType = "AB+",
                    Date = "21-Mar-2022",
                    Status = "Available",
                    UserId = 5,
                    HospitalId = 3
                },
                new Donation
                {
                    Id = 9,
                    BloodType = "AB+",
                    Date = "19-Mar-2022",
                    Status = "Available",
                    UserId = 7,
                    HospitalId = 2
                },
                new Donation
                {
                    Id = 10,
                    BloodType = "O-",
                    Date = "15-Mar-2022",
                    Status = "Not Available",
                    UserId = 9,
                    HospitalId = 1
                }
                );
        }
    }
}
