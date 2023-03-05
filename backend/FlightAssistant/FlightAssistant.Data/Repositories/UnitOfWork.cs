using FlightAssistant.Core.Repositories;
using FlightAssistant.Core.Settings;
using MongoDB.Driver;

namespace FlightAssistant.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IMongoDatabase _database;
        private readonly MongoDBSettings _mongoDBSettings;

        private LogRepository _logRepository;

        public UnitOfWork(IMongoDBConnection mongoDBConnection)
        {
            _mongoDBSettings = mongoDBConnection.MongoDBSettings;
            _database = mongoDBConnection.Database;
        }

        public ILogRepository LogRepo => _logRepository = _logRepository ?? new LogRepository(_database, _mongoDBSettings.LogCollectionName);
    }
}
