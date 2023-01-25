using System;
using System.Collections.Generic;
using System.Text;
using Emun.CoinMarketCap.Models;

namespace Emun.CoinMarketCap {

    public class ExchangeMapResult : ApiResponse<List<ExchangeMapData>> {

        public static ExchangeMapResult From(ApiResponse<List<ExchangeMapData>> model)
            => new ExchangeMapResult {
                Data = model.Data,
                Status = model.Status
            };

    }
}
