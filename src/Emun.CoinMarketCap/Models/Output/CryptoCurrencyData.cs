using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Emun.CoinMarketCap.Models
{
    public class CryptoCurrencyData {


        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("urls")]
        public Dictionary<string, string[]> URLs { get; set; }

        [JsonProperty("logo")]
        public string Logo { get; set; }
        
        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("date_added")]
        public DateTimeOffset? DateAdded { get; set; }

        [JsonProperty("tags")]
        public string[] Tags { get; set; }

        [JsonProperty("platform", NullValueHandling = NullValueHandling.Ignore)]
        public CryptoPlatform Platform { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }


    }
}
