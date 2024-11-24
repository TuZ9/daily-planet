using daily_planet_domain.Interface.Services;
using Microsoft.Extensions.DependencyInjection;

namespace daily_planet_infra.Extensions
{
    public static class HangireJobs
    {
        public static async void RunHangFireJob(ServiceProvider services)
        {
            await RunJobs(services);
        }

        public static async Task RunJobs(ServiceProvider services)
        {
            using var scope = services.CreateScope();
            var service = scope.ServiceProvider.GetRequiredService<IContentService>();
            await service.BuscarNoticiasAsync("tecnologia");
            //BackgroundJob.Enqueue(() => service.BuildBase());
        }
    }
}
