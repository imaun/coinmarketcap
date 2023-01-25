using System;
using Newtonsoft.Json;

namespace ImanN.CoinMarketCap.Models {
    
    public class AirdropData
    {
        [JsonProperty("id")]
        public string Id {get; set;}

        [JsonProperty("project_name")]
        public string ProjectName {get; set;}

        [JsonProperty("description")]
        public string Description {get; set;}

        [JsonProperty("status")]
        public string Status {get; set;}

        [JsonProperty("coin")]
        public AirdropCoinData Coin { get; set; }

        [JsonProperty("start_date")]
        public DateTimeOffset StartDate {get; set;}

        [JsonProperty("end_date")]
        public DateTimeOffset EndDate {get; set;}

        [JsonProperty("total_prize")]
        public long TotalPrize { get; set; }

        [JsonProperty("winner_count")]
        public int WinnerCount { get; set; }

        [JsonProperty("link")]
        public string Link { get; set; }

    }

    public class AirdropCoinData {
        
        [JsonProperty("id")]
        public long Id {get; set;}

        [JsonProperty("name")]
        public string Name {get; set;}

        [JsonProperty("slug")]
        public string Slug {get; set;}

        [JsonProperty("symbol")]
        public string Symbol {get; set;}
    }
}