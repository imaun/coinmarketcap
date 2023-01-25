using System.Collections.Generic;
using ImanN.CoinMarketCap.Models;

namespace ImanN.CoinMarketCap {

    public class ExchangeMapResult : ApiResponse<List<ExchangeMapData>> {

        public static ExchangeMapResult From(ApiResponse<List<ExchangeMapData>> model)
            => new ExchangeMapResult {
                Data = model.Data,
                Status = model.Status
            };

    }
}
