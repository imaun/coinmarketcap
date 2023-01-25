using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Emun.CoinMarketCap.Models {

    public class ExchangeLatestData {

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("num_market_pairs")]
        public int NumberOfMarketPairs { get; set; }

        [JsonProperty("fiats")]
        public string[] Fiats { get; set; }

        [JsonProperty("visits")]
        public string Visits { get; set; }

        [JsonProperty("traffic_score")]
        public int TrafficScore { get; set; }

        [JsonProperty("rank")]
        public int Rank { get; set; }

        [JsonProperty("exchange_score")]
        public double ExchangeScore { get; set; }

        [JsonProperty("liquidity_score")]
        public double LiquidityScore { get; set; }

        [JsonProperty("last_updated")]
        public DateTimeOffset LastUpdated { get; set; }

        [JsonProperty("quote")]
        public Dictionary<string, List<ExchangeQouteData>> Quotes { get; set; }
    }

    public class ExchangeQouteData
    {

        [JsonProperty("volume_24h")]
        public double Volume24h { get; set; }

        [JsonProperty("volume_24h_adjusted")]
        public double Volume24hAdjusted { get; set; }

        [JsonProperty("volume_7d")]
        public double Volume7d { get; set; }

        [JsonProperty("volume_30d")]
        public double Volume30d { get; set; }

        [JsonProperty("percent_change_volume_24h")]
        public double PercentChangeVolume24h { get; set; }

        [JsonProperty("percent_change_volume_7d")]
        public double PercentChangeVolume7d { get; set; }

        [JsonProperty("percent_change_volume_30d")]
        public double PercentChangeVolume30d { get; set; }

        [JsonProperty("effective_liquidity_24h")]
        public double EffectiveLiquidity24h { get; set; }

        [JsonProperty("derivative_volume_usd")]
        public double DerivativeVolumeUsd { get; set; }

        [JsonProperty("spot_volume_usd")]
        public double SpotVolumeUsd { get; set; }
    }
}
