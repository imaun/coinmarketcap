﻿namespace ImanN.CoinMarketCap {

    /// <summary>
    /// Provides CoinMarketCap API Pro v1 endpoint services.
    /// According to the official docs : https://coinmarketcap.com/api/documentation/v1/
    /// </summary>
    public interface ICoinMarketCapAPI {

        ICryptoCurrencyService CryptoCurrency { get; }

        IToolsService Tools { get; }
    }
}
