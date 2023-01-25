using Emun.CoinMarketCap.Models;

namespace Emun.CoinMarketCap {

    public class AirdropResult : ApiResponse<AirdropData> {

        public static AirdropResult From(ApiResponse<AirdropData> model)
            => new AirdropResult {
                Data = model.Data,
                Status = model.Status
            };

    }
}