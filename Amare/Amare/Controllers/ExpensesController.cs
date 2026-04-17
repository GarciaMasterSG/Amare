using Microsoft.AspNetCore.Mvc;
using Amare.Models;
using Amare.Data;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Http;

namespace Amare.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExpensesController : BaseController
    {
        private readonly DbUserProfile _db;

        public ExpensesController(DbUserProfile db) 
        { 
            _db = db;
        }

        [HttpGet]
        public async Task<List<Expenses>> GetExpenses()
        {
            string query = "SELECT Id, ExpenseName, WeddingCode, Price FROM Expense WHERE WeddingCode = @WeddingCode";

            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@WeddingCode", weddingnCode)
            };

            var expenses = await _db.GetQueryExecuter(query, r => new Expenses
            {
                Id = Convert.ToInt16(r["Id"]),
                ExpenseName = Convert.ToString(r["ExpenseName"]),
                ExpensePrice = Convert.ToInt32(r["Price"])
            }, parameters);

            return expenses;
            
        }

        [HttpPost]
        public async Task<IActionResult> AddExpense([FromForm] Expenses expenses)
        {


            string query = "INSERT INTO Expense(ExpenseName, WeddingCode, Price) VALUES (@ExpenseName, @WeddingCode, @Price); SELECT SCOPE_IDENTITY()";

            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Expensename", expenses.ExpenseName),
                new SqlParameter("@WeddingCode", weddingnCode),
                new SqlParameter("@Price", expenses.ExpensePrice)
            }; 

            int id = await _db.PostQueryExecuter(query, parameters);

            return Ok(id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteData(int id)
        {
            string query = "DELETE FROM Expense WHERE Id = @Id";

            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", id)
            };

            await _db.PatchDeleteQueryExecuter(query, parameters);

            return Ok();
        }
    }
}
