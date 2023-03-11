namespace FlightAssistant.Core.Settings
{
    public class AmadeusSettings
    {
        public string AccessTokenRequestGrantTypeParamKey { get; set; } = null!;
        public string AccessTokenRequestGrantTypeParamValue { get; set; } = null!;
        public string AccessTokenRequestApiKeyParamKey { get; set; } = null!;
        public string AccessTokenRequestApiKeyParamValue { get; set; } = null!;
        public string AccessTokenRequestApiSecretParamKey { get; set; } = null!;
        public string AccessTokenRequestApiSecretParamValue { get; set; } = null!;
        public string AccessTokenRequestURL { get; set; } = null!;
        public string APIBaseUrl { get; set; } = null!;
    }
}