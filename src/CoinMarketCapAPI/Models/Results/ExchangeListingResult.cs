using System.Collections.Generic;
using ImanN.CoinMarketCap.Models;

namespace ImanN.CoinMarketCap {

    public class ExchangeListingResult : ApiResponse<List<ExchangeLatestData>> {

        public static ExchangeListingResult From(ApiResponse<List<ExchangeLatestData>> model)
            => new ExchangeListingResult {
                Data = model.Data,
                Status = model.Status
            };
    }
}
