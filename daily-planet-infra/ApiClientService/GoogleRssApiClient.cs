using daily_planet_application.Services;
using daily_planet_domain.Interface.ApiClientService;
using Microsoft.Extensions.Logging;
using System.Xml;

namespace daily_planet_infra.ApiClientService
{
    public class GoogleRssApiClient : ServiceClientBase<XmlDocument, GoogleRssApiClient>, IGoogleRssApiClient
    {
        public GoogleRssApiClient(HttpClient clientFactory, ILogger<GoogleRssApiClient> logger) : base(clientFactory, logger)
        {
        }
    }
}
