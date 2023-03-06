using FlightAssistant.Core.Models;

namespace FlightAssistant.Core.Services
{
    public interface IAirportService
    {
        Task<Airport> Create(Airport newAirport);
        Task<List<Airport>> FetchAirports();
    }
}
