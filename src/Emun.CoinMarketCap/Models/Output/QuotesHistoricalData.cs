using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Emun.CoinMarketCap.Models {

    public class QuotesHistoricalData {

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("is_active")]
        public bool IsActive { get; set; }

        [JsonProperty("is_fiat")]
        public bool IsFiat { get; set; }

        [JsonProperty("quotes")]
        public IEnumerable<QuotesHistoricalItemData> Quotes { get; set; }

    }

    public class QuotesHistoricalItemData
    {

        [JsonProperty("timestamp")]
        public DateTimeOffset? TimeStamp { get; set; }

        [JsonProperty("quote")]
        public Dictionary<string, QuoteHistoricalPrice> Quote { get; set; }

    }
}
