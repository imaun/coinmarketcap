using Newtonsoft.Json;

namespace ImanN.CoinMarketCap.Models {

    public class ExchangeMetadataQuery {

        /// <summary>
        /// One or more comma-separated CoinMarketCap cryptocurrency exchange ids. Example: "1,2"
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Alternatively, one or more comma-separated exchange names in URL friendly shorthand "slug" format (all lowercase, spaces replaced with hyphens). 
        /// Example: "binance,gdax". 
        /// At least one "id" or "slug" is required.
        /// </summary>
        [JsonProperty("slug")]
        public string Slug { get; set; }

        /// <summary>
        /// Optionally specify a comma-separated list of supplemental data fields to return. 
        /// Pass urls,logo,description,date_launched,notice,status to include all auxiliary fields.
        /// </summary>
        [JsonProperty("aux")]
        public string Aux { get; set; } = "urls,logo,description,date_launched,notice";
    }
}
