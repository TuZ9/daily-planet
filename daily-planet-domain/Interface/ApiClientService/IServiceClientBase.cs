
namespace daily_planet_domain.Interface.ApiClientService
{
    public interface IServiceClientBase<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> SendListAsync(string url, string token);
        Task<TEntity> SendAsync(string url, string token);
        Task<TEntity> GetAsync(string url);
        Task<IEnumerable<TEntity?>> GetListAsync(string url);
        Task PostAsync(string url, TEntity obj);
        Task PutAsync(string url, TEntity obj);
        Task DeleteAsync(string url);
    }
}
