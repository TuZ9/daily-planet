using daily_planet_domain.Entities;

namespace daily_planet_domain.Interface.Repositories
{
    public interface IContentRepository
    {
        Task<IEnumerable<News>> Get();
        Task Insert(IEnumerable<News> contents);
        Task Update(IEnumerable<News> contents);
        Task Delete(News contents);
    }
}
