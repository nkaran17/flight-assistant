namespace FlightAssistant.Core.Models
{
    public class Airport
    {
        public int Id { get; set; }

        public string Iata { get; set; } = null!;
        public string Icao { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Location { get; set; } = null!;
    }
}
