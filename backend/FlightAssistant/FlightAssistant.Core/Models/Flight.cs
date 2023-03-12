namespace FlightAssistant.Core.Models
{
    public class Flight
    {
        public int Id { get; set; }
        public int DepartureAirportId { get; set; }
        public int ArrivalAirportId { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime ArrivalDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public int NumberOfPassangers { get; set; }
        public int NumberOfLayovers { get; set; }
        public int CurrencyId { get; set; }
        public string GrandTotalPrice { get; set; }
        public Airport DepartureAirport { get; set; }
        public Airport ArrivalAirport { get; set; }
        public Currency Currency { get; set; }
    }
}
