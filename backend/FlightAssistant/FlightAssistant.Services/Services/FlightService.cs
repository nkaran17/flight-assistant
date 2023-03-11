using FlightAssistant.Core.DTO;
using FlightAssistant.Core.Models;
using FlightAssistant.Core.Models.Queries;
using FlightAssistant.Core.Repositories;
using FlightAssistant.Core.Services;

namespace FlightAssistant.Services.Services
{
    public class FlightService : IFlightService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAmadeusApiService _amadeusApiService;

        public FlightService(IUnitOfWork unitOfWork, IAmadeusApiService amadeusApiService)
        {
            _unitOfWork = unitOfWork;
            _amadeusApiService = amadeusApiService;
        }

        public async Task<QueryResult<Flight>> GetFlights(AmadeusFlightsRequest query)
        {
            var flightsFromDb = await _unitOfWork.Flights.QueryFlightsAsync(query);
            if (flightsFromDb != null && flightsFromDb.TotalItems > 0)
            {
                return flightsFromDb;
            }

            var flightsFromAmadeus = await _amadeusApiService.GetFlights(query);
            return await AddAmadeusFliights(query, flightsFromAmadeus);
        }

        public async Task<Flight> Create(Flight newFlight)
        {
            await _unitOfWork.Flights.AddAsync(newFlight);
            await _unitOfWork.Complete();
            return newFlight;
        }

        public async Task<QueryResult<Flight>> AddAmadeusFliights(AmadeusFlightsRequest query, List<FlightOffer> flightOffers)
        {
            QueryResult<Flight> queryResult = new QueryResult<Flight>();

            List<Flight> flightsToAdd = new List<Flight>();

            foreach (var flightOffer in flightOffers)
            {
                flightsToAdd.Add(new Flight
                {
                    DepartureAirportId = query.DepartureAirportId,
                    ArrivalAirportId = query.ArrivalAirportId,
                    DepartureDate = GetDepartureTimeFromFlightOffer(flightOffer, query.DepartureDate),
                    ArrivalDate = GetArrivalTimeFromFlightOffer(flightOffer),
                    ReturnDate = query.ReturnDate,
                    CurrencyId = query.CurrencyId > 0 ? query.CurrencyId : null,
                    NumberOfLayovers = GetNumberOfLayoversFromFlightOffer(flightOffer),
                    NumberOfPassangers = query.NumberOfPassangers,
                    GrandTotalPrice = GetGrandTotalPriceFromFlightOffer(flightOffer)
                });
            }

            if (flightsToAdd.Count > 0)
            {
                await _unitOfWork.Flights.AddRangeAsync(flightsToAdd);
                await _unitOfWork.Complete();

                queryResult.TotalItems = flightsToAdd.Count;
                queryResult.Items = flightsToAdd.Take(Math.Min(10, flightsToAdd.Count)).ToList();
            }

            return queryResult;
        }

        private DateTime GetDepartureTimeFromFlightOffer(FlightOffer flightOffer, DateTime queryDateTime)
        {
            if (flightOffer != null &&
                flightOffer.Itineraries != null &&
                flightOffer.Itineraries.Length > 0 &&
                flightOffer.Itineraries[0].Segments != null &&
                flightOffer.Itineraries[0].Segments.Length > 0)
            {
                return flightOffer.Itineraries[0].Segments[0].Departure.At;
            }
            return queryDateTime;
        }

        private DateTime? GetArrivalTimeFromFlightOffer(FlightOffer flightOffer)
        {
            if (flightOffer != null &&
                flightOffer.Itineraries != null &&
                flightOffer.Itineraries.Length > 0 &&
                flightOffer.Itineraries[0].Segments != null &&
                flightOffer.Itineraries[0].Segments.Length > 0)
            {
                return flightOffer.Itineraries[0].Segments[flightOffer.Itineraries[0].Segments.Length - 1].Arrival.At;
            }
            return null;
        }

        private int GetNumberOfLayoversFromFlightOffer(FlightOffer flightOffer)
        {
            if (flightOffer != null &&
                flightOffer.Itineraries != null &&
                flightOffer.Itineraries.Length > 0 &&
                flightOffer.Itineraries[0].Segments != null &&
                flightOffer.Itineraries[0].Segments.Length > 0)
            {
                return flightOffer.Itineraries[0].Segments.Length;
            }
            return 0;
        }

        private string GetGrandTotalPriceFromFlightOffer(FlightOffer flightOffer)
        {
            if (flightOffer != null &&
                flightOffer.Price != null &&
                flightOffer.Price.GrandTotal != null)
            {
                return flightOffer.Price.GrandTotal;
            }
            return null;
        }
    }
}
