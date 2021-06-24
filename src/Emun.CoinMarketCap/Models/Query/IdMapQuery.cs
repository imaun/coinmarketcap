using Newtonsoft.Json;
using Emun.CoinMarketCap;

namespace Emun.CoinMarketCap.Models
{
    public class IdMapQuery
    {
        [JsonIgnore]
        public ListingStatus ListingStatus { get; set; }

        public string listing_status => 
    }
}
