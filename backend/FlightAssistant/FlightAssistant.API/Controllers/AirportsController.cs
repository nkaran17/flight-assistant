using FlightAssistant.Core.DTO;
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
        private readonly IAmadeusApiService _amadeusApiService;

        public AirportsController(IAirportService airportService, IAmadeusConfigService amadeusConfigService, IAmadeusApiService amadeusApiService)
        {
            _airportService = airportService;
            _amadeusConfigService = amadeusConfigService;
            _amadeusApiService = amadeusApiService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery]AmadeusFlightsRequest request)
        {
            //await _airportService.FetchAirports();
            //var x = await _amadeusConfigService.GetAmadeusAccessToken();

            await _amadeusApiService.GetFlights(request);

            return Ok();
        }
    }
}
