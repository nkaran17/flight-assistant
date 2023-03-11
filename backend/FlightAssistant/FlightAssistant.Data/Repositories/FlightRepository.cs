using FlightAssistant.Core.DTO;
using FlightAssistant.Core.Helpers;
using FlightAssistant.Core.Models;
using FlightAssistant.Core.Models.Queries;
using FlightAssistant.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FlightAssistant.Data.Repositories
{
    public class FlightRepository : GenericRepository<Flight>, IFlightRepository
    {
        public FlightRepository(AppDbContext context) : base(context) { }

        public async Task<QueryResult<Flight>> QueryFlightsAsync(AmadeusFlightsRequest query)
        {
            var queryable = _entities.AsQueryable();
            queryable = queryable.Include(x => x.DepartureAirport);
            queryable = queryable.Include(x => x.ArrivalAirport);
            queryable = queryable.Include(x => x.Currency);

            QueryResult<Flight> queryResult = new QueryResult<Flight>();

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
                if (query.CurrencyId > 0)
                {
                    queryable = queryable.Where(x => x.CurrencyId == query.CurrencyId);
                }
            }

            queryResult.TotalItems = await queryable.CountAsync();
            queryResult.Items = await queryable.Skip((query.Page - 1) * query.ItemsPerPage)
                                                    .Take(query.ItemsPerPage)
                                                    .ToListAsync();

            return queryResult;
        }
    }
}
