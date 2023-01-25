using ImanN.CoinMarketCap.Models;
using System.Collections.Generic;

namespace ImanN.CoinMarketCap {

    public class MetadataResult: ApiResponse<List<Dictionary<string, CryptoCurrencyData>>> {

        public static MetadataResult From(ApiResponse<List<Dictionary<string, CryptoCurrencyData>>> model)
            => new MetadataResult {
                Data = model.Data,
                Status = model.Status
            };

    }
}

