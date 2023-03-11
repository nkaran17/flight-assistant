namespace FlightAssistant.Core.Services
{
    public interface IAmadeusConfigService
    {
        Task<string> GetAmadeusAccessToken();
    }
}
