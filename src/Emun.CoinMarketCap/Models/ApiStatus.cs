using System;
using Newtonsoft.Json;

namespace Emun.CoinMarketCap {

    public class ApiStatus {

        [JsonProperty("timestamp")]
        public DateTimeOffset Timestamp { get; set; }

        [JsonProperty("error_code")]
        public int error_code { get; set; }

        public CoinMarketCapError ErrorCode => (CoinMarketCapError)error_code;


        [JsonProperty("error_message")]
        public string ErrorMessage { get; set; }

        [JsonProperty("elapsed")]
        public long Elapsed { get; set; }

        [JsonProperty("credit_count")]
        public long CreditCount { get; set; }

        [JsonIgnore]
        public bool HasError => error_code > 0;
    }
}
