using FlightAssistant.Core.Models;

namespace FlightAssistant.Core.Services
{
    public interface IFlightService
    {
        Task<Flight> Create(Flight newFlight);
    }
}
