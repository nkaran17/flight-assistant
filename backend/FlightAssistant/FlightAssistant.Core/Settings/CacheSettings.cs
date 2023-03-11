namespace FlightAssistant.Core.Settings
{
    public class CacheSettings
    {
        public int TimeoutMinutes { get; set; }
        public string AmadeusAccessTokenCacheKey { get; set; } = null!;
    }
}
