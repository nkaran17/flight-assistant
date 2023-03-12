using FlightAssistant.Core.Models.Queries;

namespace FlightAssistant.Core.DTO
{
    public class AmadeusFlightsRequest : Query
    {
        public int DepartureAirportId { get; set; }
        public int ArrivalAirportId { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public int NumberOfPassangers { get; set; }
        public int CurrencyId { get; set; }
    }
}
