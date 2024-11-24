using daily_planet_domain.Interface.Services;
using Microsoft.Extensions.Logging;

namespace daily_planet_application.Services
{
    public class SearchService : ISearchService
    {
        private readonly ILogger<SearchService> _logger;

        public SearchService(ILogger<SearchService> logger)
        {
            _logger = logger;
        }


    }
}
