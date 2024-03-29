﻿using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ImanN.CoinMarketCap.Models {

    public class LatestCryptoData {

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("cmc_rank")]
        public int CmcRank { get; set; }

        [JsonProperty("num_market_pairs")]
        public int NumberOfMarketPairs { get; set; }

        [JsonProperty("circulating_supply", NullValueHandling = NullValueHandling.Ignore)]
        public long? CirculatingSupply { get; set; }

        [JsonProperty("total_supply", NullValueHandling = NullValueHandling.Ignore)]
        public long? TotalSupply { get; set; }

        [JsonProperty("max_supply", NullValueHandling = NullValueHandling.Ignore)]
        public long? MaxSupply { get; set; }

        [JsonProperty("last_updated", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? LastUpdated { get; set; }

        [JsonProperty("date_added")]
        public DateTimeOffset? DateAdded { get; set; }

        [JsonProperty("tags")]
        public string[] Tags { get; set; }

        [JsonProperty("platform", NullValueHandling = NullValueHandling.Ignore)]
        public CryptoPlatform Platform { get; set; }

        [JsonProperty("quote")]
        public Dictionary<string, CryptoPriceQuote> Quote { get; set; }
    }
}
