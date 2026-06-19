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
            try
            {
                List<T> data = new List<T>();

                using (var conn = _db.GetConnection())
                {
                    await conn.OpenAsync();
                    using (var cmd = new SqlCommand(query, conn))
                    {
                        if (parameters != null)
                        {
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

            catch
            {
                throw;
            }
        }

        public async Task<int> PatchDeleteQueryExecuter(string query, List<SqlParameter> parameters)
        {
            using(var conn = _db.GetConnection())
            {
                await conn.OpenAsync();
                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        using (var cmd = new SqlCommand(query, conn, transaction))
                        {
                            cmd.Parameters.AddRange(parameters.ToArray());
                            var affectedRows = await cmd.ExecuteNonQueryAsync();
                            transaction.Commit();
                            return affectedRows;
                        }
                    }

                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }

                }
            }
        }

        public async Task<int> PostQueryExecuter(string query, List<SqlParameter> parameters)
        {
            try
            {
                using (var conn = _db.GetConnection())
                {
                    await conn.OpenAsync();
                    using (var cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddRange(parameters.ToArray());

                        var rawId = await cmd.ExecuteScalarAsync();

                        int id = Convert.ToInt16(rawId);

                        return id;
                    }
                }
            }

            catch
            {
                throw;
            }
        }
    }
}
