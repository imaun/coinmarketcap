using Emun.CoinMarketCap.Models;

namespace Emun.CoinMarketCap {

    public class IdMapResult: ApiResponse<CryptoCurrencyIdMapData> {

        public static IdMapResult From(ApiResponse<CryptoCurrencyIdMapData> model)
            => new IdMapResult {
                Data = model.Data,
                Status = model.Status
            };
    }
}
