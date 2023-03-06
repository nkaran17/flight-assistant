using FlightAssistant.Core.Models;
using FlightAssistant.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FlightAssistant.Data.Repositories
{
    public class LogRepository : Repository<Log>, ILogRepository
    {
        public LogRepository(DbContext context) : base(context) { }

        private AppDbContext _appDbContext { get { return context as AppDbContext; } }
    }
}
