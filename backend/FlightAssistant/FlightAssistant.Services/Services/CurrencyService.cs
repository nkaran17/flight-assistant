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

        public async Task<string> GetCurrencyAlphabeticCodeById(int currencyId)
        {
            var currency = await _unitOfWork.Currencies.GetByIdAsync(currencyId);
            if (currency != null) return currency.AlphabeticCode;
            return null;
        }

        public async Task LoadCurrencies()
        {
            var currencies = await _unitOfWork.Currencies.LoadCurrenciesFromFile();

            if (currencies != null && currencies.Count > 0)
            {
                await _unitOfWork.Currencies.AddRangeAsync(currencies);
                await _unitOfWork.Complete();
            }

            return;
        }

        public async Task<List<Currency>> GetAll() 
        {
            var currencies = await _unitOfWork.Currencies.GetAllAsync();
            if(currencies != null)
            {
                return currencies.ToList();
            }
            return null;
        }
    }
}
