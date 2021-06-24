using Emun.CoinMarketCap.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Emun.CoinMarketCap
{
    public class ListingLatestResult: ApiResponse<List<LatestCryptoData>>
    {

        public static ListingLatestResult From(ApiResponse<List<LatestCryptoData>> model) {
            return new ListingLatestResult {
                Data = model.Data,
                Status = model.Status
            };
        }
    }
}
