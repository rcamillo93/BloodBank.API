using BloodBank.Core.Entity;
using BloodBank.Core.Repositories;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace BloodBank.Infrastructure.Persistence.Repositories
{
    public class CityRepository : ICityRepository
    {
        private readonly string _connectionString;

        public CityRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("BloodBank");
        }

        public async Task<int> GetByCodIbgeAsync(int codIbge)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var sql = $"SELECT ID FROM CITY WHERE CODIBGE={codIbge}";

                var city = await sqlConnection.QuerySingleOrDefaultAsync<int>(sql);

                return city;
            }
        }

        public Task<int> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }
    }
}
