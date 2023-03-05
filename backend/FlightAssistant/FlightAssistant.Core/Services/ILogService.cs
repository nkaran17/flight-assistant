using FlightAssistant.Core.Models;

namespace FlightAssistant.Core.Services
{
    public interface ILogService
    {
        Task LogAsync(Log log);
    }
}
