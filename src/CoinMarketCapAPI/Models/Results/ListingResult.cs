using System.Collections.Generic;
using ImanN.CoinMarketCap.Models;

namespace ImanN.CoinMarketCap {

    public class ListingResult: ApiResponse<List<LatestCryptoData>> {

        public static ListingResult From(ApiResponse<List<LatestCryptoData>> model) {
            return new ListingResult {
                Data = model.Data,
                Status = model.Status
            };
        }
    }
}
