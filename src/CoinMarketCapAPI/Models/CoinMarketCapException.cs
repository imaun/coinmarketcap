using System;

namespace ImanN.CoinMarketCap {

    public class CoinMarketCapException: Exception {

        public CoinMarketCapException(string message):base(message) { }
    }
}
