namespace FlightAssistant.Core.Settings
{
    public class MongoDBSettings
    {
        public string ConnectionURI { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public string FlightsCollectionName { get; set; } = null!;
        public string LogCollectionName { get; set; } = null!;
    }
}
