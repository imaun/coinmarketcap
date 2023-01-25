using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace ImanN.CoinMarketCap.Internal
{
    internal class CoinMarketCapBaseService
    {

        private readonly HttpClient _httpClient;
        private string _apiKey;

        private HttpStatusCode[] _validStatusCodes = new HttpStatusCode[] {
            HttpStatusCode.BadRequest,
            HttpStatusCode.Forbidden,
            HttpStatusCode.Unauthorized,
            HttpStatusCode.PaymentRequired,
            (HttpStatusCode)429
        };


        public CoinMarketCapBaseService(HttpClient httpClient, string apiKey) {
            if (string.IsNullOrWhiteSpace(apiKey))
                throw new ArgumentNullException("Please pass CointMarketCap's ApiKey.");

            _httpClient = httpClient
                ?? throw new ArgumentNullException(nameof(httpClient));

            _httpClient.BaseAddress = new Uri("https://pro-api.coinmarketcap.com/v1/");
            _apiKey = apiKey;
            addDefaultHeaders();
        }


        #region Private Helper Methods

        protected void addDefaultHeaders() {
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json;charset=UTF-8");
            _httpClient.DefaultRequestHeaders.Add("Accept-Encoding", "UTF-8");
            _httpClient.DefaultRequestHeaders.Add("X-CMC_PRO_API_KEY", _apiKey);
        }

        protected string urlEncode(string value) => WebUtility.UrlEncode(value);

        protected string getQueryString(object obj) {
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

        protected async Task<ApiResponse<T>> getApiResponseAsync<T>(object request, string url, CancellationToken cancelToken) where T : class {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            string queryString = getQueryString(request);
            url = $"{url}{queryString}";
            var httpRequest = new HttpRequestMessage(HttpMethod.Get, url);
            var response = await _httpClient.SendAsync(httpRequest, cancelToken);

            if (response.IsSuccessStatusCode || _validStatusCodes.Contains(response.StatusCode)) {
                var content = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Response : {content}");
                var result = JsonConvert.DeserializeObject<ApiResponse<T>>(content);
                if (result.Status.HasError) {
                    throw new CoinMarketCapException(message: result.Status.ErrorCode.Message());
                }
                return result;
            }

            response.EnsureSuccessStatusCode();
            return null;
        }

        #endregion
    }
}
