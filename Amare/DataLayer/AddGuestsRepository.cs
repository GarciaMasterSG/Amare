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
    public class AddGuestsRepository : IAddGuest
    {
        private readonly DbUserProfile _db;
        public AddGuestsRepository(DbUserProfile db)
        {
            _db = db;
        }
        public async Task<List<GuestsDTO>> GetGuest(string weddingCode)
        {
            string query = "SELECT Id, GuestName, WeddingCode, TableName FROM Guest WHERE WeddingCode = @WeddingCode";

            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@WeddingCode",weddingCode)
            };

            var guest = await _db.GetQueryExecuter(query, r => new GuestsDTO
            {
                Id = Convert.ToInt16(r["Id"]),
                GuestName = Convert.ToString(r["Guestname"]),
                TableName = Convert.ToString(r["TableName"])
            }, parameters);

            return guest;


        }

        public async Task<int> AddGuestsPost(string guest, string weddingCode)
        {
            string query = "INSERT INTO Guest(GuestName, WeddingCode) VALUES (@GuestName, @WeddingCode); SELECT SCOPE_IDENTITY()";

            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@GuestName", guest),
                new SqlParameter("@WeddingCode", weddingCode)
            };

            int id = await _db.PostQueryExecuter(query, parameters);

            return id;
        }

        public async Task DeleteAddGuests(int id)
        {
            string query = "DELETE FROM Guest WHERE Id = @Id";

            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", id)
            };

            await _db.PatchDeleteQueryExecuter(query, parameters);

        }

        public async Task DeleteTable(string tableName, string weddingCode)
        {
            string query = "UPDATE Guest SET TableName = NULL WHERE WeddingCode = @WeddingCode AND TableName = @TableName";

            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@WeddingCode", weddingCode),
                new SqlParameter("@TableName", tableName)
            };

            await _db.PatchDeleteQueryExecuter(query, parameters);

        }
    }
}
