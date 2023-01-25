using System.Net.Http;
using ImanN.CoinMarketCap.Internal;

namespace ImanN.CoinMarketCap {

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
