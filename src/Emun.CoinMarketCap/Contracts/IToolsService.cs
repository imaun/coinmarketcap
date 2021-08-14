using System.Threading;
using System.Threading.Tasks;

namespace Emun.CoinMarketCap
{
    /// <summary>
    /// API endpoints for convenience utilities.
    /// </summary>
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
            CancellationToken cancellationToken = default);
    }
}
