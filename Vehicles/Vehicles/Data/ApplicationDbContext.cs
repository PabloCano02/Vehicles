﻿using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using Vehicles.Entities;

namespace Vehicles.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<DocumentType> DocumentTypes { get; set; }
        public DbSet<Procedure> Procedures { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<VehicleType> VehicleTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Vehicle>()
                .HasOne(bc => bc.VehicleType)
                .WithMany(b => b.Vehicles)
                .HasForeignKey(bc => bc.VehicleTypeId);
            modelBuilder.Entity<Vehicle>()
                .HasOne(bc => bc.Brand)
                .WithMany(b => b.Vehicles)
                .HasForeignKey(bc => bc.BrandId);

            base.OnModelCreating(modelBuilder);
        }

    }
}
