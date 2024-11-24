using daily_planet_domain.Interface.Repositories;
using daily_planet_infra.Context;
using Dapper;

namespace daily_planet_infra.Repositories
{
    public class BaseAuroraRepository<TEntity> : IDisposable, IBaseAuroraRepository<TEntity> where TEntity : class
    {
        private readonly AuroraDbContext _context;
        public BaseAuroraRepository(AuroraDbContext context) 
        {
            _context = context;
        }
        public async Task DeleteAsync(string query, object? param = null)
        {
            using (var con = _context.CreateConnection())
            {
                await con.ExecuteAsync(query, param);
            }
        }

        public void Dispose()
        {
        }

        public async Task<TEntity> GetAsync(string query, object? param = null)
        {
            using (var con = _context.CreateConnection())
            {
                var result = await con.QueryAsync<TEntity>(query, param);
                return result.FirstOrDefault();
            }
        }

        public async Task<IEnumerable<TEntity>> GetListAsync(string query, object? param = null)
        {
            using (var con = _context.CreateConnection())
            {
                var result = await con.QueryAsync<TEntity>(query, param);
                return result;
            }
        }

        public async Task InsertAsync(string query, object? param = null)
        {
            using (var con = _context.CreateConnection())
            {
                await con.ExecuteAsync(query, param);
            }
        }

        public async Task UpdateAsync(string query, object? param = null)
        {
            using (var con = _context.CreateConnection())
            {
                await con.ExecuteAsync(query, param);
            }
        }
    }
}
