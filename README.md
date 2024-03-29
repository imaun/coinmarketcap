# CoinMarketCap
#### CoinMarketCap API for .NET 

This is an easy to use wrapper around the [CoinMarketCap API](https://coinmarketcap.com/api/documentation/v1/) providing services for calling the following endpoints :
### CryptoCurrencyService
- `cryptocurrency/map` Returns a mapping of all cryptocurrencies to unique CoinMarketCap `id`s
- `cryptocurrency/info` - Returns all static metadata available for one or more cryptocurrencies
- `cryptocurrency/listings/historical` Returns a ranked and sorted list of all cryptocurrencies for a historical UTC date.
- `cryptocurrency/listings/latest` Returns a paginated list of all active cryptocurrencies with latest market data
- `cryptocurrency/market-pairs/latest` Lists all active market pairs that CoinMarketCap tracks for a given cryptocurrency or fiat currency
- `cryptocurrency/ohlcv/historical` Returns historical OHLCV (Open, High, Low, Close, Volume) data along with market cap for any cryptocurrency using time interval parameters.
- `cryptocurrency/ohlcv/latest` Returns the latest OHLCV (Open, High, Low, Close, Volume) market values for one or more cryptocurrencies for the current UTC day
- `cryptocurrency/quotes/historical` Returns an interval of historic market quotes for any cryptocurrency based on time and interval parameters.
- `cryptocurrency/quotes/latest` Returns the latest market quote for 1 or more cryptocurrencies.

### ToolsService
- `tools/price-conversion` Convert an amount of one cryptocurrency or fiat currency into one or more different currencies utilizing the latest market rate for each currency.

### FiatService
- `fiat/map` API endpoints for fiat currencies. Returns a mapping of all supported fiat currencies to unique CoinMarketCap ids.

## How to use
### 1. Clone this repo :
```cli
git clone https://github.com/imaun/coinmarketcap.git
```
### 2. Build 
```cli
dotnet build
```

### or Alternatively install `ImanN.CoinMarketCap` from nuget :
```cli
dotnet add package ImanN.CoinMarketCap --version 1.0.0
```
or with package manager console :
```cli
Install-Package ImanN.CoinMarketCap -Version 1.0.0
```

### 3. Get your own API Key from [here](https://pro.coinmarketcap.com/signup/)

### 4. Add CoinMarketCapAPI services in startup
```cs
public void ConfigureServices(IServiceCollection services)
{
    //...
    services.AddCoinMarketCapAPI(apiKey: "YourApiKey");
    //...
}
```
### 5. Inject `ICoinMarketCapAPI` and use it
```cs
using System.Threading.Tasks;
using ImanN.CoinMarketCap;

namespace Sample {

    public class SampleController : Controller {

        private readonly ICoinMarketCapAPI _client;

        public SampleController(ICoinMarketCapAPI client) {
            _client = client ?? throw new ArgumentNullException(nameof(client));

            var result = await _client.CryptoCurrency.GetListingsLatestAsync(new ListingsLatestQuery {
                Limit = 100,
                Start = 1
            });
        }
    }

}
```

## Questions & Contact
You can contact me via email : imun22 at gmail or hi at imaun.ir

