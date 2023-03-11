using FlightAssistant.Core.Services;
using FlightAssistant.Core.Settings;
using Microsoft.Extensions.Options;

namespace FlightAssistant.Services.Services
{
    public class CacheService : ICacheService
    {
        private readonly Dictionary<string, string> _cache;
        private readonly Dictionary<string, Timer> _timers;
        private readonly int _cacheTimeoutMinutes;

        public CacheService(IOptions<CacheSettings> cacheSettings)
        {
            _cache = new Dictionary<string, string>();
            _timers = new Dictionary<string, Timer>();
            _cacheTimeoutMinutes = cacheSettings.Value.TimeoutMinutes;
        }

        public void AddToCache(string key, string value)
        {
            _cache[key] = value;

            var timer = new Timer(state => RemoveFromCache(key), null, TimeSpan.FromMinutes(_cacheTimeoutMinutes), TimeSpan.Zero);
            _timers[key] = timer;
        }

        public string GetFromCache(string key)
        {
            if (!_cache.ContainsKey(key))
            {
                return null;
            }

            return _cache[key];
        }

        private void RemoveFromCache(string key)
        {
            _cache.Remove(key);
            _timers.Remove(key);
        }
    }
}
