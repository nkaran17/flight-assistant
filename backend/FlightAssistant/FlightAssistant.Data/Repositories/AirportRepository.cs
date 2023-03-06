using FlightAssistant.Core.Models;
using FlightAssistant.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FlightAssistant.Data.Repositories
{
    public class AirportRepository : Repository<Airport>, IAirportRepository
    {
        public AirportRepository(DbContext context) : base(context) { }

        private AppDbContext _appDbContext { get { return context as AppDbContext; } }
    }
}
