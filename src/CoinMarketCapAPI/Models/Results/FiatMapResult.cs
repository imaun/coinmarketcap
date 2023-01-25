using System.Collections.Generic;
using ImanN.CoinMarketCap.Models;

namespace ImanN.CoinMarketCap {

    public class FiatMapResult : ApiResponse<List<FiatMapData>>  {

        public static FiatMapResult From(ApiResponse<List<FiatMapData>> model)
            => new FiatMapResult {
                Data = model.Data,
                Status = model.Status
            };
    }
}
