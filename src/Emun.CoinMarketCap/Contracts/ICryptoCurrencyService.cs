﻿using System.Threading;
using System.Threading.Tasks;

namespace Emun.CoinMarketCap
{
    public interface ICryptoCurrencyService
    {

        /// <summary>
        /// Returns a mapping of all cryptocurrencies to unique CoinMarketCap ids. Per our Best Practices 
        /// we recommend utilizing CMC ID instead of cryptocurrency symbols to securely identify cryptocurrencies with our other endpoints 
        /// and in your own application logic. Each cryptocurrency returned includes typical identifiers such as name, symbol, and token_address 
        /// for flexible mapping to id.
        /// This endpoint is available on the following API plans:
        /// [Basic, Hobbyist, Startup, Standard, Professional, Enterprise]
        /// </summary>
        /// <param name="request">Query data to filter data and apply paging.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Returns a mapping of all cryptocurrencies to unique CoinMarketCap ids. </returns>
        Task<IdMapResult> MapAsync(
            IdMapQuery request,
            CancellationToken cancellationToken);


        /// <summary>
        /// Returns a paginated list of all active cryptocurrencies with latest market data. 
        /// The default "market_cap" sort returns cryptocurrency in order of CoinMarketCap's 
        /// market cap rank (as outlined in our methodology) but you may configure this call 
        /// to order by another market ranking field. Use the "convert" option to return market
        /// values in multiple fiat and cryptocurrency conversions in the same call.
        /// This endpoint is available on the following API plans:
        /// [Basic, Hobbyist, Startup, Standard, Professional, Enterprise]
        /// </summary>
        /// <param name="request">Query data to filter output result.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Returns a paginated list of all active cryptocurrencies with latest market data</returns>
        Task<ListingResult> GetListingsLatestAsync(
            ListingsLatestQuery request,
            CancellationToken cancellationToken);


        /// <summary>
        /// This endpoint is identical in format to our /cryptocurrency/listings/latest endpoint but is used to retrieve historical daily ranking snapshots from the end of each UTC day.
        /// Daily snapshots reflect market data at the end of each UTC day and may be requested as far back as 2013-04-28 (as supported by your plan's historical limits).
        /// This endpoint is available on the following API plans:
        /// [Standard (3 months), Professional (12 months), Enterprise (Up to 6 years)]
        /// </summary>
        /// <param name="request">Query data to filter output result.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Returns a ranked and sorted list of all cryptocurrencies for a historical UTC date.</returns>
        Task<ListingResult> GetListingHistoricalAsync(
            ListingHistoricalQuery request,
            CancellationToken cancellationToken);

        /// <summary>
        /// Returns the latest market quote for 1 or more cryptocurrencies. Use the "convert" option to return 
        /// market values in multiple fiat and cryptocurrency conversions in the same call.
        /// This endpoint is available on the following API plans:
        /// Basic, Startup, Hobbyist, Standard, Professional, Enterprise
        /// </summary>
        /// <param name="request">Query data to filter output result.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Returns the latest market quote for 1 or more cryptocurrencies</returns>
        Task<ListingResult> GetQuotesLatestAsync(
            QuotesLatestQuery request,
            CancellationToken cancellationToken);

        /// <summary>
        /// Returns an interval of historic market quotes for any cryptocurrency based on time and interval parameters.
        /// A historic quote for every "interval" period between your "time_start" and "time_end" will be returned.
        /// If a "time_start" is not supplied, the "interval" will be applied in reverse from "time_end".
        /// If "time_end" is not supplied, it defaults to the current time.
        /// At each "interval" period, the historic quote that is closest in time to the requested time will be returned.
        /// If no historic quotes are available in a given "interval" period up until the next interval period, it will be skipped.
        /// More : https://coinmarketcap.com/api/documentation/v1/#operation/getV1CryptocurrencyQuotesHistorical
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>Returns an interval of historic market quotes for any cryptocurrency based on time and interval parameters.</returns>
        Task<QuotesHistoricalResult> GetQuotesHistoricalAsync(
            QuotesHistoricalQuery request,
            CancellationToken cancellationToken);


        /// <summary>
        /// Returns all static metadata available for one or more cryptocurrencies. 
        /// This information includes details like logo, description, official website URL, 
        /// social links, and links to a cryptocurrency's technical documentation.
        /// This endpoint is available on the following API plans:
        /// Basic, Startup, Hobbyist, Standard, Professional, Enterprise
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>Returns all static metadata available for one or more cryptocurrencies. </returns>
        Task<MetadataResult> GetMetadataAsync(
            MetadataQuery request,
            CancellationToken cancellationToken);

        /// <summary>
        /// Returns the latest OHLCV (Open, High, Low, Close, Volume) market values for one or more cryptocurrencies for the current UTC day.
        /// Since the current UTC day is still active these values are updated frequently. You can find the final calculated OHLCV values for 
        /// the last completed UTC day along with all historic days using /cryptocurrency/ohlcv/historical.
        /// This endpoint is available on the following API plans:
        /// Startup, Standard, Professional, Enterprise
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<LatestOhlcvResult> GetOhlcvLatestAsync(
            OhlcvQuery request,
            CancellationToken cancellationToken);
    }

}