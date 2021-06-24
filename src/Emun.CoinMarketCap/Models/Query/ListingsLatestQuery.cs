using Newtonsoft.Json;

namespace Emun.CoinMarketCap {

    /// <summary>
    /// Returns a paginated list of all active cryptocurrencies with latest market data. The default "market_cap" sort returns cryptocurrency 
    /// in order of CoinMarketCap's market cap rank (as outlined in our methodology) but you may configure this call to order by another market 
    /// ranking field. Use the "convert" option to return market values in multiple fiat and cryptocurrency conversions in the same call.
    /// See: <seealso cref="https://pro.coinmarketcap.com/api/v1#operation/getV1CryptocurrencyListingsLatest"/> 
    /// </summary>
    public class ListingsLatestQuery {

        /// <summary>
        /// Optionally offset the start (1-based index) of the paginated list of items to return.
        /// Default = 1; Must be >= 1
        /// </summary>
        [JsonProperty("start")]
        public int Start { get; set; } = 1;

        /// <summary>
        /// Optionally specify the number of results to return. Use this parameter and the "start" parameter to determine your own pagination size.
        /// Default = 100; Range = 1...5000
        /// </summary>
        [JsonProperty("limit")]
        public int? Limit { get; set; } = 100;

        /// <summary>
        /// Optionally specify a threshold of minimum USD price to filter results by.
        /// </summary>
        [JsonProperty("price_min")]
        public double? MinimumPrice { get; set; }

        /// <summary>
        /// Optionally specify a threshold of maximum USD price to filter results by.
        /// </summary>
        [JsonProperty("price_max")]
        public double? MaximumPrice { get; set; }

        /// <summary>
        /// Optionally specify a threshold of minimum market cap to filter results by.
        /// </summary>
        [JsonProperty("market_cap_min")]
        public double? MinimumMarketCap { get; set; }

        [JsonProperty("market_cap_max")]
        public double? MaximumMarketCap { get; set; }

        /// <summary>
        /// Optionally specify a threshold of minimum 24 hour USD volume to filter results by.
        /// </summary>
        [JsonProperty("volume_24h_min")]
        public double? Minimum24hVolume { get; set; }

        /// <summary>
        /// Optionally specify a threshold of maximum 24 hour USD volume to filter results by.
        /// </summary>
        [JsonProperty("volume_24h_max")]
        public double? Maximum24hVolume { get; set; }

        /// <summary>
        /// Optionally specify a threshold of minimum circulating supply to filter results by.
        /// </summary>
        [JsonProperty("circulating_supply_min")]
        public double? MinimumCirculatingSupply { get; set; }

        /// <summary>
        /// Optionally specify a threshold of maximum circulating supply to filter results by.
        /// </summary>
        [JsonProperty("circulating_supply_max")]
        public double? MaximumCirculatingSupply { get; set; }

        /// <summary>
        /// Optionally specify a threshold of minimum 24 hour percent change to filter results by.
        /// >=-100
        /// </summary>
        [JsonProperty("percent_change_24h_min")]
        public double? MinimumPercentChange24h { get; set; }

        /// <summary>
        /// Optionally specify a threshold of maximum 24 hour percent change to filter results by.
        /// >=-100
        /// </summary>
        [JsonProperty("percent_change_24h_max")]
        public double? MaximumPercentChange24h { get; set; }

        /// <summary>
        /// Optionally calculate market quotes in up to 120 currencies at once by passing a comma-separated list of cryptocurrency or 
        /// fiat currency symbols. Each additional convert option beyond the first requires an additional call credit. 
        /// A list of supported fiat options can be found here. Each conversion is returned in its own "quote" object.
        /// </summary>
        [JsonProperty("convert")]
        public string Convert { get; set; }

        /// <summary>
        /// Optionally calculate market quotes by CoinMarketCap ID instead of symbol. This option is identical to convert outside of ID format.
        /// Ex: convert_id=1,2781 would replace convert=BTC,USD in your query. This parameter cannot be used when convert is used.
        /// </summary>
        [JsonProperty("convert_id")]
        public string ConvertId { get; set; }

        [JsonProperty("sort")]
        private string sort => SortBy.ToStrValue();
        /// <summary>
        /// What field to sort the list of cryptocurrencies by.
        /// </summary>
        [JsonIgnore]
        public ListingLatestOrder SortBy { get; set; }

        [JsonProperty("sort_dir")]
        private string sortDir => SortDirection.ToStrValue();

        /// <summary>
        /// The direction in which to order cryptocurrencies against the specified sort.
        /// </summary>
        [JsonIgnore]
        public SortDir SortDirection { get; set; }

        [JsonProperty("cryptocurrency_type")]
        private string cryptocurrencyType => CryptocurrencyType.ToStrValue();

        /// <summary>
        /// The type of cryptocurrency to include. Default is 'all'
        /// </summary>
        [JsonIgnore]
        public CryptoType CryptocurrencyType { get; set; }

        [JsonProperty("tag")]
        private string tag => Tag.ToStrValue();

        /// <summary>
        /// The tag of cryptocurrency to include.
        /// Default is 'all'
        /// </summary>
        [JsonIgnore]
        public CryptoTag Tag { get; set; }

    }
}
