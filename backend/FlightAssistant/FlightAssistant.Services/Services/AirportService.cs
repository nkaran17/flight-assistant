using FlightAssistant.Core.Models;
using FlightAssistant.Core.Repositories;
using FlightAssistant.Core.Services;

namespace FlightAssistant.Services.Services
{
    public class AirportService : IAirportService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AirportService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Airport> Create(Airport newAirport)
        {
            await _unitOfWork.AirportRepo.AddAsync(newAirport);
            await _unitOfWork.CommitAsyncAppDbContext();
            return newAirport;
        }

        public Task<List<Airport>> FetchAirports()
        {
            throw new NotImplementedException();
        }
    }
}
