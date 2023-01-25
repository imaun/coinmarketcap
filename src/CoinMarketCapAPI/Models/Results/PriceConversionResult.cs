using Emun.CoinMarketCap.Models;

namespace Emun.CoinMarketCap {

    public class PriceConversionResult : ApiResponse<PriceConversionData> {

        public static PriceConversionResult From(ApiResponse<PriceConversionData> model)
            => new PriceConversionResult {
                Data = model.Data,
                Status = model.Status
            };
    }
}
