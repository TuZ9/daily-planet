
using daily_planet_domain.Entities;

namespace daily_planet_domain.Interface.Services
{
    public interface IContentService
    {
        Task ProcessNews();
        Task<List<News>> BuscarNoticiasAsync(string search);
    }
}
