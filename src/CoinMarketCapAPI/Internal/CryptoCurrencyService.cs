using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using ImanN.CoinMarketCap.Models;

namespace ImanN.CoinMarketCap.Internal {

    internal class CryptoCurrencyService : CoinMarketCapBaseService, ICryptoCurrencyService {

        public CryptoCurrencyService(HttpClient httpClient, string apiKey) 
            : base(httpClient, apiKey) { }


        const string _urlPrefix = "cryptocurrency";

        /// <inheritdoc/>
        public async Task<ListingResult> GetListingsLatestAsync(
            ListingsLatestQuery request,
            CancellationToken cancellationToken = default) {

            request.CheckArgumentIsNull(nameof(request));

            var api_result = await getApiResponseAsync<List<LatestCryptoData>>
                (request, $"{_urlPrefix}/listings/latest", cancellationToken);

            return await Task.FromResult(ListingResult.From(api_result));
        }

        /// <inheritdoc/>
        public async Task<ListingResult> GetListingHistoricalAsync(
            ListingHistoricalQuery request,
            CancellationToken cancellationToken = default) {

            request.CheckArgumentIsNull(nameof(request));

            if (string.IsNullOrWhiteSpace(request.date))
                throw new ArgumentNullException("date");

            var api_result = await base.getApiResponseAsync<List<LatestCryptoData>>
                (request, $"{_urlPrefix}/listings/historical", cancellationToken);

            return await Task.FromResult(ListingResult.From(api_result));
        }

        /// <inheritdoc />
        public async Task<ListingResult> GetQuotesLatestAsync(
            QuotesLatestQuery request,
            CancellationToken cancellationToken = default) {

            request.CheckArgumentIsNull(nameof(request));

            var api_result = await getApiResponseAsync<List<LatestCryptoData>>
                (request, $"{_urlPrefix}/quotes/latest", cancellationToken);

            return await Task.FromResult(ListingResult.From(api_result));
        }

        /// <inheritdoc />
        public async Task<QuotesHistoricalResult> GetQuotesHistoricalAsync(
            QuotesHistoricalQuery request,
            CancellationToken cancellationToken = default) {

            request.CheckArgumentIsNull(nameof(request));

            var api_result = await getApiResponseAsync<List<QuotesHistoricalData>>
                (request, $"{_urlPrefix}/quotes/historical", cancellationToken);

            return await Task.FromResult(QuotesHistoricalResult.From(api_result));
        }

        /// <inheritdoc />
        public async Task<MetadataResult> GetInfoAsync(
            MetadataQuery request,
            CancellationToken cancellationToken = default) {

            request.CheckArgumentIsNull(nameof(request));

            var api_result = await getApiResponseAsync
                <List<Dictionary<string, CryptoCurrencyData>>>
                    (request, $"{_urlPrefix}/info", cancellationToken);

            return await Task.FromResult(MetadataResult.From(api_result));
        }

        /// <inheritdoc />
        public async Task<IdMapResult> MapAsync(
            IdMapQuery request,
            CancellationToken cancellationToken = default) {

            request.CheckArgumentIsNull(nameof(request));

            var api_result = await getApiResponseAsync<List<CryptoCurrencyIdMapData>>
                (request, $"{_urlPrefix}/map", cancellationToken);

            return await Task.FromResult(IdMapResult.From(api_result));
        }

        /// <inheritdoc />
        public async Task<OhlcvLatestResult> GetOhlcvLatestAsync(
            OhlcvLatestQuery request,
            CancellationToken cancellationToken = default) {

            request.CheckArgumentIsNull(nameof(request));

            var api_result = await getApiResponseAsync<Dictionary<string, LatestOhlcvData>>
               (request, $"{_urlPrefix}/ohlcv/latest", cancellationToken);

            return await Task.FromResult(OhlcvLatestResult.From(api_result));
        }

        /// <inheritdoc />
        public async Task<OhlcvHistoricalResult> GetOhlcvHistoricalAsync(
            OhlcvHistoricalQuery request,
            CancellationToken cancellationToken = default) {

            request.CheckArgumentIsNull(nameof(request));

            var api_result = await getApiResponseAsync<OhlcvHistoricalData>
                (request, $"{_urlPrefix}/ohlcv/historical", cancellationToken);

            return await Task.FromResult(OhlcvHistoricalResult.From(api_result));
        }

        /// <inheritdoc />
        public async Task<AirdropResult> GetAirdropAsync(string id, CancellationToken cancellationToken = default) {
            if(string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));

            var api_result = await getApiResponseAsync<AirdropData>
                (id, $"{_urlPrefix}/airdrop", cancellationToken);

            return await Task.FromResult(AirdropResult.From(api_result));
        }

    }
}
