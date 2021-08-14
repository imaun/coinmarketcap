using System.Collections.Generic;
using Emun.CoinMarketCap.Models;

namespace Emun.CoinMarketCap {

    public class ExchangeListingResult : ApiResponse<List<ExchangeLatestData>> {

        public static ExchangeListingResult From(ApiResponse<List<ExchangeLatestData>> model)
            => new ExchangeListingResult {
                Data = model.Data,
                Status = model.Status
            };
    }
}
