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

        public async Task<List<UserLeaderboardDomain>> GetLeaderboard(string weddingCode)
        {
            string query = "SELECT u.Name, u.UserPoints FROM UserProfile u LEFT JOIN UsersInWeddings w ON u.Email = w.UserEmail WHERE WeddingCode = @WeddingCode";

            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@WeddingCode", weddingCode)
            };

            var userPoints = await _db.GetQueryExecuter(query, r => new UserLeaderboardDomain
            {
                UserPoints = Convert.ToInt32(r["UserPoints"]),
                Name = Convert.ToString(r["Name"])
            }, parameters);

            return userPoints;
        }
    }
}
