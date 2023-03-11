namespace FlightAssistant.Core.DTO
{
    public class AmadeusFlightsRequest
    {
        public string OriginLocationCode { get; set; } = null!;
        public string DestinationLocationCode { get; set; } = null!;
        public DateTime DepartureDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public int Adults { get; set; }
        public int? Children { get; set; }
        public int? Infants { get; set; }
        public string? CurrencyCode { get; set; }
    }
}
