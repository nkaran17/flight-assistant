using FlightAssistant.Core.DTO;
using FlightAssistant.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace FlightAssistant.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CurrenciesController : ControllerBase
    {
        private readonly ICurrencyService _currencyService;

        public CurrenciesController(ICurrencyService currencyService)
        {
            _currencyService = currencyService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var currencies = await _currencyService.GetAll();
            return Ok(currencies);
        }

        [HttpGet("load")]
        public async Task<IActionResult> LoadAll()
        {
            await _currencyService.LoadCurrencies();
            return Ok();
        }
    }
}
