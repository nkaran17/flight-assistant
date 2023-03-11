using FlightAssistant.Core.Models;
using FlightAssistant.Core.Repositories;

namespace FlightAssistant.Data.Repositories
{
    public class FlightRepository : GenericRepository<Flight>, IFlightRepository
    {
        public FlightRepository(AppDbContext context) : base(context) { }
    }
}
