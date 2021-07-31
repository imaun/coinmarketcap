using System;
using System.Net;
using System.Linq;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading;
using System.Reflection;
using System.Threading.Tasks;
using System.Collections.Generic;
using Emun.CoinMarketCap.Models;

namespace Emun.CoinMarketCap {

    /// <inheritdoc/>
    public class CoinMarketCapAPI: ICoinMarketCapAPI {

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
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json;charset=UTF-8");
            _httpClient.DefaultRequestHeaders.Add("Accept-Encoding", "UTF-8");
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
                var result = JsonConvert.DeserializeObject<ApiResponse<T>>(content);
                if(result.Status.HasError) {
                    throw new CoinMarketCapException(message: result.Status.ErrorCode.Message());
                }
                return result;
            }

            response.EnsureSuccessStatusCode();
            return null;
        }

        #endregion

        #region Methods

        /// <inheritdoc/>
        public async Task<ListingResult> GetListingsLatestAsync(
            ListingsLatestQuery request,
            CancellationToken cancellationToken) {

            request.CheckArgumentIsNull(nameof(request));

            var api_result = await getApiResponseAsync<List<LatestCryptoData>>
                (request, "cryptocurrency/listings/latest", cancellationToken);

            return await Task.FromResult(ListingResult.From(api_result));
        }

        /// <inheritdoc/>
        public async Task<ListingResult> GetListingHistoricalAsync(
            ListingHistoricalQuery request,
            CancellationToken cancellationToken) {

            request.CheckArgumentIsNull(nameof(request));

            if (string.IsNullOrWhiteSpace(request.date))
                throw new ArgumentNullException("date");

            var api_result = await getApiResponseAsync<List<LatestCryptoData>>
                (request, "cryptocurrency/listings/historical", cancellationToken);

            return await Task.FromResult(ListingResult.From(api_result));
        }

        /// <inheritdoc />
        public async Task<ListingResult> GetQuotesLatestAsync(
            QuotesLatestQuery request,
            CancellationToken cancellationToken) {


            request.CheckArgumentIsNull(nameof(request));

            var api_result = await getApiResponseAsync<List<LatestCryptoData>>
                (request, "cryptocurrency/quotes/latest", cancellationToken);

            return await Task.FromResult(ListingResult.From(api_result));
        }

        /// <inheritdoc />
        public async Task<MetadataResult> GetMetadataAsync(
            MetadataQuery request,
            CancellationToken cancellationToken) {

            request.CheckArgumentIsNull(nameof(request));

            var api_result = await getApiResponseAsync
                <List<Dictionary<string, CryptoCurrencyData>>>
                    (request, "cryptocurrency/info", cancellationToken);

            return await Task.FromResult(MetadataResult.From(api_result));
        }

        /// <inheritdoc />
        public async Task<IdMapResult> MapAsync(
            IdMapQuery request,
            CancellationToken cancellationToken) {

            request.CheckArgumentIsNull(nameof(request));

            var api_result = await getApiResponseAsync<List<CryptoCurrencyIdMapData>>
                (request, "cryptocurrency/map", cancellationToken);

            return await Task.FromResult(IdMapResult.From(api_result));
        }

        /// <inheritdoc />
        public async Task<PriceConversionResult> PriceConversionAsync(
            PriceConversionQuery request,
            CancellationToken cancellationToken) {

            request.CheckArgumentIsNull(nameof(request));

            var api_result = await getApiResponseAsync<PriceConversionData>
                (request, "tools/price-conversion", cancellationToken);

            return await Task.FromResult(PriceConversionResult.From(api_result));
        }

        #endregion

    }
}
