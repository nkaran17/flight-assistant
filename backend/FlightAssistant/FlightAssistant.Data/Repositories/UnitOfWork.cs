using FlightAssistant.Core.Repositories;

namespace FlightAssistant.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _appDbContext;

        private LogRepository _logRepository;
        private AirportRepository _airportRepository;

        public UnitOfWork(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public ILogRepository LogRepo => _logRepository = _logRepository ?? new LogRepository(_appDbContext);
        public IAirportRepository AirportRepo => _airportRepository = _airportRepository ?? new AirportRepository(_appDbContext);

        public async Task<int> CommitAsyncAppDbContext()
        {
            return await _appDbContext.SaveChangesAsync();
        }
    }
}
