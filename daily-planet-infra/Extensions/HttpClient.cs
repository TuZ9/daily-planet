using daily_planet_application.Static;
using daily_planet_domain.Interface.ApiClientService;
using daily_planet_infra.ApiClientService;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace daily_planet_infra.Extensions
{
    public static class HttpClient
    {
        public static IServiceCollection AddHttpClients(this IServiceCollection services)
        {
            var serviceProvider = services.BuildServiceProvider();

            services.AddHttpClient<IGoogleRssApiClient, GoogleRssApiClient>(_ => _.BaseAddress = new Uri(RunTimeConfig.GoogleRssUrl));
            //services.AddHttpClient<IXboxAchievementApiClient, XboxAchievementApiClient>(_ => _.BaseAddress = new Uri(RunTimeConfig.XboxEndpoint));
            //services.AddHttpClient<IXboxUserApiClient, XboxUserApiClient>(_ => _.BaseAddress = new Uri(RunTimeConfig.XboxEndpoint));

            return services;
        }
    }
}