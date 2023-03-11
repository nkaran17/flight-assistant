using FlightAssistant.Core.Models;
using FlightAssistant.Core.Repositories;
using FlightAssistant.Core.Services;
using HtmlAgilityPack;

namespace FlightAssistant.Services.Services
{
    public class AirportService : IAirportService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AirportService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Airport> Create(Airport newAirport)
        {
            await _unitOfWork.Airports.AddAsync(newAirport);
            await _unitOfWork.Complete();
            return newAirport;
        }

        public async Task<string> GetAirportIataById(int airportId)
        {
            var airport = await _unitOfWork.Airports.GetByIdAsync(airportId);
            if (airport != null) return airport.Iata;
            return null;
        }

        public async Task FetchAirports()
        {
            var url = "https://en.wikipedia.org/wiki/List_of_airports_by_IATA_airport_code:_A";
            var httpClient = new HttpClient();
            var html = await httpClient.GetStringAsync(url);
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);
            var tables = htmlDocument.DocumentNode.SelectNodes("//table");

            List<Airport> airports = new List<Airport>();

            foreach (var table in tables)
            {
                var rows = table.SelectNodes(".//tr");
                foreach (var row in rows)
                {
                    var cells = row.SelectNodes(".//td");
                    if (cells == null || cells.Count < 4)
                    {
                        continue;
                    }
                    var iata = cells[0].InnerText.Trim();
                    var icao = cells[1].InnerText.Trim();
                    var name = cells[2].InnerText.Trim();
                    var location = cells[3].InnerText.Trim();
                    var airport = new Airport { Iata = iata, Icao = icao, Name = name, Location = location };
                    airports.Add(airport);
                }
            }

            if (airports != null && airports.Count > 0)
            {
                await _unitOfWork.Airports.AddRangeAsync(airports);
                await _unitOfWork.Complete();
            }

            return;
        }
    }
}
