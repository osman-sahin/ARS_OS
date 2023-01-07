using ARS_OS.Models;
using Microsoft.EntityFrameworkCore;
using static ARS_OS.Models.City;

namespace ARS_OS.Data
{
    public class AdessoRideShareDbContext : DbContext
    {
        public AdessoRideShareDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TripPlanConfiguration());
            modelBuilder.ApplyConfiguration(new CityConfiguration());
        }

        public DbSet<TripPlan> TripPlans { get; set; }
        public DbSet<TripPlanRequest> TripPlanRequests { get; set; }
        public DbSet<City> Cities { get; set; }
        
        
    }
}
