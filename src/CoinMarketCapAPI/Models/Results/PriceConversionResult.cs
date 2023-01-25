using ImanN.CoinMarketCap.Models;

namespace ImanN.CoinMarketCap {

    public class PriceConversionResult : ApiResponse<PriceConversionData> {

        public static PriceConversionResult From(ApiResponse<PriceConversionData> model)
            => new PriceConversionResult {
                Data = model.Data,
                Status = model.Status
            };
    }
}
