using FlightAssistant.Core.Models;

namespace FlightAssistant.Core.Repositories
{
    public interface ICurrencyRepository : IGenericRepository<Currency>
    {
        Task<List<Currency>> LoadCurrenciesFromFile();
    }
}
