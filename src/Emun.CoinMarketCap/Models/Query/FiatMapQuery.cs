using Newtonsoft.Json;

namespace Emun.CoinMarketCap {

    /// <summary>
    /// 
    /// </summary>
    public class FiatMapQuery
    {

        /// <summary>
        /// Optionally offset the start (1-based index) of the paginated list of items to return. Default : 1
        /// </summary>
        [JsonProperty("start")]
        public int Start { get; set; } = 1;

        /// <summary>
        /// Optionally specify the number of results to return. Use this parameter and the "start" parameter to determine your own pagination size.
        /// </summary>
        [JsonProperty("limit")]
        public int Limit { get; set; }

        /// <summary>
        /// What field to sort the list by.
        /// Valid fields : [id, name]
        /// </summary>
        [JsonProperty("sort")]
        public string Sort { get; set; }

        /// <summary>
        /// Pass true to include precious metals.
        /// </summary>
        [JsonProperty("include_metals")]
        public bool IncludeMetals { get; set; }
    }
}
