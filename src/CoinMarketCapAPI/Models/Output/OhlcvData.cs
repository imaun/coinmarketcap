using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace ImanN.CoinMarketCap.Models
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

    public class OhlcvHistoricalData
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("quotes")]
        public IEnumerable<OhlcvHistoricalQuoteTimeData> Quotes { get; set; }

    }

    public class OhlcvHistoricalQuoteTimeData
    {
        [JsonProperty("time_open")]
        public DateTimeOffset? TimeOpen { get; set; }

        [JsonProperty("time_close")]
        public DateTimeOffset? TimeClose { get; set; }

        [JsonProperty("time_high")]
        public DateTimeOffset? TimeHigh { get; set; }

        [JsonProperty("time_low")]
        public DateTimeOffset? TimeLow { get; set; }

        [JsonProperty("quote")]
        public Dictionary<string, OhlcvHistoricalQuoteData> Quote { get; set; }
    }

    public class OhlcvHistoricalQuoteData
    {
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

        [JsonProperty("market_cap")]
        public double MarketCap { get; set; }

        [JsonProperty("timestamp")]
        public DateTimeOffset TimeStamp { get; set; }
    }
}
