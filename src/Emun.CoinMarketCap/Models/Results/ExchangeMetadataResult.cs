using System;
using System.Collections.Generic;
using Emun.CoinMarketCap.Models;

namespace Emun.CoinMarketCap {

    public class ExchangeMetadataResult : ApiResponse<Dictionary<string, List<ExchangeMetadata>>> {

        public static ExchangeMetadataResult From(ApiResponse<Dictionary<string, List<ExchangeMetadata>>> model)
            => new ExchangeMetadataResult {
                Data = model.Data,
                Status = model.Status
            };
    }
}
