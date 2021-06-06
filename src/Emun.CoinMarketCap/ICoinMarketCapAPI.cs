using System.Threading;
using System.Threading.Tasks;
using Emun.CoinMarketCap.Models;

namespace Emun.CoinMarketCap {
    /// <summary>
    /// 
    /// </summary>
    public interface ICoinMarketCapAPI {

        /// <summary>
        /// Returns a paginated list of all active cryptocurrencies with latest market data. 
        /// The default "market_cap" sort returns cryptocurrency in order of CoinMarketCap's 
        /// market cap rank (as outlined in our methodology) but you may configure this call 
        /// to order by another market ranking field. Use the "convert" option to return market
        /// values in multiple fiat and cryptocurrency conversions in the same call.
        /// This endpoint is available on the following API plans:
        /// 
        /// </summary>
        /// <param name="request">Query data to filter output result.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Returns a paginated list of all active cryptocurrencies with latest market data</returns>
        Task<ListingLatestResult> GetListingsLatestAsync(
            ListingsLatestQuery request,
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
        Task<ListingLatestResult> GetQuotesLatestAsync(
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
