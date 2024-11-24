using daily_planet_application.Static;
using daily_planet_domain.Interface.ApiClientService;
using daily_planet_infra.ApiClientService;
using Microsoft.Extensions.DependencyInjection;

namespace daily_planet_infra.Extensions
{
    public static class HttpClient
    {
        public static IServiceCollection AddHttpClients(this IServiceCollection services)
        {
            var serviceProvider = services.BuildServiceProvider();

            services.AddHttpClient<IGoogleRssApiClient, GoogleRssApiClient>(_ => _.BaseAddress = new Uri(RunTimeConfig.GoogleRssUrl));

            return services;
        }
    }
}