using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using ImanN.CoinMarketCap.Models;

namespace ImanN.CoinMarketCap.Internal
{

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
