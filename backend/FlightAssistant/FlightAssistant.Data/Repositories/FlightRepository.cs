using FlightAssistant.Core.DTO;
using FlightAssistant.Core.Models;
using FlightAssistant.Core.Models.Queries;
using FlightAssistant.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FlightAssistant.Data.Repositories
{
    public class FlightRepository : GenericRepository<Flight>, IFlightRepository
    {
        public FlightRepository(AppDbContext context) : base(context) { }

        public async Task<QueryResult<FlightResponse>> QueryFlightsAsync(AmadeusFlightsRequest query)
        {
            var queryable = _entities.AsQueryable();

            QueryResult<FlightResponse> queryResult = new QueryResult<FlightResponse>();

            if (query != null)
            {
                queryable = queryable.Where(x => x.DepartureAirportId == query.DepartureAirportId);
                queryable = queryable.Where(x => x.ArrivalAirportId == query.ArrivalAirportId);
                queryable = queryable.Where(x => x.DepartureDate.Date == query.DepartureDate.Date);
                queryable = queryable.Where(x => x.CurrencyId == query.CurrencyId);
                queryable = queryable.Where(x => x.NumberOfPassangers == query.NumberOfPassangers);
                queryable = queryable.Where(x => x.ReturnDate.Date == query.ReturnDate.Date);
            }

            queryResult.TotalItems = await queryable.CountAsync();

            var flightsQuery = await queryable.Skip((query.Page - 1) * query.ItemsPerPage)
                                                    .Take(query.ItemsPerPage)
                                                    .ToListAsync();

            var flightsResponseItems = flightsQuery.Select(f => new FlightResponse(f.Id, f.DepartureAirportId, f.ArrivalAirportId, f.DepartureDate, f.ArrivalDate, f.ReturnDate, f.NumberOfPassangers, f.NumberOfLayovers, f.CurrencyId, f.GrandTotalPrice)).ToList();

            queryResult.Items = flightsResponseItems;

            return queryResult;
        }
    }
}
