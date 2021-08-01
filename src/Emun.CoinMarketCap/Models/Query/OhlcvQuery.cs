using Newtonsoft.Json;

namespace Emun.CoinMarketCap
{
    public class OhlcvQuery
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
}
