using FlightAssistant.Core.Models;
using FlightAssistant.Core.Repositories;
using MongoDB.Driver;

namespace FlightAssistant.Data.Repositories
{
    public class LogRepository : Repository<Log>, ILogRepository
    {
        public LogRepository(IMongoDatabase database, string collectionName) : base(database, collectionName) { }
    }
}
