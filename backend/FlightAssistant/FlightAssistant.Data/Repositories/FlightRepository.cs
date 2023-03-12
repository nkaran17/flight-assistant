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
                if (query.DepartureAirportId > 0)
                {
                    queryable = queryable.Where(x => x.DepartureAirportId == query.DepartureAirportId);
                }
                if (query.ArrivalAirportId > 0)
                {
                    queryable = queryable.Where(x => x.ArrivalAirportId == query.ArrivalAirportId);
                }
                if (query.DepartureDate != null)
                {
                    queryable = queryable.Where(x => x.DepartureDate.Date == query.DepartureDate.Date);
                }
                if (query.ReturnDate != null)
                {
                    queryable = queryable.Where(x => x.ReturnDate.Value.Date == query.ReturnDate.Value.Date);
                }
                if (query.CurrencyId > 0)
                {
                    queryable = queryable.Where(x => x.CurrencyId == query.CurrencyId);
                }
                if (query.NumberOfPassangers > 0)
                {
                    queryable = queryable.Where(x => x.NumberOfPassangers == query.NumberOfPassangers);
                }
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
