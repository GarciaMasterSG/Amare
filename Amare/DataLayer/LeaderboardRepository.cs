using Amare.Data;
using Amare.Models;
using Microsoft.Data.SqlClient;
using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class LeaderboardRepository : ILeaderboard
    {
        private readonly DbUserProfile _db;

        public LeaderboardRepository(DbUserProfile db)
        {
            _db = db;
        }

        public async Task<List<UserLeaderboardDTO>> GetLeaderboard(string weddingCode)
        {
            string query = "SELECT Name, UserPoints FROM UserProfile WHERE WeddingCode = @WeddingCode";

            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@WeddingCode", weddingCode)
            };

            var userPoints = await _db.GetQueryExecuter(query, r => new UserLeaderboardDTO
            {
                UserPoints = Convert.ToInt32(r["UserPoints"]),
                Name = Convert.ToString(r["Name"])
            }, parameters);

            return userPoints;
        }
    }
}
