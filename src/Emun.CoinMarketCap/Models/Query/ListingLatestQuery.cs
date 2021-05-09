using Newtonsoft.Json;

namespace Emun.CoinMarketCap.Models.Query
{
    /// <summary>
    /// Returns a paginated list of all active cryptocurrencies with latest market data. The default "market_cap" sort returns cryptocurrency 
    /// in order of CoinMarketCap's market cap rank (as outlined in our methodology) but you may configure this call to order by another market 
    /// ranking field. Use the "convert" option to return market values in multiple fiat and cryptocurrency conversions in the same call.
    /// See: <seealso cref="https://pro.coinmarketcap.com/api/v1#operation/getV1CryptocurrencyListingsLatest"/> 
    /// </summary>
    public class ListingLatestQuery {


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
        /// Optionally specify a threshold of minimum USD price to filter results by.
        /// </summary>
        [JsonProperty("price_min")]
        public float MinimumPrice { get; set; }


        /// <summary>
        /// Optionally specify a threshold of maximum USD price to filter results by.
        /// </summary>
        [JsonProperty("price_max")]
        public float MaximumPrice { get; set; }

        /// <summary>
        /// Optionally specify a threshold of minimum market cap to filter results by.
        /// </summary>
        [JsonProperty("market_cap_min")]
        public float MinimumMarketCap { get; set; }

        [JsonProperty("market_cap_max")]
        public float MaximumMarketCap { get; set; }

        /// <summary>
        /// Optionally specify a threshold of minimum 24 hour USD volume to filter results by.
        /// </summary>
        [JsonProperty("volume_24h_min")]
        public float Minimum24hVolume { get; set; }

        /// <summary>
        /// Optionally specify a threshold of maximum 24 hour USD volume to filter results by.
        /// </summary>
        [JsonProperty("volume_24h_max")]
        public float Maximum24hVolume { get; set; }

        /// <summary>
        /// Optionally specify a threshold of minimum circulating supply to filter results by.
        /// </summary>
        [JsonProperty("circulating_supply_min")]
        public float MinimumCirculatingSupply { get; set; }

        /// <summary>
        /// Optionally specify a threshold of maximum circulating supply to filter results by.
        /// </summary>
        [JsonProperty("circulating_supply_max")]
        public float MaximumCirculatingSupply { get; set; }

        /// <summary>
        /// Optionally specify a threshold of minimum 24 hour percent change to filter results by.
        /// >=-100
        /// </summary>
        [JsonProperty("percent_change_24h_min")]
        public float MinimumPercentChange24h { get; set; }

        /// <summary>
        /// Optionally specify a threshold of maximum 24 hour percent change to filter results by.
        /// >=-100
        /// </summary>
        [JsonProperty("percent_change_24h_max")]
        public float MaximumPercentChange24h { get; set; }

        /// <summary>
        /// Optionally calculate market quotes in up to 120 currencies at once by passing a comma-separated list of cryptocurrency or 
        /// fiat currency symbols. Each additional convert option beyond the first requires an additional call credit. 
        /// A list of supported fiat options can be found here. Each conversion is returned in its own "quote" object.
        /// </summary>
        [JsonProperty("convert")]
        public string Convert { get; set; }

        /// <summary>
        /// Optionally calculate market quotes by CoinMarketCap ID instead of symbol. This option is identical to convert outside of ID format. Ex: convert_id=1,2781 would replace convert=BTC,USD in your query. This parameter cannot be used when convert is used.
        /// </summary>
        [JsonProperty("convert_id")]
        public string ConvertId { get; set; }


        /// <summary>
        /// What field to sort the list of cryptocurrencies by. Default is 'id' 
        /// Valid Values : 'cmc_rank' and 'id'
        /// </summary>
        private string sort => "id";


        public string Symbol { get; set; }

    }
}
