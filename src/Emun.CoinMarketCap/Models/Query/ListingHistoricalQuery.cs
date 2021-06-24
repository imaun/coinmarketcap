using Newtonsoft.Json;

namespace Emun.CoinMarketCap.Models.Query {

    public class ListingHistoricalQuery {

        /// <summary>
        /// Required. date (Unix or ISO 8601) to reference day of snapshot.
        /// </summary>
        [JsonProperty]
        public string date { get; set; }

        /// <summary>
        /// Optionally offset the start (1-based index) of the paginated list of items to return.
        /// Default = 1. Must be >= 1
        /// </summary>
        [JsonProperty("start")]
        public int Start { get; set; } = 1;


        /// <summary>
        /// Optionally specify the number of results to return. Use this parameter and the "start" parameter to determine your own pagination size.
        /// Default = 100; Range = 1...5000
        /// </summary>
        [JsonProperty("limit")]
        public int Limit { get; set; } = 100;

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

        [JsonProperty("cryptocurrency_type")]
        private string cryptocurrencyType => CryptocurrencyType.ToStrValue();

        /// <summary>
        /// The type of cryptocurrency to include. Default is 'all'
        /// </summary>
        [JsonIgnore]
        public CryptoType CryptocurrencyType { get; set; }

        /// <summary>
        /// Optionally specify a comma-separated list of supplemental data fields to return. 
        /// Pass platform,tags,date_added,circulating_supply,total_supply,max_supply,cmc_rank,num_market_pairs to include all auxiliary fields.
        /// Default : "platform,tags,date_added,circulating_supply,total_supply,max_supply,cmc_rank,num_market_pairs"
        /// </summary>
        [JsonProperty("aux")]
        public string Aux { get; set; }
    }
}
