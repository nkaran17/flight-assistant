using FlightAssistant.Core.Settings;
using MongoDB.Driver;

namespace FlightAssistant.Core.Repositories
{
    public interface IMongoDBConnection
    {
        MongoDBSettings MongoDBSettings { get; }
        IMongoDatabase Database { get; }
    }
}
