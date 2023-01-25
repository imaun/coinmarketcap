using Newtonsoft.Json;

namespace ImanN.CoinMarketCap.Models
{
    public class FiatMapData
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("sign")]
        public string Sign { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

    }
}
