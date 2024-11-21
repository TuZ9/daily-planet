using daily_planet_application.Services;
using daily_planet_domain.Interface.Services;
using daily_planet_infra.Context;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace daily_planet_infra.Extensions
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            return services
                .RegisterServices()
                .RegisterRepositories();
        }
        private static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            return services
                .AddScoped<IContentService, ContentService>();
        }
        private static IServiceCollection RegisterRepositories(this IServiceCollection services)
        {
            return services
                .AddScoped(_ => new AuroraDbContext());
                //.AddScoped<IFlowerRepository, FlowerRepository>()
                //.AddScoped<IStrainRepository, StrainRepository>();
        }
    }
}