using daily_planet_domain.Entities;

namespace daily_planet_domain.Interface.Repositories
{
    public interface ISearchRepository
    {
        Task<IEnumerable<Search>> Get();
        Task Insert(IEnumerable<Search> searchs);
        Task Update(IEnumerable<Search> searchs);
        Task Delete(Search search);
    }
}
