using System.Collections.Generic;
using Emun.CoinMarketCap.Models;

namespace Emun.CoinMarketCap
{
    public class OhlcvLatestResult : ApiResponse<Dictionary<string, LatestOhlcvData>>
    {

        public static OhlcvLatestResult From(ApiResponse<Dictionary<string, LatestOhlcvData>> model)
            => new OhlcvLatestResult {
                Data = model.Data,
                Status = model.Status
            };
    }

    public class OhlcvHistoricalResult : ApiResponse<OhlcvHistoricalData>
    {

        public static OhlcvHistoricalResult From(ApiResponse<OhlcvHistoricalData> model)
            => new OhlcvHistoricalResult {
                Data = model.Data,
                Status = model.Status
            };
    }
}
