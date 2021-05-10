using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Net;
using Newtonsoft.Json;
using System.Reflection;
using Emun.CoinMarketCap.Models;
using Emun.CoinMarketCap.Models.Enum;

namespace Emun.CoinMarketCap {

    public class CoinMarketCapAPI {

        private readonly IHttpClientFactory _httpClientFactory;
        private readonly HttpClient _httpClient;
        private string _apiKey;

        private HttpStatusCode[] _validStatusCodes = new HttpStatusCode[] {
            HttpStatusCode.BadRequest,
            HttpStatusCode.Forbidden,
            HttpStatusCode.Unauthorized,
            HttpStatusCode.PaymentRequired,
            (HttpStatusCode)429
        };

        public CoinMarketCapAPI(IHttpClientFactory httpClientFactory, string apiKey) {
            if (string.IsNullOrWhiteSpace(apiKey))
                throw new ArgumentNullException("Please pass CointMarketCap ApiKey.");

            _httpClientFactory = httpClientFactory
                ?? throw new ArgumentNullException(nameof(httpClientFactory));
            _httpClient = _httpClientFactory.CreateClient();
            _apiKey = apiKey;
            addDefaultHeaders();
        }

        #region Properties

        #endregion

        #region Methods

        private void addDefaultHeaders() {
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            _httpClient.DefaultRequestHeaders.Add("Content-Type", "application/json; charset=utf-8");
            _httpClient.DefaultRequestHeaders.Add("X-CMC_PRO_API_KEY", _apiKey);
        }

        private string urlEncode(string value) => WebUtility.UrlEncode(value);

        private string getQueryString(object obj) {
            var properties = obj.GetType().GetProperties();
            var parameters = properties.Select(_ => new {
                name = _.GetCustomAttribute<JsonPropertyAttribute>()?.PropertyName,
                value = _.GetValue(obj)
            }).Where(_ => _.value != null && !string.IsNullOrWhiteSpace(_.name));

            var query = parameters.Select(_ => $"{_.name}={urlEncode(_.value.ToString())}");
            var result = query.Select((_, __) => __ > 0 ? $"&?{_}" : $"{__}");

            return string.Join("", result);
        }

        private async Task<ApiResponse<T>> getApiResponseAsync<T>(object request, string url, CancellationToken cancelToken) where T: class {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            string queryString = getQueryString(request);
            url = $"{url}{queryString}";
            var httpRequest = new HttpRequestMessage(HttpMethod.Get, url);
            var response = await _httpClient.SendAsync(httpRequest, cancelToken);

            if(response.IsSuccessStatusCode || _validStatusCodes.Contains(response.StatusCode)) {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ApiResponse<T>>(content);
            }

            response.EnsureSuccessStatusCode();
            return null;
        }

        #endregion
    }
}
