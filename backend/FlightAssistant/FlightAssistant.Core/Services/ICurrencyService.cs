using FlightAssistant.Core.DTO;
using FlightAssistant.Core.Models;

namespace FlightAssistant.Core.Services
{
    public interface ICurrencyService
    {
        Task<Currency> Create(Currency newCurrency);
        Task<string> GetCurrencyAlphabeticCodeById(int currencyId);
        Task LoadCurrencies();
        Task<List<CurrencyResponse>> GetAll();
    }
}
