using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Emun.CoinMarketCap.Models {

    public class ExchangeMetadata {

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("logo")]
        public string Logo { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("date_launched")]
        public DateTimeOffset DateLaunched { get; set; }

        [JsonProperty("notice")]
        public string Notice { get; set; }

        [JsonProperty("countries")]
        public string[] Countries { get; set; }

        [JsonProperty("fiat")]
        public string[] Fiat { get; set; }

        [JsonProperty("tags")]
        public string[] Tags { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("marker_fee")]
        public double? MakerFee { get; set; }

        [JsonProperty("taker_fee")]
        public double? TakerFee { get; set; }

        [JsonProperty("spot_volume_usd")]
        public double SpotVolumeUsd { get; set; }

        [JsonProperty("spot_volume_last_updated")]
        public DateTimeOffset SpotVolumeLastUpdated { get; set; }

        [JsonProperty("urls")]
        public Dictionary<string, string[]> URLs { get; set; }

    }
}
