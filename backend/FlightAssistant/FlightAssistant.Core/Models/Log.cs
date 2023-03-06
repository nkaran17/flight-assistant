using FlightAssistant.Core.Enums;

namespace FlightAssistant.Core.Models
{
    public class Log
    {
        public int Id { get; set; }

        public LogLevelEnum Level { get; set; }

        public string Message { get; set; } = null!;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
