# CoinMarketCap
CoinMarketCap API for .NET 

This is an easy to use wrapper around the CoinMarketCap Pro API providing services for calling the following endpoints :
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

# Project Status :
This project is under development and is in early stage. If you want to contribute, feel free to fork it.
