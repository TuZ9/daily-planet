using daily_planet_domain.Interface.ApiClientService;
using Microsoft.Extensions.Logging;
using System.Net.Mime;
using System.Text;
using System.Text.Json;

namespace daily_planet_application.Services
{
    public abstract class ServiceClientBase<TEntity, TYEntity> : IServiceClientBase<TEntity> where TEntity : class where TYEntity : class
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<TYEntity> _logger;

        protected ServiceClientBase(HttpClient clientFactory, ILogger<TYEntity> logger)
        {
            _httpClient = clientFactory;
            _logger = logger;
        }
        public async Task DeleteAsync(string url)
        {
            try
            {

                _logger.LogInformation("Delete from url: {0}", url);
                using var httpResponseMessage = await _httpClient.DeleteAsync(url);

                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    httpResponseMessage.EnsureSuccessStatusCode();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Resourse Server {0} return an error {1}", url, ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<TEntity>> SendListAsync(string url, string token)
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, url);
                request.Headers.Add("x-authorization", token);
                using var httpResponseMessage = await _httpClient.SendAsync(request);
                _logger.LogInformation("Get from url: {0}", url);

                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    var contentStream = await httpResponseMessage.Content.ReadAsStreamAsync();
                    var result = JsonSerializer.Deserialize<IEnumerable<TEntity>>(contentStream);
                    return result;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Resourse Server {0} return an error {1}", url, ex.Message);
                throw new Exception(ex.Message);
            }
            return null;
        }

        public async Task<TEntity> SendAsync(string url, string token)
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, url);
                request.Headers.Add("x-authorization", token);
                using var httpResponseMessage = await _httpClient.SendAsync(request);
                _logger.LogInformation("Get from url: {0}", url);

                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    var contentStream = await httpResponseMessage.Content.ReadAsStreamAsync();
                    var result = JsonSerializer.Deserialize<TEntity>(contentStream);
                    return result;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Resourse Server {0} return an error {1}", url, ex.Message);
                throw new Exception(ex.Message);
            }
            return null;
        }

        public async Task<TEntity> GetAsync(string url)
        {
            try
            {
                using var httpResponseMessage = await _httpClient.GetAsync(url);
                _logger.LogInformation("Get from url: {0}", url);

                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    var contentStream = await httpResponseMessage.Content.ReadAsStreamAsync();
                    var result = JsonSerializer.Deserialize<TEntity>(contentStream);
                    return result;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Resourse Server {0} return an error {1}", url, ex.Message);
                throw new Exception(ex.Message);
            }
            return null;
        }

        public async Task<IEnumerable<TEntity>> GetListAsync(string url)
        {
            try
            {

                _logger.LogInformation("Get from url: {0}", url);
                using var httpResponseMessage = await _httpClient.GetAsync(url);

                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    var contentStream = await httpResponseMessage.Content.ReadAsStreamAsync();

                    var result = JsonSerializer.Deserialize<IEnumerable<TEntity>>(contentStream);
                    return result;
                }
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError("Resourse Server {0} return an error {1}", url, ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public async Task PostAsync(string url, TEntity obj)
        {
            try
            {
                _logger.LogInformation("Save from url: {0}", url);

                var body = new StringContent(JsonSerializer.Serialize(obj), Encoding.UTF8, MediaTypeNames.Application.Json);
                using var httpResponseMessage = await _httpClient.PostAsync(url, body);

                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    httpResponseMessage.EnsureSuccessStatusCode();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Resourse Server {0} return an error {1}", url, ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public async Task PostAsync(string url, IEnumerable<TEntity> obj)
        {
            try
            {
                _logger.LogInformation("Save from url: {0}", url);

                var body = new StringContent(JsonSerializer.Serialize(obj), Encoding.UTF8, MediaTypeNames.Application.Json);
                using var httpResponseMessage = await _httpClient.GetAsync(url);

                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    httpResponseMessage.EnsureSuccessStatusCode();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Resourse Server {0} return an error {1}", url, ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public async Task PutAsync(string url, TEntity obj)
        {
            try
            {
                _logger.LogInformation("Save from url: {0}", url);

                var body = new StringContent(JsonSerializer.Serialize(obj), Encoding.UTF8, MediaTypeNames.Application.Json);
                using var httpResponseMessage = await _httpClient.PutAsync(url, body);

                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    httpResponseMessage.EnsureSuccessStatusCode();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Resourse Server {0} return an error {1}", url, ex.Message);
                throw new Exception(ex.Message);
            }
        }
    }
}
