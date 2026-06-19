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
    public class TablesRepository : ITables
    {
        private readonly DbUserProfile _db;

        public TablesRepository(DbUserProfile db)
        {
            _db = db;
        }

        public async Task<List<string>> PostTable(TablesDomain table, string weddingCode)
        {
            var tables = table.Guests.Select(async guest =>
            {
                string queryGuests = "UPDATE Guest SET TableName = @TableName WHERE GuestName = @GuestName AND WeddingCode = @WeddingCode";

                List<SqlParameter> parametersGuests = new List<SqlParameter>()
                {
                    new SqlParameter("@TableName", table.Name),
                    new SqlParameter("@GuestName", guest),
                    new SqlParameter("@WeddingCode", weddingCode)
                };

                int rows = await _db.PatchDeleteQueryExecuter(queryGuests, parametersGuests);

                return rows == 0 ? guest : null;
            });

            var results = await Task.WhenAll(tables);

            var noOnTable = results.Where(guest => guest != null).ToList();

            return noOnTable;
        }
    }
}
