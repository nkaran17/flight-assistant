using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightAssistant.Core.DTO
{
    public class AirportResponse
    {
        public int Id { get; set; }

        public string Iata { get; set; } = null!;
        public string Icao { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Location { get; set; } = null!;

        public AirportResponse(int id, string iata, string icao, string name, string location)
        {
            Id = id;
            Iata = iata;
            Icao = icao;
            Name = name;
            Location = location;
        }
    }
}
