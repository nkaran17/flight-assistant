using FlightAssistant.Core.Repositories;
using FlightAssistant.Core.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace FlightAssistant.Data.Repositories
{
    public class MongoDBConnection : IMongoDBConnection
    {
        private readonly IMongoDatabase _database;
        private readonly MongoDBSettings _mongoDBSettings;

        public MongoDBConnection(IOptions<MongoDBSettings> mongoDBSettings)
        {
            _mongoDBSettings = mongoDBSettings.Value;
            MongoClient client = new MongoClient(_mongoDBSettings.ConnectionURI);
            _database = client.GetDatabase(_mongoDBSettings.DatabaseName);
        }

        public MongoDBSettings MongoDBSettings => _mongoDBSettings;
        public IMongoDatabase Database => _database;
    }
}
