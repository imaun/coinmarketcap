using System.Collections.Generic;
using Emun.CoinMarketCap.Models;

namespace Emun.CoinMarketCap {

    public class ListingResult: ApiResponse<List<LatestCryptoData>> {

        public static ListingResult From(ApiResponse<List<LatestCryptoData>> model) {
            return new ListingResult {
                Data = model.Data,
                Status = model.Status
            };
        }
    }
}
