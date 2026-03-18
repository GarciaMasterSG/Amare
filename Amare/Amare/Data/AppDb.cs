using Microsoft.Data.SqlClient;
namespace Amare.Data
{
    public class AppDb
    {
        private readonly string _dbConnectionString;

        public AppDb(IConfiguration configuration)
        {
            _dbConnectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public SqlConnection GetConnection()
        {
            return new SqlConnection(_dbConnectionString);
        }
    }
}
