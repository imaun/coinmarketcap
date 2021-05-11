using System;
using Newtonsoft.Json;

namespace Emun.CoinMarketCap.Models {

    public class CryptoPriceQuote {

        [JsonProperty("price")]
        public double? Price { get; set; }

        [JsonProperty("volume_24h", NullValueHandling = NullValueHandling.Ignore)]
        public long? Volume24H { get; set; }

        [JsonProperty("percent_change_1h", NullValueHandling = NullValueHandling.Ignore)]
        public double? PercentChange1H { get; set; }

        [JsonProperty("percent_change_24h", NullValueHandling = NullValueHandling.Ignore)]
        public double? PercentChange24H { get; set; }

        [JsonProperty("percent_change_7d", NullValueHandling = NullValueHandling.Ignore)]
        public double? PercentChange7D { get; set; }

        [JsonProperty("market_cap")]
        public long? MarketCap { get; set; }

        [JsonProperty("last_updated")]
        public DateTimeOffset? LastUpdated { get; set; }

    }
}
