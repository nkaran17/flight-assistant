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
        public async Task<IActionResult> GetAll()
        {
            var airports = await _airportService.GetAll();
            return Ok(airports);
        }

        [HttpGet("load")]
        public async Task<IActionResult> LoadAll()
        {
            await _airportService.LoadAirports();
            return Ok();
        }
    }
}
