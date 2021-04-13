using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace SqlInfrastructure.Repositories
{
    public abstract class BaseRepository
    {
        private readonly IConfiguration _configuration;

        protected BaseRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected IDbConnection CreateConnection()
        {
            return new SqlConnection(_configuration.GetConnectionString("LocalConnection"));
        }
    }
}
