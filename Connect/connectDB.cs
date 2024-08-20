using System.Collections.Generic;
using System;
using Microsoft.EntityFrameworkCore;
using Military_Asset_Management_System.Military_modles;

namespace Military_Asset_Management_System.Connect
{
    public class connectDB : DbContext
    {
        public connectDB(DbContextOptions<connectDB> options) : base(options)
        {
            Database.EnsureCreated();
   
        }
        private static DbContextOptions Getoptions(string connectionString)
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new
                DbContextOptionsBuilder(), connectionString).Options;
        }
        private void Seed()
        {
            Vehicle mylibrary = new Vehicle
            {
                Id = 2,
                Name = "Tank",
                AssetType = "Vehicle",
                Status = "Active",
                Model = "M1 Abrams",
                LicensePlate = "456-DEF",
                OperationalStatus = "Operational"
            };
            _Vehicles.Add(mylibrary);
            SaveChanges();
        }
       
        public DbSet<Vehicle> _Vehicles { get; set; }
        public DbSet<Personnel> _Personnels { get; set; }
        public DbSet<Weapon> _Weapons { get; set; }

    }
}

