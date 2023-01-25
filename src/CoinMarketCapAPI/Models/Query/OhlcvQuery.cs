using System;
using Newtonsoft.Json;

namespace ImanN.CoinMarketCap
{

    public class OhlcvLatestQuery
    {

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
        /// Pass true to relax request validation rules. When requesting records on multiple cryptocurrencies an error 
        /// is returned if no match is found for 1 or more requested cryptocurrencies. 
        /// If set to true, invalid lookups will be skipped allowing valid cryptocurrencies to still be returned.
        /// </summary>
        [JsonProperty("skin_invalid")]
        public bool SkipInvalid { get; set; }
    }

    public class OhlcvHistoricalQuery
    {

        /// <summary>
        /// One or more comma-separated cryptocurrency CoinMarketCap IDs. Example: 1,2
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Alternatively pass a comma-separated list of cryptocurrency slugs. Example: "bitcoin,ethereum"
        /// </summary>
        [JsonProperty("slug")]
        public string Slug { get; set; }


        /// <summary>
        /// Alternatively pass one or more comma-separated cryptocurrency symbols. Example: "BTC,ETH". 
        /// At least one "id" or "slug" or "symbol" is required for this request.
        /// </summary>
        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        /// <summary>
        /// Time period to return OHLCV data for. The default is "daily". See the main endpoint description for details.
        /// Default is : daily
        /// </summary>
        [JsonIgnore]
        public OhlcvTimePeriod TimePeriod { get; set; }

        [JsonProperty("time_period")]
        public string time_period => TimePeriod.ToStrValue();

        /// <summary>
        ///Timestamp (Unix or ISO 8601) to start returning OHLCV time periods for. 
        ///Only the date portion of the timestamp is used for daily OHLCV so it's recommended to send an ISO date format like "2018-09-19" without time.
        /// </summary>
        [JsonIgnore]
        public DateTimeOffset? TimeStart { get; set; }

        [JsonProperty]
        public string time_start => TimeStart.ToStrDate();

        /// <summary>
        /// Timestamp (Unix or ISO 8601) to stop returning OHLCV time periods for (inclusive). Optional, if not passed we'll default to the current time. 
        /// Only the date portion of the timestamp is used for daily OHLCV so it's recommended to send an ISO date format like "2018-09-19" without time.
        /// </summary>
        [JsonIgnore]
        public DateTimeOffset? TimeEnd { get; set; }

        [JsonProperty]
        public string time_end => TimeEnd.ToStrDate();

        /// <summary>
        /// Optionally limit the number of time periods to return results for. The default is 10 items. The current query limit is 10000 items.
        /// </summary>
        [JsonProperty("count")]
        public int Count { get; set; } = 10;

        /// <summary>
        /// Optionally adjust the interval that "time_period" is sampled. See main endpoint description for available options.
        /// Default is : daily
        /// </summary>
        [JsonIgnore]
        public CoinMarketCapHistoricalInterval Interval { get; set; }

        [JsonProperty]
        public string interval => Interval.ToStrValue();

        /// <summary>
        /// By default market quotes are returned in USD. Optionally calculate market quotes in up to 3 fiat currencies or cryptocurrencies.
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
        /// Pass true to relax request validation rules. When requesting records on multiple cryptocurrencies an error 
        /// is returned if no match is found for 1 or more requested cryptocurrencies. 
        /// If set to true, invalid lookups will be skipped allowing valid cryptocurrencies to still be returned.
        /// </summary>
        [JsonProperty("skin_invalid")]
        public bool SkipInvalid { get; set; }
    }
}
