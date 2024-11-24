using daily_planet_application.Services;
using daily_planet_domain.Interface.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace daily_planet_infra.Extensions
{
    public class BackgroundJobs : BackgroundService
    {
        private readonly ILogger<BackgroundJobs> _logger;
        private readonly IServiceProvider _service;
        private readonly IContentService _contentService;
        public BackgroundJobs(ILogger<BackgroundJobs> logger, IServiceProvider service, IContentService contentService)
        {
            _contentService = contentService;
            _service = service;
            _logger = logger;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var job = Task.Run(() => Start(stoppingToken), stoppingToken);
            _logger.LogInformation("Start Background Jobs");
            //await Task.WhenAll(job);
            await job;
        }

        private async Task Start(CancellationToken tokenStop)
        {
            await using var scoped = _service.CreateAsyncScope();
            var scopedService = scoped.ServiceProvider;

            while (!tokenStop.IsCancellationRequested)
            {

            }
        }
    }
}
