using Amare.Data;
using Microsoft.Data.SqlClient;
using Models;
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

        public async Task PostProfileImage(ProfileImageDomain image)
        {
            string query = "UPDATE UserProfile SET ProfilePhoto = @PhotoUrl WHERE UserId = @Id";

            List<SqlParameter> parameters = new List<SqlParameter>()
                {
                    new SqlParameter("@PhotoUrl", image.FileName),
                    new SqlParameter("@Id", image.UserId)
                };

            await _db.PatchDeleteQueryExecuter(query, parameters);

        }
        public async Task<List<string>> GetProfileImage(ProfileImageDomain userId)
        {
            string query = "SELECT ProfilePhoto FROM UserProfile WHERE UserId = @Id";

            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", userId.UserId)
            };

            var result = await _db.GetQueryExecuter(query, r => Convert.ToString(r["ProfilePhoto"]), parameters);

            return result;

        }
    }
}
