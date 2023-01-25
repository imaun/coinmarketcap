using System;
using Newtonsoft.Json;

namespace ImanN.CoinMarketCap.Models {

    public class CryptoCurrencyIdMapData {

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("is_active")]
        public bool IsActive { get; set; }

        [JsonProperty("first_historical_data", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? FirstHistoricalData { get; set; }

        [JsonProperty("last_historical_data", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? LastHistoricalData { get; set; }

        [JsonProperty("platform", NullValueHandling = NullValueHandling.Ignore)]
        public CryptoPlatform Platform { get; set; }
    }
}
