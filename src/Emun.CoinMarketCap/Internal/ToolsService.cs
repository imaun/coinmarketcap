using Emun.CoinMarketCap.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Emun.CoinMarketCap.Internal {

    public interface IToolsService
    {
        /// <summary>
        /// Convert an amount of one cryptocurrency or fiat currency into one or more different currencies utilizing the latest market rate for each currency.
        /// You may optionally pass a historical timestamp as time to convert values based on historical rates (as your API plan supports).
        /// This endpoint is available on the following API plans:
        /// Basic, Startup, Hobbyist, Standard, Professional, Enterprise.
        /// More: https://coinmarketcap.com/api/documentation/v1/#operation/getV1ToolsPriceconversion
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<PriceConversionResult> PriceConversionAsync(
            PriceConversionQuery request,
            CancellationToken cancellationToken);
    }


    internal class ToolsService : CoinMarketCapBaseService, IToolsService {

        public ToolsService(HttpClient httpClient, string apiKey)
            : base(httpClient, apiKey) { }


        /// <inheritdoc />
        public async Task<PriceConversionResult> PriceConversionAsync(
            PriceConversionQuery request,
            CancellationToken cancellationToken) {

            request.CheckArgumentIsNull(nameof(request));

            var api_result = await getApiResponseAsync<PriceConversionData>
                (request, "tools/price-conversion", cancellationToken);

            return await Task.FromResult(PriceConversionResult.From(api_result));
        }

    }
}
