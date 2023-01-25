using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using ImanN.CoinMarketCap.Models;

namespace ImanN.CoinMarketCap.Internal {

    /// <inheritdoc/>
    internal class ExchangeService : CoinMarketCapBaseService, IExchangeService {
    
        public ExchangeService(HttpClient httpClient, string apiKey) 
            : base(httpClient, apiKey) { }


        /// <inheritdoc/>
        public async Task<ExchangeMapResult> MapAsync(
            ExchangeMapQuery request, 
            CancellationToken cancellationToken = default) {

            request.CheckArgumentIsNull(nameof(request));

            var api_result = await getApiResponseAsync<List<ExchangeMapData>>
                (request, "exchange/map", cancellationToken);

            return ExchangeMapResult.From(api_result);
        }

        /// <inheritdoc/>
        public async Task<ExchangeListingResult> ListingLatestAsync(
            ExchangeListingLatestQuery request, 
            CancellationToken cancellationToken = default) {

            request.CheckArgumentIsNull(nameof(request));

            var api_result = await getApiResponseAsync<List<ExchangeLatestData>>
                (request, "exchange/listings/latest", cancellationToken);

            return ExchangeListingResult.From(api_result);
        }

        /// <inheritdoc/>
        public async Task<ExchangeMetadataResult> GetInfoAsync(
            ExchangeMetadataQuery request,
            CancellationToken cancellationToken = default) {

            request.CheckArgumentIsNull(nameof(request));

            var api_result = await getApiResponseAsync<Dictionary<string, List<ExchangeMetadata>>>
                (request, "exchange/info", cancellationToken);

            return ExchangeMetadataResult.From(api_result);
        }

    }
}
