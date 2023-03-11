using FlightAssistant.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace FlightAssistant.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AirportsController : ControllerBase
    {
        private readonly IAirportService _airportService;
        private readonly IAmadeusConfigService _amadeusConfigService;

        public AirportsController(IAirportService airportService, IAmadeusConfigService amadeusConfigService)
        {
            _airportService = airportService;
            _amadeusConfigService = amadeusConfigService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            //await _airportService.FetchAirports();
            var x = await _amadeusConfigService.GetAmadeusAccessToken();

            return Ok(x);
        }
    }
}
