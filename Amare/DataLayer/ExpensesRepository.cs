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
    public class ExpensesRepository : IExpenses
    {
        private readonly DbUserProfile _db;

        public ExpensesRepository(DbUserProfile db)
        {
            _db = db;
        }

        public async Task<List<ExpensesDomain>> GetExpenses(string weddingCode)
        {
            string query = "SELECT Id, ExpenseName, WeddingCode, Price FROM Expense WHERE WeddingCode = @WeddingCode";

            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@WeddingCode", weddingCode)
            };

            var expenses = await _db.GetQueryExecuter(query, r => new ExpensesDomain
            {
                Id = Convert.ToInt16(r["Id"]),
                ExpenseName = Convert.ToString(r["ExpenseName"]),
                ExpensePrice = Convert.ToInt32(r["Price"])
            }, parameters);

            return expenses;

        }
        public async Task<int> PostExpenses(ExpensesDomain expenses, string weddingCode)
        {

            string query = "INSERT INTO Expense(ExpenseName, WeddingCode, Price) VALUES (@ExpenseName, @WeddingCode, @Price); SELECT SCOPE_IDENTITY()";

            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Expensename", expenses.ExpenseName),
                new SqlParameter("@WeddingCode", weddingCode),
                new SqlParameter("@Price", expenses.ExpensePrice)
            };

            int id = await _db.PostQueryExecuter(query, parameters);

            return id;
        }

        public async Task DeleteExpenses(int id)
        {
            string query = "DELETE FROM Expense WHERE Id = @Id";

            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", id)
            };

            await _db.PatchDeleteQueryExecuter(query, parameters);
        }
    }
}
