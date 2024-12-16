using FipeBrasil.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FipeBrasil.Infrastructure.Data.Context
{
    public class FipeDbContext : DbContext
    {
        public DbSet<Brand> Brands { get; set; } = null!;
        public DbSet<Model> Models { get; set; } = null!;
        public DbSet<VehicleYear> VehicleYears { get; set; } = null!;
        public DbSet<Vehicle> Vehicles { get; set; } = null!;
        public DbSet<Comment> Comments { get; set; } = null!;

        public FipeDbContext(DbContextOptions<FipeDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(FipeDbContext).Assembly);
        }
    }
}
