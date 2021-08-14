using Emun.CoinMarketCap.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Emun.CoinMarketCap.Internal {

    /// <inheritdoc/>
    internal class ExchangeService : CoinMarketCapBaseService, IExchangeService {
    
        public ExchangeService(HttpClient httpClient, string apiKey) 
            : base(httpClient, apiKey) { }


        /// <inheritdoc/>
        public async Task<ExchangeMapResult> MapAsync(
            ExchangeMapQuery request, 
            CancellationToken cancellationToken) {

            request.CheckArgumentIsNull(nameof(request));

            var api_result = await getApiResponseAsync<List<ExchangeMapData>>
                (request, "exchange/map", cancellationToken);

            return ExchangeMapResult.From(api_result);
        }
    }
}
