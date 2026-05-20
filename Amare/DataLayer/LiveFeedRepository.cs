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
    public class LiveFeedRepository : ILiveFeed
    {
        private readonly DbUserProfile _db;

        public LiveFeedRepository(DbUserProfile db)
        {
            _db = db;
        }

        public async Task<List<LiveFeedGetDTO>> GetLiveFeed(string weddingCode)
        {
            string query = "SELECT Id, UserName, PhotoFeed, Description FROM LiveFeed WHERE WeddingCode = @WeddingCode";

            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@WeddingCode", weddingCode)
            };

            var posts = await _db.GetQueryExecuter(query, r => new LiveFeedGetDTO
            {
                Id = Convert.ToInt16(r["Id"]),
                UserName = Convert.ToString(r["UserName"]),
                PhotoFeed = Convert.ToString(r["PhotoFeed"]),
                Description = Convert.ToString(r["Description"])
            }, parameters);

            return posts;
        }
        public async Task PostLiveFeed(string fileName, string description, string weddingCode, string userName)
        {

            string query = "INSERT INTO LiveFeed(UserName, WeddingCode, PhotoFeed, Description) VALUES (@UserName, @WeddingCode, @PhotoFeed, @Description)";

            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@UserName", userName),
                new SqlParameter("@WeddingCode", weddingCode),
                new SqlParameter("@PhotoFeed", fileName),
                new SqlParameter("@Description", description)
            };

            await _db.PostQueryExecuter(query, parameters);
        }
    }
}
