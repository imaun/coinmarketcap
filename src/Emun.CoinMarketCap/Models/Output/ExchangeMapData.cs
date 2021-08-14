using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Emun.CoinMarketCap.Models
{
    public class ExchangeMapData
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("is_active")]
        public bool IsActive { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("first_historical_data")]
        public DateTimeOffset FirstHistoricalDate { get; set; }

        [JsonProperty("last_historical_data")]
        public DateTimeOffset LastHistoricalDate { get; set; }

    }
}
