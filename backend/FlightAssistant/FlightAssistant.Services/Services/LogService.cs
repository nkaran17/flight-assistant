using FlightAssistant.Core.Models;
using FlightAssistant.Core.Repositories;
using FlightAssistant.Core.Services;

namespace FlightAssistant.Services.Services
{
    public class LogService : ILogService
    {
        private readonly IUnitOfWork _unitOfWork;

        public LogService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Log> Create(Log newLog)
        {
            await _unitOfWork.LogRepo.AddAsync(newLog);
            await _unitOfWork.CommitAsyncAppDbContext();
            return newLog;
        }
    }
}
