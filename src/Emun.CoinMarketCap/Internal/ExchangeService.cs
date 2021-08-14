using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using Emun.CoinMarketCap.Models;

namespace Emun.CoinMarketCap.Internal {

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


    }
}
