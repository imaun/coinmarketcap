using System;

namespace Emun.CoinMarketCap {

    public static class Extensions {

        public static string ToStr(this ListingLatestOrder order) {
            switch(order) {
                case ListingLatestOrder.CirculatingSupply: return "circulating_supply";
                case ListingLatestOrder.MarketCap: return "market_cap";
                case ListingLatestOrder.Name: return "name";
                case ListingLatestOrder.Symbol: return "symbol";
                case ListingLatestOrder.DateAdded: return "date_added";
                case ListingLatestOrder.MarketCapStrict: return "market_cap_strict";
                case ListingLatestOrder.Price: return "price";
                case ListingLatestOrder.TotalSupply: return "total_supply";
                case ListingLatestOrder.MaxSupply: return "max_supply";
                case ListingLatestOrder.NumberOfMarketPairs: return "num_market_pairs";
                case ListingLatestOrder.Volume24h: return "volume_24h";
                case ListingLatestOrder.PercentChange1h: return "percent_change_1h";
                case ListingLatestOrder.PercentChange24h: return "percent_change_24h";
                case ListingLatestOrder.PercentChange7d: return "percent_change_7d";
                case ListingLatestOrder.MarketCapByTotalSupplyStrict: return "market_cap_by_total_supply_strict";
                case ListingLatestOrder.Volume7d: return "volume_7d";
                case ListingLatestOrder.Volume30d: return "volume_30d";
                default: return "market_cap"; // according to API docs the default order is 'market_cap'
            };
        }

        public static string ToStr(this SortDir dir)
            => dir == SortDir.Asc ? "asc" : "desc";

        public static string ToStr(this CryptoType cryptoType) {
            switch(cryptoType) {
                case CryptoType.All: return "all";
                case CryptoType.Coins: return "coins";
                case CryptoType.Tokens: return "tokens";
                default: return "all";
            }
        }

        public static string ToStr(this CryptoTag tag) {
            switch(tag) {
                case CryptoTag.All: return "all";
                case CryptoTag.DeFi: return "defi";
                case CryptoTag.FileSharing: return "filesharing";
                default: return "all";
            }
        }

        private static DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public static DateTime FromUnixTime(this Int64 unixTime) 
            => epoch.AddSeconds(unixTime);
        
        public static long ToUnixTime(this DateTime date) 
            => Convert.ToInt64((date.ToUniversalTime() - epoch).TotalSeconds);
        
    }
}
