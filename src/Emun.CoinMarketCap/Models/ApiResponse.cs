using Newtonsoft.Json;

namespace Emun.CoinMarketCap {

    public class ApiResponse<T> where T: class {

        [JsonProperty("status")]
        public ApiStatus Status { get; set; }

        [JsonProperty("data")]
        public T Data { get; set; }
    }
}
