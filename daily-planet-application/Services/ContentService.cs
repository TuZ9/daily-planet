using daily_planet_domain.Entities;
using daily_planet_domain.Interface.Services;
using Microsoft.Extensions.Logging;
using System.Xml;

namespace daily_planet_application.Services
{
    public class ContentService : IContentService
    {
        private readonly ILogger<ContentService> _logger;

        public ContentService(ILogger<ContentService> logger) 
        {
            _logger = logger;
        }

        public async Task<List<News>> BuscarNoticiasAsync()
        {
            string url = "https://news.google.com/rss/search?q=tecnologia&hl=pt-BR&gl=BR&ceid=BR:pt-419";
            var noticias = new List<News>();

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);

                if (!response.IsSuccessStatusCode)
                    throw new Exception("Erro ao buscar notícias");

                string rssContent = await response.Content.ReadAsStringAsync();
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(rssContent);

                XmlNodeList items = xmlDoc.SelectNodes("//item");
                foreach (XmlNode item in items)
                {
                    var noticia = new News
                    {
                        Titulo = item["title"]?.InnerText,
                        Descricao = item["description"]?.InnerText,
                        Url = item["link"]?.InnerText,
                        DataPublicacao = DateTime.Parse(item["pubDate"]?.InnerText)
                    };
                    noticias.Add(noticia);
                }
            }
            return noticias;
        }
    }
}