using System;

namespace ImanN.CoinMarketCap {

    internal static class Extensions {

        public static string ToStrDate(this DateTimeOffset? value)
            => value.HasValue
                    ? value.Value.UtcDateTime.ToString("yyyy-MM-dd")
                    : null;

        public static string ToStrValue(this OhlcvTimePeriod period)
            => period switch {
                OhlcvTimePeriod.Daily => "daily",
                OhlcvTimePeriod.Hourly => "hourly",
                _=> "daily" // according to API docs the default value is daily
            };

        public static string ToStrValue(this ListingLatestOrder order) 
            => order switch {
                ListingLatestOrder.CirculatingSupply => "circulating_supply",
                ListingLatestOrder.MarketCap => "market_cap",
                ListingLatestOrder.Name => "name",
                ListingLatestOrder.Symbol => "symbol",
                ListingLatestOrder.DateAdded => "date_added",
                ListingLatestOrder.MarketCapStrict => "market_cap_strict",
                ListingLatestOrder.Price => "price",
                ListingLatestOrder.TotalSupply => "total_supply",
                ListingLatestOrder.MaxSupply => "max_supply",
                ListingLatestOrder.NumberOfMarketPairs => "num_market_pairs",
                ListingLatestOrder.Volume24h => "volume_24h",
                ListingLatestOrder.PercentChange1h => "percent_change_1h",
                ListingLatestOrder.PercentChange24h => "percent_change_24h",
                ListingLatestOrder.PercentChange7d => "percent_change_7d",
                ListingLatestOrder.MarketCapByTotalSupplyStrict => "market_cap_by_total_supply_strict",
                ListingLatestOrder.Volume7d => "volume_7d",
                ListingLatestOrder.Volume30d => "volume_30d",
                _ => "market_cap",// according to API docs the default order is 'market_cap'
            };

        public static string ToStrValue(this CoinMarketCapHistoricalInterval interval)
            => interval switch {
                CoinMarketCapHistoricalInterval.Yearly => "yearly",
                CoinMarketCapHistoricalInterval.Monthly => "monthly",
                CoinMarketCapHistoricalInterval.Weekly => "weekly",
                CoinMarketCapHistoricalInterval.Daily => "daily",
                CoinMarketCapHistoricalInterval.Hourly => "hourly",
                CoinMarketCapHistoricalInterval._5m => "5m",
                CoinMarketCapHistoricalInterval._10m => "10m",
                CoinMarketCapHistoricalInterval._15m => "15m",
                CoinMarketCapHistoricalInterval._30m => "30m",
                CoinMarketCapHistoricalInterval._45m => "45m",
                CoinMarketCapHistoricalInterval._1h => "1h",
                CoinMarketCapHistoricalInterval._2h => "2h",
                CoinMarketCapHistoricalInterval._3h => "3h",
                CoinMarketCapHistoricalInterval._4h => "4h",
                CoinMarketCapHistoricalInterval._6h => "6h",
                CoinMarketCapHistoricalInterval._12h => "12h",
                CoinMarketCapHistoricalInterval._24h => "24h",
                CoinMarketCapHistoricalInterval._1d => "1d",
                CoinMarketCapHistoricalInterval._2d => "2d",
                CoinMarketCapHistoricalInterval._3d => "3d",
                CoinMarketCapHistoricalInterval._7d => "7d",
                CoinMarketCapHistoricalInterval._14d => "14d",
                CoinMarketCapHistoricalInterval._15d => "15d",
                CoinMarketCapHistoricalInterval._30d => "30d",
                CoinMarketCapHistoricalInterval._60d => "60d",
                CoinMarketCapHistoricalInterval._90d => "90d",
                CoinMarketCapHistoricalInterval._365d => "365d",
                _=> "5m" //according to API docs the default is 5m
            };

        public static string ToStrValue(this SortDir dir)
            => dir == SortDir.Asc ? "asc" : "desc";

        public static string ToStrValue(this ExchangeMarketType marketType)
            => marketType switch {
                ExchangeMarketType.All => "all",
                ExchangeMarketType.Fees => "fees",
                ExchangeMarketType.NoFees => "nofees",
                _=> "all"
            };

        public static string ToStrValue(this CryptoType cryptoType) 
            => cryptoType switch {
                CryptoType.All => "all",
                CryptoType.Coins => "coins",
                CryptoType.Tokens => "tokens",
                _ => "all",
            };

        public static string ToStrValue(this CryptoTag tag) 
            => tag switch {
                CryptoTag.All => "all",
                CryptoTag.DeFi => "defi",
                CryptoTag.FileSharing => "filesharing",
                _ => "all",
            };

        public static string ToStrValue(this ListingStatus status)
            => status switch {
                ListingStatus.Active => CoinMarketCap_ListingStatus.active,
                ListingStatus.Inactive => CoinMarketCap_ListingStatus.inactive,
                ListingStatus.Untracked => CoinMarketCap_ListingStatus.untracked,
                ListingStatus.ActiveAndInactive => $"{CoinMarketCap_ListingStatus.active}, {CoinMarketCap_ListingStatus.inactive}",
                ListingStatus.ActiveAndUntracked => $"{CoinMarketCap_ListingStatus.active}, {CoinMarketCap_ListingStatus.untracked}",
                ListingStatus.InactiveAndUntracked => $"{CoinMarketCap_ListingStatus.inactive}, {CoinMarketCap_ListingStatus.untracked}",
                ListingStatus.All => CoinMarketCap_ListingStatus.all,
                _ => CoinMarketCap_ListingStatus.active
            };

        public static string ToStrValue(this IdMapSort sort)
            => sort switch {
                IdMapSort.Id => "id",
                IdMapSort.Rank => "cmc_rank",
                _=> "id"
            };

        private static DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public static DateTime FromUnixTime(this Int64 unixTime) 
            => epoch.AddSeconds(unixTime);
        
        public static long ToUnixTime(this DateTime date) 
            => Convert.ToInt64((date.ToUniversalTime() - epoch).TotalSeconds);
        
    }
}
