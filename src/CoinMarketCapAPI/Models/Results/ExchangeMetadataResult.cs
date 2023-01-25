using System.Collections.Generic;
using ImanN.CoinMarketCap.Models;

namespace ImanN.CoinMarketCap {

    public class ExchangeMetadataResult : ApiResponse<Dictionary<string, List<ExchangeMetadata>>> {

        public static ExchangeMetadataResult From(ApiResponse<Dictionary<string, List<ExchangeMetadata>>> model)
            => new ExchangeMetadataResult {
                Data = model.Data,
                Status = model.Status
            };
    }
}
