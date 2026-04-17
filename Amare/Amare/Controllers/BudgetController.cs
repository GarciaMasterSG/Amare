using Amare.Data;
using Amare.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace Amare.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BudgetController : BaseController
    {
        private readonly DbUserProfile _db;

        public BudgetController(DbUserProfile db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<List<Budget>> GetBudget()
        {
            string query = "SELECT Id, MaxBudget FROM Budget WHERE WeddingCode = @WeddingCode";

            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@WeddingCode", weddingnCode)
            };

            var budget = await _db.GetQueryExecuter(query, r => new Budget
            {
                Id = Convert.ToInt16(r["Id"]),
                MaxBudget = Convert.ToInt32(r["MaxBudget"])
            }, parameters);

            return budget;
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateBadget(int id)
        {
            string query = "UPDATE Budget SET MaxBudget = @MaxBudget WHERE Id = @Id";

            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter(),
                new SqlParameter("@Id", id)
            };

            await _db.PatchDeleteQueryExecuter(query, parameters);

            return Ok();
        }
    }
}
