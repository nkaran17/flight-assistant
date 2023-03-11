using FlightAssistant.Core.DTO;
using FlightAssistant.Core.Models;
using FlightAssistant.Core.Models.Queries;

namespace FlightAssistant.Core.Repositories
{
    public interface IFlightRepository : IGenericRepository<Flight>
    {
        Task<QueryResult<Flight>> QueryFlightsAsync(AmadeusFlightsRequest query);
    }
}
