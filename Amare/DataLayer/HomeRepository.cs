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
    public class HomeRepository : IHome
    {
        private readonly DbUserProfile _db;

        public HomeRepository(DbUserProfile db)
        {
            _db = db;
        }

        public async Task<List<WeddingDomain>> GetIndex(string weddingCode)
        {
            string query = "SELECT * FROM Wedding WHERE WeddingCode = @WeddingCode";

            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@WeddingCode",weddingCode)
            };

            var couple = await _db.GetQueryExecuter(query, r => new WeddingDomain
            {
                Groom = Convert.ToString(r["Groom"]),
                Bride = Convert.ToString(r["Bride"]),
                WeddingCode = Convert.ToString(r["WeddingCode"]),
                WeddingLocation = r["WeddingLocation"] == DBNull.Value ? null : Convert.ToString(r["WeddingLocation"]),
                WeddingDate = r["WeddingDate"] == DBNull.Value ? null : Convert.ToDateTime(r["WeddingDate"])
            }, parameters);

            return couple;
        }
    }
}
