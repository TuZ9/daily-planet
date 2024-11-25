using daily_planet_application.Static;
using daily_planet_domain.Entities;
using daily_planet_domain.Interface.ApiClientService;
using daily_planet_domain.Interface.Services;
using Microsoft.Extensions.Logging;
using System.Xml;

namespace daily_planet_application.Services
{
    public class ContentService : IContentService
    {
        private readonly ILogger<ContentService> _logger;
        private readonly IGoogleRssApiClient _googleRssApiClient;

        public ContentService(ILogger<ContentService> logger, IGoogleRssApiClient googleRssApiClient) 
        {
            _logger = logger;
            _googleRssApiClient = googleRssApiClient;
        }

        public async Task ProcessNews()
        {
            var list = new List<News>();
            foreach (var item in RunTimeConfig.SearchList)
            {
                var news = await BuscarNoticiasAsync(item);
                list.AddRange(news);
            }

            _logger.LogInformation("rodando");
        }

        public async Task<List<News>> BuscarNoticiasAsync(string search)
        {
            string url = $"https://news.google.com/rss/search?q={search}&hl=pt-BR&gl=BR&ceid=BR:pt-419";
            var noticias = new List<News>();

            var contents = await _googleRssApiClient.GetXmlAsync($"search?q={search}&hl=pt-BR&gl=BR&ceid=BR:pt-419");

            foreach (XmlNode item in contents)
            {
                var noticia = new News
                {
                    IdContent = Guid.NewGuid(),
                    Title = item["title"]?.InnerText,
                    Description = item["description"]?.InnerText,
                    Url = item["link"]?.InnerText,
                    DatePublication = DateTime.Parse(item["pubDate"]?.InnerText)
                };
                noticias.Add(noticia);
            }

            return noticias;
        }
    }
}