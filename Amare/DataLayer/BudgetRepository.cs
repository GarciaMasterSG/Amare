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
    public class BudgetRepository : IBudget
    {
        private readonly DbUserProfile _db;

        public BudgetRepository(DbUserProfile db)
        {
            _db = db;
        }

        public async Task<List<BudgetDTO>> GetBudget(string weddingCode)
        {
            string query = "SELECT Id, MaxBudget FROM Budget WHERE WeddingCode = @WeddingCode";

            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@WeddingCode", weddingCode)
            };

            var budget = await _db.GetQueryExecuter(query, r => new BudgetDTO
            {
                Id = Convert.ToInt16(r["Id"]),
                MaxBudget = Convert.ToInt32(r["MaxBudget"])
            }, parameters);

            return budget;
        }

        public async Task UpdateBudget(int id, int maxBudget)
        {
            string query = "UPDATE Budget SET MaxBudget = @MaxBudget WHERE Id = @Id";

            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@MaxBudget", maxBudget),
                new SqlParameter("@Id", id)
            };

            await _db.PatchDeleteQueryExecuter(query, parameters);
        }
    }
}
