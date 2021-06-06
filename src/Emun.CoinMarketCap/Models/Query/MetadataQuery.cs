using Newtonsoft.Json;

namespace Emun.CoinMarketCap.Models {

    public class MetadataQuery {

        /// <summary>
        /// One or more comma-separated CoinMarketCap cryptocurrency IDs.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Alternatively pass a comma-separated list of cryptocurrency slugs. Example: "bitcoin,ethereum"
        /// </summary>
        [JsonProperty("slug")]
        public string Slug { get; set; }

        /// <summary>
        /// Alternatively pass one or more comma-separated cryptocurrency symbols. 
        /// Example: "BTC,ETH". At least one "id" or "slug" or "symbol" is required for this request.
        /// </summary>
        [JsonProperty("symbol")]
        public string Symbol { get; set; }


        /// <summary>
        /// "urls,logo,description,tags,platform,date_added,notice"
        /// Optionally specify a comma-separated list of supplemental data fields to return. 
        /// Pass urls, logo, description, tags, platform, date_added, notice, status to include all auxiliary fields.
        /// </summary>
        [JsonProperty("aux")]
        public string Aux { get; set; }

    }
}
