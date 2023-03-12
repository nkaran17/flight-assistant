using FlightAssistant.Core.DTO;
using FlightAssistant.Core.Models;
using FlightAssistant.Core.Models.Queries;

namespace FlightAssistant.Core.Services
{
    public interface IFlightService
    {
        Task<QueryResult<FlightResponse>> GetFlights(AmadeusFlightsRequest query);
        Task<Flight> Create(Flight newFlight);
        Task<QueryResult<FlightResponse>> AddAmadeusFliights(AmadeusFlightsRequest query, List<FlightOffer> flightOffers);
    }
}
