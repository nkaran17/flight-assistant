using FlightAssistant.Core.Models;
using FlightAssistant.Core.Repositories;
using FlightAssistant.Core.Services;

namespace FlightAssistant.Services.Services
{
    public class FlightService : IFlightService
    {
        private readonly IUnitOfWork _unitOfWork;

        public FlightService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Flight> Create(Flight newFlight)
        {
            await _unitOfWork.Flights.AddAsync(newFlight);
            await _unitOfWork.Complete();
            return newFlight;
        }
    }
}
