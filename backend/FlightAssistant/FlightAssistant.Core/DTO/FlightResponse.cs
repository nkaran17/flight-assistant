namespace FlightAssistant.Core.DTO
{
    public class FlightResponse
    {
        public int Id { get; set; }
        public int DepartureAirportId { get; set; }
        public int ArrivalAirportId { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime ArrivalDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public int NumberOfPassangers { get; set; }
        public int NumberOfLayovers { get; set; }
        public int CurrencyId { get; set; }
        public string GrandTotalPrice { get; set; }

        public FlightResponse(int id, int departureAirportId, int arrivalAirportId, DateTime departureDate, DateTime arrivalDate, DateTime returnDate, int numberOfPassangers, int numberOfLayovers, int currencyId, string grandTotalPrice)
        {
            Id = id;
            DepartureAirportId = departureAirportId;
            ArrivalAirportId = arrivalAirportId;
            DepartureDate = departureDate;
            ArrivalDate = arrivalDate;
            ReturnDate = returnDate.Date != DateTime.MinValue.Date ? returnDate.Date : null;
            NumberOfPassangers = numberOfPassangers;
            NumberOfLayovers = numberOfLayovers;
            CurrencyId = currencyId;
            GrandTotalPrice = grandTotalPrice;
        }
    }
}
