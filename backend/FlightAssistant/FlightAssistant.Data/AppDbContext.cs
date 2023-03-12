using FlightAssistant.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightAssistant.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() { }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Airport> Airports { get; set; }
        public DbSet<Currency> Currencies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Airport>().HasKey(a => a.Id);
            modelBuilder.Entity<Airport>().HasIndex(a => a.Iata).IsUnique();

            modelBuilder.Entity<Currency>().HasKey(c => c.Id);
            modelBuilder.Entity<Currency>().HasIndex(c => c.AlphabeticCode).IsUnique();

            modelBuilder.Entity<Flight>().HasKey(c => c.Id);
            modelBuilder.Entity<Flight>()
            .HasOne(f => f.DepartureAirport)
            .WithMany()
            .HasForeignKey(f => f.DepartureAirportId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Flight>()
            .HasOne(f => f.ArrivalAirport)
            .WithMany()
            .HasForeignKey(f => f.ArrivalAirportId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Flight>()
            .HasOne(f => f.Currency)
            .WithMany()
            .HasForeignKey(f => f.CurrencyId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Flight>()
                .Property(f => f.DepartureDate).IsRequired();
            modelBuilder.Entity<Flight>()
                .Property(f => f.ArrivalDate).IsRequired();

        }
    }
}
