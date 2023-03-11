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

        public AirportsController(IAirportService airportService)
        {
            _airportService = airportService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] AmadeusFlightsRequest request)
        {
            await _airportService.FetchAirports();
            return Ok();
        }
    }
}
