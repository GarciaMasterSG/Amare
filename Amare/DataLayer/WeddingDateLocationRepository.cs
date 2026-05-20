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
    public class WeddingDateLocationRepository : IWeddingDateLocation
    {
        private readonly DbUserProfile _db;

        public WeddingDateLocationRepository(DbUserProfile db)
        {
            _db = db;
        }
        public async Task PostWeddingDateLocation(WeddingLocationAndDateDTO postDateLocation, string weddingCode)
        {
            string query = "UPDATE Wedding SET WeddingLocation = @WeddingLocation, Weddingdate = @WeddingDate WHERE WeddingCode = @WeddingCode";

            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@WeddingLocation", postDateLocation.WeddingLocation),
                new SqlParameter("@WeddingDate", postDateLocation.WeddingDate),
                new SqlParameter("WeddingCode", weddingCode)
            };

            await _db.PatchDeleteQueryExecuter(query, parameters);

        }
    }
}
