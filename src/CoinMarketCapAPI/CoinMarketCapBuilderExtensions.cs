using System.Net.Http;
using ImanN.CoinMarketCap;

namespace Microsoft.Extensions.DependencyInjection {

    public static class CoinMarketCapBuilderExtensions {

        public static IServiceCollection AddCoinMarketCapAPI(
            this IServiceCollection services,
            string apiKey) {

            services.AddHttpClient();
            var clientFactory = services.BuildServiceProvider()
                .GetRequiredService<IHttpClientFactory>();
            var httpClient = clientFactory.CreateClient();
            services.AddTransient(_ => new CoinMarketCapAPI(httpClient, apiKey));

            return services;
        }
    }
}
