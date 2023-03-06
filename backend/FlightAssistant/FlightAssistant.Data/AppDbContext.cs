using FlightAssistant.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightAssistant.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() { }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Log> Logs { get; set; }
        public DbSet<Airport> Airports { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Log>().HasKey(l => l.Id);

            modelBuilder.Entity<Airport>().HasKey(a => a.Id);
            modelBuilder.Entity<Airport>().HasIndex(a => a.Iata).IsUnique();
        }
    }
}
