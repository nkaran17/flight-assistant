using FlightAssistant.Core.Models;
using FlightAssistant.Core.Repositories;
using FlightAssistant.Core.Services;

namespace FlightAssistant.Services.Services
{
    public class CurrencyService : ICurrencyService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CurrencyService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Currency> Create(Currency newCurrency)
        {
            await _unitOfWork.Currencies.AddAsync(newCurrency);
            await _unitOfWork.Complete();
            return newCurrency;
        }

        public async Task FetchCurrencies()
        {
            var currencies = await _unitOfWork.Currencies.LoadCurrenciesFromFile();

            if (currencies != null && currencies.Count > 0)
            {
                await _unitOfWork.Currencies.AddRangeAsync(currencies);
                await _unitOfWork.Complete();
            }

            return;
        }
    }
}
