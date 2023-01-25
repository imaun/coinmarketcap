using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using ImanN.CoinMarketCap.Models;

namespace ImanN.CoinMarketCap.Internal {

    internal class FiatService : CoinMarketCapBaseService, IFiatService {

        public FiatService(HttpClient httpClient, string apiKey) 
            : base(httpClient, apiKey) { }

        
        /// <inheritdoc/>
        public async Task<FiatMapResult> MapAsync(
            FiatMapQuery request, 
            CancellationToken cancellationToken = default) {

            request.CheckArgumentIsNull(nameof(request));

            var api_result = await getApiResponseAsync<List<FiatMapData>>
                (request, "fiat/map", cancellationToken);

            return await Task.FromResult(FiatMapResult.From(api_result));
        }


    }
}
