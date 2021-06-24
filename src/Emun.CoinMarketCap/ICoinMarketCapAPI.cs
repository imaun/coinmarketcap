using System.Threading;
using System.Threading.Tasks;
using Emun.CoinMarketCap.Models;

namespace Emun.CoinMarketCap {

    /// <summary>
    /// Provides CoinMarketCap API v1 endpoint services.
    /// According to the official docs : https://coinmarketcap.com/api/documentation/v1/
    /// </summary>
    public interface ICoinMarketCapAPI {

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


    }
}
