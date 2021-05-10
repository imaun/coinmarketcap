using System;
using System.Net;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Reflection;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json;
using Emun.CoinMarketCap.Models;
using Emun.CoinMarketCap.Models.Enum;

namespace Emun.CoinMarketCap {

    public class CoinMarketCapAPI {

        private readonly HttpClient _httpClient;
        private string _apiKey;

        private HttpStatusCode[] _validStatusCodes = new HttpStatusCode[] {
            HttpStatusCode.BadRequest,
            HttpStatusCode.Forbidden,
            HttpStatusCode.Unauthorized,
            HttpStatusCode.PaymentRequired,
            (HttpStatusCode)429
        };

        public CoinMarketCapAPI(HttpClient httpClient, string apiKey) {
            if (string.IsNullOrWhiteSpace(apiKey))
                throw new ArgumentNullException("Please pass CointMarketCap's ApiKey.");

            _httpClient = httpClient
                ?? throw new ArgumentNullException(nameof(httpClient));

            _httpClient.BaseAddress = new Uri("https://pro-api.coinmarketcap.com/v1/");
            _apiKey = apiKey;
            addDefaultHeaders();
        }

        #region Properties

        #endregion

        #region Private Helper Methods

        private void addDefaultHeaders() {
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            //_httpClient.DefaultRequestHeaders.Add("Content-Type", "application/json; charset=utf-8");
            _httpClient.DefaultRequestHeaders.Add("X-CMC_PRO_API_KEY", _apiKey);
        }

        private string urlEncode(string value) => WebUtility.UrlEncode(value);

        private string getQueryString(object obj) {
            var properties = obj.GetType().GetProperties();
            var parameters = properties.Select(_ => new {
                name = _.GetCustomAttribute<JsonPropertyAttribute>()?.PropertyName,
                value = _.GetValue(obj)
            }).Where(_ => _.value != null && !string.IsNullOrWhiteSpace(_.name));

            var query = parameters.Select(_ 
                => $"{_.name}={urlEncode(_.value.ToString())}"
            );
            var result = query.Select((field, index) 
                => index > 0 ? $"&{field}" : $"?{field}"
            );

            return string.Join("", result);
        }

        private async Task<ApiResponse<T>> getApiResponseAsync<T>(object request, string url, CancellationToken cancelToken) where T : class {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            string queryString = getQueryString(request);
            url = $"{url}{queryString}";
            var httpRequest = new HttpRequestMessage(HttpMethod.Get, url);
            var response = await _httpClient.SendAsync(httpRequest, cancelToken);

            if (response.IsSuccessStatusCode || _validStatusCodes.Contains(response.StatusCode)) {
                var content = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Response : {content}");
                return JsonConvert.DeserializeObject<ApiResponse<T>>(content);
            }

            response.EnsureSuccessStatusCode();
            return null;
        }

        #endregion

        #region Methods

        public async Task<ApiResponse<List<LatestCryptoData>>> GetListingsLatestAsync(
            ListingsLatestQuery request,
            CancellationToken cancellationToken) {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var result = await getApiResponseAsync<List<LatestCryptoData>>
                (request, "cryptocurrency/listings/latest", cancellationToken);

            return await Task.FromResult(result);
        }

        #endregion
       
    }
}
