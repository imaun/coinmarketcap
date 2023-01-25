using System;
using System.Collections.Generic;
using System.Text;

namespace Emun.CoinMarketCap
{
    public static class CoinMarketCapConst
    {

        public const string circulating_supply = "circulating_supply";
        public const string market_cap = "market_cap";
        public const string name = "name";
        public const string symbol = "symbol";
        public const string date_added = "date_added";


    }

    public static class CoinMarketCap_ListingStatus
    {
        public const string active = nameof(active);
        public const string inactive = nameof(inactive);
        public const string untracked = nameof(untracked);
        public const string all = active + ", " + inactive + ", " + untracked;
    }
}
