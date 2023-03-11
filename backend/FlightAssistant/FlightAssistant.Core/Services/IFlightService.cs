using FlightAssistant.Core.DTO;
using FlightAssistant.Core.Models;
using FlightAssistant.Core.Models.Queries;

namespace FlightAssistant.Core.Services
{
    public interface IFlightService
    {
        Task<QueryResult<Flight>> GetFlights(AmadeusFlightsRequest query);
        Task<Flight> Create(Flight newFlight);
        Task<QueryResult<Flight>> AddAmadeusFliights(AmadeusFlightsRequest query, List<FlightOffer> flightOffers);
    }
}
