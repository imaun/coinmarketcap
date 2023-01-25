using System;
using System.Collections.Generic;
using System.Text;
using Emun.CoinMarketCap.Models;

namespace Emun.CoinMarketCap {

    public class FiatMapResult : ApiResponse<List<FiatMapData>>  {

        public static FiatMapResult From(ApiResponse<List<FiatMapData>> model)
            => new FiatMapResult {
                Data = model.Data,
                Status = model.Status
            };
    }
}
