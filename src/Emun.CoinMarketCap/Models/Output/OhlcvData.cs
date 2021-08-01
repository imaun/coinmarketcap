using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Emun.CoinMarketCap.Models
{
    public class LatestOhlcvData
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("last_updated")]
        public DateTimeOffset? LastUpdated { get; set; }

        [JsonProperty("time_open")]
        public DateTimeOffset? TimeOpen { get; set; }

        [JsonProperty("time_close")]
        public DateTimeOffset? TimeClose { get; set; }

        [JsonProperty("time_high")]
        public DateTimeOffset? TimeHigh { get; set; } 

        [JsonProperty("time_low")]
        public DateTimeOffset? TimeLow { get; set; }

        [JsonProperty("quote")]
        public Dictionary<string, OhlcvQuoteData> Quote { get; set; }
    }

    public class OhlcvQuoteData { 

        [JsonProperty("open")]
        public double Open { get; set; }

        [JsonProperty("high")]
        public double High { get; set; }

        [JsonProperty("low")]
        public double Low { get; set; }

        [JsonProperty("close")]
        public double Close { get; set; }

        [JsonProperty("volume")]
        public double Volume { get; set; }

        [JsonProperty("last_updated")]
        public DateTimeOffset? LastUpdated { get; set; }
    }
}
