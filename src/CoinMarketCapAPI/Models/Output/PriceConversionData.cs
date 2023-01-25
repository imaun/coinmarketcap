using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ImanN.CoinMarketCap.Models {
    
    public class PriceConversionData {


        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("last_updated")]
        public DateTimeOffset? LastUpdated { get; set; }

        [JsonProperty("quote")]
        public Dictionary<string, CryptoSinglePriceQuote> Quote { get; set; }
    }
}
