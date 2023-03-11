namespace FlightAssistant.Core.Models
{
    public class Flight
    {
        public int Id { get; set; }
        public int DepartureAirportId { get; set; }
        public Airport DepartureAirport { get; set; }
        public int ArrivalAirportId { get; set; }
        public Airport ArrivalAirport { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime ArrivalDate { get; set; }
        public int NumberOfPassangers { get; set; }
        public int CurrencyId { get; set; }
        public Currency Currency { get; set; }
        public decimal GrandTotalPrice { get; set; }
    }
}
