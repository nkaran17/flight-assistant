using FlightAssistant.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightAssistant.Core.Services
{
    public interface IAmadeusApiService
    {
        Task<List<FlightOffer>> GetFlights(AmadeusFlightsRequest request);
    }
}
