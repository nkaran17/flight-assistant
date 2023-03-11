namespace FlightAssistant.Core.Services
{
    public interface ICacheService
    {
        void AddToCache(string key, string value);
        string GetFromCache(string key);
    }
}
