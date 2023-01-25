using System.Collections.Generic;
using ImanN.CoinMarketCap.Models;

namespace ImanN.CoinMarketCap
{
    public class QuotesHistoricalResult : ApiResponse<List<QuotesHistoricalData>>
    {

        public static QuotesHistoricalResult From(ApiResponse<List<QuotesHistoricalData>> model)
            => new QuotesHistoricalResult {
                Data = model.Data,
                Status = model.Status
            };
        
    }
}
