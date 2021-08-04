using Emun.CoinMarketCap.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Emun.CoinMarketCap.Internal {

    internal class ToolsService : CoinMarketCapBaseService, IToolsService {

        public ToolsService(HttpClient httpClient, string apiKey)
            : base(httpClient, apiKey) { }

        /// <inheritdoc />
        public async Task<PriceConversionResult> PriceConversionAsync(
            PriceConversionQuery request,
            CancellationToken cancellationToken = default) {

            request.CheckArgumentIsNull(nameof(request));

            var api_result = await getApiResponseAsync<PriceConversionData>
                (request, "tools/price-conversion", cancellationToken);

            return await Task.FromResult(PriceConversionResult.From(api_result));
        }

    }
}
