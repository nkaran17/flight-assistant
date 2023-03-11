using FlightAssistant.Core.DTO;
using FlightAssistant.Core.Services;
using FlightAssistant.Core.Settings;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace FlightAssistant.Services.Services
{
    public class AmadeusConfigService : IAmadeusConfigService
    {
        private readonly ICacheService _cacheService;
        private readonly CacheSettings _cacheSettings;
        private readonly AmadeusSettings _amadeusSettings;
        public AmadeusConfigService(IOptions<CacheSettings> cacheSettings, IOptions<AmadeusSettings> amadeusSettings, ICacheService cacheService)
        {
            _cacheService = cacheService;
            _cacheSettings = cacheSettings.Value;
            _amadeusSettings = amadeusSettings.Value;
        }

        public async Task<string> GetAmadeusAccessToken()
        {
            var accessTokenFromCache = _cacheService.GetFromCache(_cacheSettings.AmadeusAccessTokenCacheKey);
            if (accessTokenFromCache != null)
            {
                return accessTokenFromCache;
            }

            return await LoginToAmadeus();
        }

        private async Task<string> LoginToAmadeus()
        {
            var httpClient = new HttpClient();
            var formData = new Dictionary<string, string>
            {
                { _amadeusSettings.AccessTokenRequestGrantTypeParamKey, _amadeusSettings.AccessTokenRequestGrantTypeParamValue },
                { _amadeusSettings.AccessTokenRequestApiKeyParamKey, _amadeusSettings.AccessTokenRequestApiKeyParamValue },
                { _amadeusSettings.AccessTokenRequestApiSecretParamKey, _amadeusSettings.AccessTokenRequestApiSecretParamValue },
            };
            var content = new FormUrlEncodedContent(formData);
            var response = await httpClient.PostAsync(_amadeusSettings.AccessTokenRequestURL, content);
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            var responseData = JsonConvert.DeserializeObject<AmadeusLoginResponse>(responseContent);
            if (responseData != null)
            {
                _cacheService.AddToCache(_cacheSettings.AmadeusAccessTokenCacheKey, responseData.access_token);
            }
            else
            {
                throw new Exception("Amadeus login failed.");
            }

            return responseData.access_token;
        }
    }
}
