using FlightAssistant.Core.DTO;
using FlightAssistant.Core.Helpers;
using FlightAssistant.Core.Services;
using FlightAssistant.Core.Settings;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Collections.Specialized;
using System.Net.Http.Headers;
using System.Web;

namespace FlightAssistant.Services.Services
{
    public class AmadeusApiService : IAmadeusApiService
    {
        private readonly IAmadeusConfigService _amadeusConfigService;
        private readonly AmadeusSettings _amadeusSettings;
        private readonly IAirportService _airportService;
        private readonly ICurrencyService _currencyService;

        public AmadeusApiService(IAmadeusConfigService amadeusConfigService, IOptions<AmadeusSettings> amadeusSettings, IAirportService airportService, ICurrencyService currencyService)
        {
            _amadeusConfigService = amadeusConfigService;
            _amadeusSettings = amadeusSettings.Value;
            _airportService = airportService;
            _currencyService = currencyService;
        }

        public async Task<List<FlightOffer>> GetFlights(AmadeusFlightsRequest request)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _amadeusConfigService.GetAmadeusAccessToken());

            var url = $"{_amadeusSettings.APIBaseUrl}/shopping/flight-offers";

            var queryString = await FillGetFlightsQueryParams(request);
            if (queryString != null)
            {
                url += "?" + queryString;
            }

            var response = await client.GetAsync(url);

            var responseContent = await response.Content.ReadAsStringAsync();
            var responseData = JsonConvert.DeserializeObject<AmadeusFlightsResponse>(responseContent);

            if (responseData != null && responseData.Data != null)
            {
                return responseData.Data;
            }
            else
            {
                return null;
            }
        }

        private async Task<string> FillGetFlightsQueryParams(AmadeusFlightsRequest request)
        {
            NameValueCollection queryParams = new NameValueCollection();

            if (request.DepartureAirportId > 0)
            {
                var departureAirportIata = await _airportService.GetAirportIataById(request.DepartureAirportId);
                if (departureAirportIata != null)
                {
                    queryParams.Add("originLocationCode", departureAirportIata);
                }
            }
            if (request.ArrivalAirportId > 0)
            {
                var arrivalAirportIata = await _airportService.GetAirportIataById(request.ArrivalAirportId);
                if (arrivalAirportIata != null)
                {
                    queryParams.Add("destinationLocationCode", arrivalAirportIata);
                }
            }

            var departureDate = DateTimeHelper.DateOnly(request.DepartureDate);
            if (departureDate != null)
            {
                queryParams.Add("departureDate", departureDate);
            }

            var returnDate = DateTimeHelper.DateOnly(request.ReturnDate);
            if (returnDate != null)
            {
                queryParams.Add("returnDate", returnDate);
            }
            if (request.NumberOfPassangers > 0)
            {
                queryParams.Add("adults", request.NumberOfPassangers.ToString());
            }
            if (request.CurrencyId > 0)
            {
                var currencyAlphabeticCode = await _currencyService.GetCurrencyAlphabeticCodeById(request.CurrencyId);
                if (currencyAlphabeticCode != null)
                {
                    queryParams.Add("currencyCode", currencyAlphabeticCode);
                }
            }

            string queryString = null;

            if (queryParams.Count > 0)
            {
                queryString = string.Join("&", queryParams.AllKeys
            .Select(key => $"{HttpUtility.UrlEncode(key)}={HttpUtility.UrlEncode(queryParams[key])}"));
            }

            return queryString;
        }
    }
}
