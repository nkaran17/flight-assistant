namespace FlightAssistant.Core.DTO
{
    public class AmadeusFlightsResponse
    {
        public List<FlightOffer> Data { get; set; }
    }


    public class FlightOffer
    {
        public string Type { get; set; }
        public string Id { get; set; }
        public string Source { get; set; }
        public int NumberOfBookableSeats { get; set; }
        public OfferPrice Price { get; set; }
        public Itinerary[] Itineraries { get; set; }
    }

    public class OfferPrice
    {
        public string Currency { get; set; }
        public string GrandTotal { get; set; }
    }

    public class Itinerary
    {
        public Segment[] Segments { get; set; }
    }

    public class Segment
    {
        public LocationAndDate Departure { get; set; }
        public LocationAndDate Arrival { get; set; }
    }

    public class LocationAndDate
    {
        public string IataCode { get; set; }
        public DateTime At { get; set; }
    }
}
