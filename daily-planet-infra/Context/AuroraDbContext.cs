using daily_planet_application.Static;
using Npgsql;
using System.Data;

namespace daily_planet_infra.Context
{
    public class AuroraDbContext : IDisposable
    {

        public AuroraDbContext()
        {
        }

        public IDbConnection CreateConnection()
            => new NpgsqlConnection(RunTimeConfig.Auroraconnection);

        public void Dispose()
        {
        }
    }
}
