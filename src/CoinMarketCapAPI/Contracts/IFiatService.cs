using System.Threading;
using System.Threading.Tasks;

namespace ImanN.CoinMarketCap {

    /// <summary>
    /// API endpoints for fiat currencies.
    /// </summary>
    public interface IFiatService {

        /// <summary>
        /// Returns a mapping of all supported fiat currencies to unique CoinMarketCap ids. 
        /// Per our Best Practices we recommend utilizing CMC ID instead of currency symbols to securely identify assets 
        /// with our other endpoints and in your own application logic.
        /// Mapping data is updated only as needed, every 30 seconds.
        /// This endpoint is available on the following API plans:
        /// [Basic, Hobbyist, Startup, Standard, Professional, Enterprise]
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<FiatMapResult> MapAsync(
            FiatMapQuery request,
            CancellationToken cancellationToken = default);


    }
}
