using Emun.CoinMarketCap.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Emun.CoinMarketCap.Internal
{


    internal class CryptoCurrencyService : CoinMarketCapBaseService, ICryptoCurrencyService
    {

        public CryptoCurrencyService(HttpClient httpClient, string apiKey) 
            : base(httpClient, apiKey) { }


        /// <inheritdoc/>
        public async Task<ListingResult> GetListingsLatestAsync(
            ListingsLatestQuery request,
            CancellationToken cancellationToken) {

            request.CheckArgumentIsNull(nameof(request));

            var api_result = await getApiResponseAsync<List<LatestCryptoData>>
                (request, "cryptocurrency/listings/latest", cancellationToken);

            return await Task.FromResult(ListingResult.From(api_result));
        }

        /// <inheritdoc/>
        public async Task<ListingResult> GetListingHistoricalAsync(
            ListingHistoricalQuery request,
            CancellationToken cancellationToken) {

            request.CheckArgumentIsNull(nameof(request));

            if (string.IsNullOrWhiteSpace(request.date))
                throw new ArgumentNullException("date");

            var api_result = await base.getApiResponseAsync<List<LatestCryptoData>>
                (request, "cryptocurrency/listings/historical", cancellationToken);

            return await Task.FromResult(ListingResult.From(api_result));
        }

        /// <inheritdoc />
        public async Task<ListingResult> GetQuotesLatestAsync(
            QuotesLatestQuery request,
            CancellationToken cancellationToken) {

            request.CheckArgumentIsNull(nameof(request));

            var api_result = await getApiResponseAsync<List<LatestCryptoData>>
                (request, "cryptocurrency/quotes/latest", cancellationToken);

            return await Task.FromResult(ListingResult.From(api_result));
        }

        /// <inheritdoc />
        public async Task<QuotesHistoricalResult> GetQuotesHistoricalAsync(
            QuotesHistoricalQuery request,
            CancellationToken cancellationToken) {

            request.CheckArgumentIsNull(nameof(request));

            var api_result = await getApiResponseAsync<List<QuotesHistoricalData>>
                (request, "cryptocurrency/quotes/historical", cancellationToken);

            return await Task.FromResult(QuotesHistoricalResult.From(api_result));
        }

        /// <inheritdoc />
        public async Task<MetadataResult> GetMetadataAsync(
            MetadataQuery request,
            CancellationToken cancellationToken) {

            request.CheckArgumentIsNull(nameof(request));

            var api_result = await getApiResponseAsync
                <List<Dictionary<string, CryptoCurrencyData>>>
                    (request, "cryptocurrency/info", cancellationToken);

            return await Task.FromResult(MetadataResult.From(api_result));
        }

        /// <inheritdoc />
        public async Task<IdMapResult> MapAsync(
            IdMapQuery request,
            CancellationToken cancellationToken) {

            request.CheckArgumentIsNull(nameof(request));

            var api_result = await getApiResponseAsync<List<CryptoCurrencyIdMapData>>
                (request, "cryptocurrency/map", cancellationToken);

            return await Task.FromResult(IdMapResult.From(api_result));
        }

    }
}
