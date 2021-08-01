using Newtonsoft.Json;

namespace Emun.CoinMarketCap {

    public class QuotesHistoricalQuery {

        /// <summary>
        /// One or more comma-separated cryptocurrency CoinMarketCap IDs. Example: 1,2
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Alternatively pass one or more comma-separated cryptocurrency symbols. Example: "BTC,ETH". 
        /// At least one "id" or "slug" or "symbol" is required for this request.
        /// </summary>
        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        /// <summary>
        /// Timestamp (Unix or ISO 8601) to start returning quotes for. Optional, 
        /// if not passed, we'll return quotes calculated in reverse from "time_end".
        /// </summary>
        [JsonProperty("time_start")]
        public string TimeStart { get; set; }

        /// <summary>
        /// Timestamp (Unix or ISO 8601) to stop returning quotes for (inclusive). Optional, 
        /// if not passed, we'll default to the current time. If no "time_start" is passed, 
        /// we return quotes in reverse order starting from this time.
        /// </summary>
        [JsonProperty("time_end")]
        public string TimeEnd { get; set; }

        /// <summary>
        /// The number of interval periods to return results for. 
        /// Optional, required if both "time_start" and "time_end" aren't supplied.
        /// The default is 10 items. The current query limit is 10000.
        /// </summary>
        [JsonProperty("count")]
        public int Count { get; set; }

        /// <summary>
        /// Interval Options
        ///There are 2 types of time interval formats that may be used for "interval".
        /// The first are calendar year and time constants in UTC time:
        /// "hourly" - Get the first quote available at the beginning of each calendar hour.
        /// "daily" - Get the first quote available at the beginning of each calendar day.
        /// "weekly" - Get the first quote available at the beginning of each calendar week.
        /// "monthly" - Get the first quote available at the beginning of each calendar month.
        /// "yearly" - Get the first quote available at the beginning of each calendar year.
        /// The second are relative time intervals.
        /// "m": Get the first quote available every "m" minutes (60 second intervals). Supported minutes are: "5m", "10m", "15m", "30m", "45m".
        /// "h": Get the first quote available every "h" hours(3600 second intervals). Supported hour intervals are: "1h", "2h", "3h", "4h", "6h", "12h".
        /// "d": Get the first quote available every "d" days(86400 second intervals). Supported day intervals are: "1d", "2d", "3d", "7d", "14d", "15d", "30d", "60d", "90d", "365d".
        /// </summary>
        [JsonIgnore]
        public CoinMarketCapHistoricalInterval Interval { get; set; }

        [JsonProperty]
        public string interval => Interval.ToStrValue();

        /// <summary>
        /// Optionally calculate market quotes in up to 120 currencies at once by passing a comma-separated 
        /// list of cryptocurrency or fiat currency symbols. Each additional convert option beyond the first 
        /// requires an additional call credit. A list of supported fiat options can be found here. 
        /// Each conversion is returned in its own "quote" object.
        /// </summary>
        [JsonProperty("convert")]
        public string Convert { get; set; }

        /// <summary>
        /// Optionally calculate market quotes by CoinMarketCap ID instead of symbol. 
        /// This option is identical to convert outside of ID format.
        /// Ex: convert_id=1,2781 would replace convert=BTC,USD in your query. This parameter 
        /// cannot be used when convert is used.
        /// </summary>
        [JsonProperty("convert_id")]
        public string ConvertId { get; set; }

        /// <summary>
        /// Default : "num_market_pairs,cmc_rank,date_added,tags,platform,max_supply,circulating_supply,
        /// total_supply,is_active,is_fiat"
        /// Optionally specify a comma-separated list of supplemental data fields to return. 
        /// Pass num_market_pairs, cmc_rank, date_added, tags, platform, max_supply, circulating_supply, 
        /// total_supply, market_cap_by_total_supply, volume_24h_reported, volume_7d, volume_7d_reported, 
        /// volume_30d, volume_30d_reported, is_active, is_fiat 
        /// to include all auxiliary fields.
        /// </summary>
        [JsonProperty("aux")]
        public string Aux { get; set; }

        /// <summary>
        /// Pass true to relax request validation rules. When requesting records on multiple cryptocurrencies an error 
        /// is returned if no match is found for 1 or more requested cryptocurrencies. 
        /// If set to true, invalid lookups will be skipped allowing valid cryptocurrencies to still be returned.
        /// </summary>
        [JsonProperty("skin_invalid")]
        public bool SkipInvalid { get; set; }
    }

    public enum CoinMarketCapHistoricalInterval
    {
        Yearly,
        Monthly,
        Weekly,
        Daily,
        Hourly,
        _5m,
        _10m,
        _15m, 
        _30m,
        _45m,
        _1h,
        _2h,
        _3h,
        _4h,
        _6h,
        _12h,
        _24h,
        _1d,
        _2d,
        _3d,
        _7d,
        _14d,
        _15d,
        _30d,
        _60d,
        _90d,
        _365d
    }

}
