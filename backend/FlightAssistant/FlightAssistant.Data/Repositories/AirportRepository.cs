using FlightAssistant.Core.Models;
using FlightAssistant.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FlightAssistant.Data.Repositories
{
    public class AirportRepository : GenericRepository<Airport>, IAirportRepository
    {
        public AirportRepository(AppDbContext context) : base(context) { }
    }
}
