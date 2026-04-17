using Amare.Models;
using Microsoft.Data.SqlClient;

namespace Amare.Data
{
    public class DbUserProfile
    {
        private readonly AppDb _db;

        public DbUserProfile(AppDb db)
        {
            _db = db;
        }

        public async Task<List<T>> GetQueryExecuter<T>(string query, Func<SqlDataReader, T> map, List<SqlParameter> parameters = null)
        {
            List<T> data = new List<T>();

            using(var conn = _db.GetConnection())
            {
                await conn.OpenAsync();
                using (var cmd = new SqlCommand(query, conn))
                {
                    if (parameters != null) {
                        cmd.Parameters.AddRange(parameters.ToArray());
                    }
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {

                        while (reader.Read())
                        {
                            data.Add(map(reader));
                        }
                    }
                }
            }
            return data;
        }

        public async Task<int> PatchDeleteQueryExecuter(string query, List<SqlParameter> parameters)
        {
            using(var conn = _db.GetConnection())
            {
                await conn.OpenAsync();
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddRange(parameters.ToArray());
                    return await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task<int> PostQueryExecuter(string query, List<SqlParameter> parameters)
        {
            using (var conn = _db.GetConnection())
            {
                await conn.OpenAsync();
                using ( var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddRange(parameters.ToArray());

                    var rawId = await cmd.ExecuteScalarAsync();

                    int id = Convert.ToInt16(rawId);

                    return id;
                }
            }
        }
    }
}
