using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using Emun.CoinMarketCap.Models;

namespace Emun.CoinMarketCap
{
    /// <summary>
    /// API endpoints for cryptocurrency exchanges
    /// </summary>
    public interface IExchangeService {

        /// <summary>
        /// Returns a paginated list of all active cryptocurrency exchanges by CoinMarketCap ID. 
        /// We recommend using this convenience endpoint to lookup and utilize our unique exchange id across all endpoints 
        /// as typical exchange identifiers may change over time. As a convenience you may pass a comma-separated list of 
        /// exchanges by slug to filter this list to only those you require or the aux parameter to slim down the payload.
        /// This endpoint is available on the following API plans:
        /// [Startup, Standard, Professional, Enterprise]
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<ExchangeMapResult> MapAsync(
            ExchangeMapQuery request,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Returns a paginated list of all cryptocurrency exchanges including the latest aggregate market data for each exchange. 
        /// Use the "convert" option to return market values in multiple fiat and cryptocurrency conversions in the same call.
        /// This endpoint is available on the following API plans:
        /// [Standard, Professional, Enterprise]
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<ExchangeListingResult> ListingLatestAsync(
            ExchangeListingLatestQuery request,
            CancellationToken cancellationToken = default);
    }
}
