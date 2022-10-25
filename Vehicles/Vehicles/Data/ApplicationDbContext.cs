using Microsoft.EntityFrameworkCore;
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
        public DbSet<VehicleType> VehicleTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
