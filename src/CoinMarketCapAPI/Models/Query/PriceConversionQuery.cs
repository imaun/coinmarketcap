using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Emun.CoinMarketCap {
    
    public class PriceConversionQuery {

        /// <summary>
        /// An amount of currency to convert. Example: 10.43
        /// </summary>
        [JsonProperty("amount")]
        public double Amount { get; set; }

        /// <summary>
        /// The CoinMarketCap currency ID of the base cryptocurrency or fiat to convert from. Example: "1"
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Alternatively the currency symbol of the base cryptocurrency or fiat to convert from. Example: "BTC". One "id" or "symbol" is required.
        /// </summary>
        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        /// <summary>
        /// Optional timestamp (Unix or ISO 8601) to reference historical pricing during conversion.
        /// If not passed, the current time will be used.
        /// If passed, we'll reference the closest historic values available for this conversion.
        /// </summary>
        [JsonProperty("time")]
        public string Time { get; set; }

        /// <summary>
        /// Pass up to 120 comma-separated fiat or cryptocurrency symbols to convert the source amount to.
        /// </summary>
        [JsonProperty("convert")]
        public string Convert { get; set; }

        /// <summary>
        /// Optionally calculate market quotes by CoinMarketCap ID instead of symbol. This option is identical to convert outside of ID format.
        /// Ex: convert_id=1,2781 would replace convert=BTC,USD in your query. This parameter cannot be used when convert is used.
        /// </summary>
        [JsonProperty("convert_id")]
        public string ConvertId { get; set; }
    }
}
