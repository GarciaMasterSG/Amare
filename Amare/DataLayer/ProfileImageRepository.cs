using Amare.Data;
using Microsoft.Data.SqlClient;
using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class ProfileImageRepository : IProfileImage
    {
        private readonly DbUserProfile _db;

        public ProfileImageRepository(DbUserProfile db)
        {
            _db = db;
        }

        public async Task PostProfileImage(int userId, string fileName)
        {
            string query = "UPDATE UserProfile SET ProfilePhoto = @PhotoUrl WHERE UserId = @Id";

            List<SqlParameter> parameters = new List<SqlParameter>()
                {
                    new SqlParameter("@PhotoUrl", fileName),
                    new SqlParameter("@Id", userId)
                };

            await _db.PatchDeleteQueryExecuter(query, parameters);

        }
        public async Task<List<string>> GetProfileImage(int userId)
        {
            string query = "SELECT ProfilePhoto FROM UserProfile WHERE UserId = @Id";

            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", userId)
            };

            var result = await _db.GetQueryExecuter(query, r => Convert.ToString(r["ProfilePhoto"]), parameters);

            return result;

        }
    }
}
