using FlightAssistant.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightAssistant.Core.Services
{
    public interface ICurrencyService
    {
        Task<Currency> Create(Currency newCurrency);
        Task<string> GetCurrencyAlphabeticCodeById(int currencyId);
        Task LoadCurrencies();
        Task<List<Currency>> GetAll();
    }
}
