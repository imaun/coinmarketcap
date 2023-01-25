using Newtonsoft.Json;

namespace ImanN.CoinMarketCap {

    public class ExchangeMapQuery {

        /// <summary>
        /// Only active exchanges are returned by default. Pass inactive to get a list of exchanges that are no longer active. 
        /// Pass untracked to get a list of exchanges that are registered but do not currently meet methodology requirements 
        /// to have active markets tracked. You may pass one or more comma-separated values.
        /// default : `active`
        /// </summary>
        [JsonIgnore]
        public ListingStatus ListingStatus { get; set; }

        [JsonProperty]
        public string listing_status => this.ListingStatus.ToStrValue();

        /// <summary>
        /// Optionally pass a comma-separated list of exchange slugs (lowercase URL friendly shorthand name with spaces replaced with dashes)
        /// to return CoinMarketCap IDs for. If this option is passed, other options will be ignored.
        /// </summary>
        public string Slug { get; set; }

        /// <summary>
        /// Optionally offset the start (1-based index) of the paginated list of items to return.
        /// </summary>
        public int Start { get; set; } = 1;

        /// <summary>
        /// Optionally specify the number of results to return. Use this parameter and the "start" parameter to determine your own pagination size.
        /// </summary>
        public int Limit { get; set; }

        /// <summary>
        /// What field to sort the list of exchanges by.
        /// Valid values : "volume_24h", "id"
        /// </summary>
        [JsonProperty("sort")]
        public string Sort { get; set; } = "id";

        /// <summary>
        /// Default : "first_historical_data,last_historical_data,is_active" 
        /// Optionally specify a comma-separated list of supplemental data fields to return. 
        /// Pass first_historical_data, last_historical_data, is_active, status to include all auxiliary fields.
        /// </summary>
        [JsonProperty("aux")]
        public string Aux { get; set; }

        /// <summary>
        /// Optionally include one fiat or cryptocurrency IDs to filter market pairs by. 
        /// For example ?crypto_id=1 would only return exchanges that have BTC.
        /// </summary>
        public string CryptoId { get; set; }

    }
}
