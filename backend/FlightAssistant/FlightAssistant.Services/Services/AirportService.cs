using FlightAssistant.Core.Enums;
using FlightAssistant.Core.Models;
using FlightAssistant.Core.Repositories;
using FlightAssistant.Core.Services;
using HtmlAgilityPack;

namespace FlightAssistant.Services.Services
{
    public class AirportService : IAirportService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogService _logService;

        public AirportService(IUnitOfWork unitOfWork, ILogService logService)
        {
            _unitOfWork = unitOfWork;
            _logService = logService;
        }

        public async Task<Airport> Create(Airport newAirport)
        {
            await _unitOfWork.AirportRepo.AddAsync(newAirport);
            await _unitOfWork.CommitAsyncAppDbContext();
            return newAirport;
        }

        public async Task FetchAirports()
        {
            await _logService.Create(new Log
            {
                Level = LogLevelEnum.Trace,
                Message = "Fetching airports started."
            });

            var url = "https://en.wikipedia.org/wiki/List_of_airports_by_IATA_airport_code:_A";
            var httpClient = new HttpClient();
            var html = await httpClient.GetStringAsync(url);
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);
            var tables = htmlDocument.DocumentNode.SelectNodes("//table");
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
                    await _unitOfWork.AirportRepo.AddAsync(airport);
                }
                await _unitOfWork.CommitAsyncAppDbContext();
            }

            await _logService.Create(new Log
            {
                Level = LogLevelEnum.Trace,
                Message = "Fetching airports finished."
            });
            return;
        }
    }
}
