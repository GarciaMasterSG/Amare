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

        public List<T> GetQueryExecuter<T>(string query, Func<SqlDataReader, T> map, List<SqlParameter> parameters = null)
        {
            List<T> data = new List<T>();

            using(var conn = _db.GetConnection())
            {
                conn.Open();
                using (var cmd = new SqlCommand(query, conn))
                {
                    if (parameters != null) {
                        cmd.Parameters.AddRange(parameters.ToArray());
                    }
                    using (var reader = cmd.ExecuteReader())
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

        public int PostQueryExecuter(string query, List<SqlParameter> parameters)
        {
            using(var conn = _db.GetConnection())
            {
                conn.Open();
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddRange(parameters.ToArray());
                    return cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
