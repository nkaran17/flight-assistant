using FlightAssistant.Core.DTO;
using FlightAssistant.Core.Models;

namespace FlightAssistant.Core.Services
{
    public interface IAirportService
    {
        Task<Airport> Create(Airport newAirport);
        Task<string> GetAirportIataById(int airportId);
        Task LoadAirports();
        Task<List<AirportResponse>> GetAll();
    }
}
