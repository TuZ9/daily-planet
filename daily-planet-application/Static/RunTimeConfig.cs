using Microsoft.Extensions.Configuration;
using System.Diagnostics;

namespace daily_planet_application.Static
{
    public static class RunTimeConfig
    {
        public static string? Auroraconnection;
        public static string? Mongoconnection = "";
        public static string GoogleRssUrl  = "https://news.google.com/rss/";
        //search?q=tecnologia&hl=pt-BR&gl=BR&ceid=BR:pt-419
        public static string CannabisEndpoint = "https://api.otreeba.com/";

        public static void SetConfigs(ConfigurationManager configuration)
        {
            if (Debugger.IsAttached)
            {
                Auroraconnection = "host=localhost;Database=postgres;username=postgres;password=12345678;";
                Mongoconnection = configuration.GetConnectionString("Mongoconnection");
            }
            else
            {
                Auroraconnection = Environment.GetEnvironmentVariable("Auroraconnection");
                Mongoconnection = Environment.GetEnvironmentVariable("Mongoconnection");
            }
        }

    }
}
