using Newtonsoft.Json;

namespace ImanN.CoinMarketCap {

    public class IdMapQuery {

        /// <summary>
        /// Only active cryptocurrencies are returned by default. Pass inactive to get a list of cryptocurrencies that are no longer active. 
        /// Pass untracked to get a list of cryptocurrencies that are listed but do not yet meet methodology requirements to have tracked markets available.
        /// You may pass one or more comma-separated values.
        /// </summary>
        [JsonIgnore]
        public ListingStatus ListingStatus { get; set; }

        [JsonProperty]
        public string listing_status => this.ListingStatus.ToStrValue();

        /// <summary>
        /// Optionally offset the start (1-based index) of the paginated list of items to return.
        /// </summary>
        [JsonProperty("start")]
        public int? Start { get; set; }

        /// <summary>
        /// Optionally specify the number of results to return. Use this parameter and the "start" parameter to determine your own pagination size.
        /// </summary>
        [JsonProperty("limit")]
        public int? Limit { get; set; }

        /// <summary>
        /// What field to sort the list of cryptocurrencies by.
        /// </summary>
        [JsonIgnore]
        public IdMapSort Sort { get; set; }
        
        [JsonProperty]
        public string sort => Sort.ToStrValue();

        /// <summary>
        /// Default : "platform,first_historical_data,last_historical_data,is_active"
        /// Optionally specify a comma-separated list of supplemental data fields to return. 
        /// Pass platform,first_historical_data,last_historical_data,is_active,status to include all auxiliary fields.
        /// </summary>
        [JsonProperty("aux")]
        public string Aux { get; set; }

    }
}
