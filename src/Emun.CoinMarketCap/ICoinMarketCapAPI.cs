using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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
        /// </summary>
        /// <param name="request">Request to filter output result.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Returns a paginated list of all active cryptocurrencies with latest market data</returns>
        Task<ListingLatestResult> GetListingsLatestAsync(
            ListingsLatestQuery request,
            CancellationToken cancellationToken);


    }
}
