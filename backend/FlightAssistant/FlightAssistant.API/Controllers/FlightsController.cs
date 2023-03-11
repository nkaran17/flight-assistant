using FlightAssistant.Core.DTO;
using FlightAssistant.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace FlightAssistant.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FlightsController : ControllerBase
    {
        private readonly IFlightService _flightService;

        public FlightsController(IFlightService flightService)
        {
            _flightService = flightService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery]AmadeusFlightsRequest request)
        {
            var flights = await _flightService.GetFlights(request);
            return Ok(flights);
        }
    }
}
