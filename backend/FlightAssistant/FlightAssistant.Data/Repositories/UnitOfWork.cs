using FlightAssistant.Core.Repositories;

namespace FlightAssistant.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public IAirportRepository Airports { get; }
        public ICurrencyRepository Currencies { get; }
        public IFlightRepository Flights { get; }

        public UnitOfWork(AppDbContext appDbContext,
            IAirportRepository airportRepository,
            ICurrencyRepository currencyRepository,
            IFlightRepository flightRepository)
        {
            _context = appDbContext;

            Airports = airportRepository;
            Currencies = currencyRepository;
            Flights = flightRepository;
        }

        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
    }
}
