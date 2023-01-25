using Newtonsoft.Json;

namespace ImanN.CoinMarketCap
{
    public class ExchangeListingLatestQuery
    {

        /// <summary>
        /// Optionally offset the start (1-based index) of the paginated list of items to return.
        /// </summary>
        [JsonProperty("start")]
        public int Start { get; set; } = 1;

        /// <summary>
        /// Optionally specify the number of results to return. Use this parameter and the "start" parameter to determine your own pagination size.
        /// </summary>
        [JsonProperty("limit")]
        public int Limit { get; set; } = 100;

        /// <summary>
        /// What field to sort the list of exchanges by.
        /// Valid values : "name""volume_24h""volume_24h_adjusted""exchange_score"
        /// </summary>
        [JsonProperty("sort")]
        public string Sort { get; set; } = "volume_24h";


        [JsonProperty("sort_dir")]
        private string sortDir => SortDirection.ToStrValue();

        /// <summary>
        /// The direction in which to order exchanges against the specified sort.
        /// </summary>
        [JsonIgnore]
        public SortDir SortDirection { get; set; }

        [JsonProperty]
        private string market_type => MarketType.ToStrValue();

        /// <summary>
        /// The type of exchange markets to include in rankings. This field is deprecated. Please use "all" for accurate sorting.
        /// Default : all
        /// </summary>
        [JsonIgnore]
        public ExchangeMarketType MarketType { get; set; }

        /// <summary>
        /// Optionally specify a comma-separated list of supplemental data fields to return. 
        /// Pass num_market_pairs,traffic_score,rank,exchange_score,effective_liquidity_24h,date_launched,fiats,visits 
        /// to include all auxiliary fields.
        /// </summary>
        [JsonProperty("aux")]
        public string Aux { get; set; } = "num_market_pairs,traffic_score,rank,exchange_score,effective_liquidity_24h";

        /// <summary>
        /// Optionally calculate market quotes in up to 120 currencies at once by passing a comma-separated list of cryptocurrency or fiat currency symbols. Each additional convert option beyond the first requires an additional call credit. 
        /// A list of supported fiat options can be found here: https://coinmarketcap.com/api/documentation/v1/#section/Standards-and-Conventions.
        /// Each conversion is returned in its own "quote" object.
        /// </summary>
        [JsonProperty("convert")]
        public string Convert { get; set; }


        /// <summary>
        /// Optionally calculate market quotes by CoinMarketCap ID instead of symbol. 
        /// This option is identical to convert outside of ID format. Ex: convert_id=1,2781 would replace convert=BTC,USD in your query. 
        /// This parameter cannot be used when convert is used.
        /// </summary>
        [JsonProperty("convert_id")]
        public string ConvertId { get; set; }
    }
}
