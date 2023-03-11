using FlightAssistant.Core.Models;
using FlightAssistant.Core.Repositories;
using Newtonsoft.Json;

namespace FlightAssistant.Data.Repositories
{
    public class CurrencyRepository : GenericRepository<Currency>, ICurrencyRepository
    {
        public CurrencyRepository(AppDbContext context) : base(context) { }

        public async Task<List<Currency>> LoadCurrenciesFromFile()
        {
            List<Currency> currencies = new List<Currency>();

            var fileContent = await File.ReadAllTextAsync("../FlightAssistant.Data/Files/Currencies.json");
            if (fileContent != null)
            {
                currencies = JsonConvert.DeserializeObject<List<Currency>>(fileContent);
                if (currencies != null && currencies.Count > 0)
                {
                    currencies = currencies.GroupBy(c => c.AlphabeticCode).Select(g => g.First()).ToList();
                }
            }

            return currencies;
        }
    }
}
