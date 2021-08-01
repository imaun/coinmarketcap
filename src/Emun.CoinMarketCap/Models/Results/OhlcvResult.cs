using System.Collections.Generic;
using Emun.CoinMarketCap.Models;

namespace Emun.CoinMarketCap
{
    public class LatestOhlcvResult : ApiResponse<Dictionary<string, LatestOhlcvData>>
    {

        public static LatestOhlcvResult From(ApiResponse<Dictionary<string, LatestOhlcvData>> model)
            => new LatestOhlcvResult {
                Data = model.Data,
                Status = model.Status
            };
    }
}
