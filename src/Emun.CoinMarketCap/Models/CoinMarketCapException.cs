using System;

namespace Emun.CoinMarketCap {

    public class CoinMarketCapException: Exception {

        public CoinMarketCapException(string message):base(message) { }
    }
}
