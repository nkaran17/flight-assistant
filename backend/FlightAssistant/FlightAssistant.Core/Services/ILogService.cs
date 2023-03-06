using FlightAssistant.Core.Models;

namespace FlightAssistant.Core.Services
{
    public interface ILogService
    {
        Task<Log> Create(Log newLog);
    }
}
