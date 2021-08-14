using System;
using System.Net;
using System.Linq;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading;
using System.Reflection;
using System.Threading.Tasks;
using System.Collections.Generic;
using Emun.CoinMarketCap.Models;
using Emun.CoinMarketCap.Internal;

namespace Emun.CoinMarketCap {

    /// <inheritdoc/>
    public class CoinMarketCapAPI: ICoinMarketCapAPI {

       
        public CoinMarketCapAPI(HttpClient httpClient, string apiKey) {
            CryptoCurrency = new CryptoCurrencyService(httpClient, apiKey);
            Tools = new ToolsService(httpClient, apiKey);
            Exchange = new ExchangeService(httpClient, apiKey);
            Fiat = new FiatService(httpClient, apiKey);
        }

        public ICryptoCurrencyService CryptoCurrency { get; private set; }

        public IToolsService Tools { get; private set; }

        public IExchangeService  Exchange { get; set; }

        public IFiatService Fiat { get; set; }
    }
}
