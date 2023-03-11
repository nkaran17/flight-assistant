using FlightAssistant.Core.DTO;
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

        public AmadeusApiService(IAmadeusConfigService amadeusConfigService, IOptions<AmadeusSettings> amadeusSettings)
        {
            _amadeusConfigService = amadeusConfigService;
            _amadeusSettings = amadeusSettings.Value;
        }

        public async Task<List<FlightOffer>> GetFlights(AmadeusFlightsRequest request)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _amadeusConfigService.GetAmadeusAccessToken());

            var url = $"{_amadeusSettings.APIBaseUrl}/shopping/flight-offers";

            var queryString = FillGetFlightsQueryParams(request);
            if (queryString != null)
            {
                url += "?" + queryString;   
            }

            var response = await client.GetAsync(url);

            var responseContent = await response.Content.ReadAsStringAsync();
            var responseData = JsonConvert.DeserializeObject<AmadeusFlightsResponse>(responseContent);

            if(responseData!= null && responseData.Data != null)
            {
                return responseData.Data;
            } else
            {
                return null;
            }
        }

        private string FillGetFlightsQueryParams(AmadeusFlightsRequest request)
        {
            NameValueCollection queryParams = new NameValueCollection();

            if (request.OriginLocationCode != null)
            {
                queryParams.Add("originLocationCode", request.OriginLocationCode);
            }
            if (request.DestinationLocationCode != null)
            {
                queryParams.Add("destinationLocationCode", request.DestinationLocationCode);
            }
            if (request.DepartureDate != null)
            {
                queryParams.Add("departureDate", request.DepartureDate.ToString("yyyy-MM-dd"));
            }
            if (request.ReturnDate != null)
            {
                queryParams.Add("returnDate", request.ReturnDate.Value.ToString("yyyy-MM-dd"));
            }
            if (request.Adults > 0)
            {
                queryParams.Add("adults", request.Adults.ToString());
            }
            if (request.Children > 0)
            {
                queryParams.Add("children", request.Children.ToString());
            }
            if (request.Infants > 0)
            {
                queryParams.Add("infants", request.Infants.ToString());
            }
            if (request.CurrencyCode != null)
            {
                queryParams.Add("currencyCode", request.CurrencyCode);
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
