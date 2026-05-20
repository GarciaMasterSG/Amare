using Amare.Data;
using Amare.Models;
using LogicLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace Amare.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BudgetController : BaseController
    {
        private readonly Budget _budget;

        public BudgetController(Budget budget)
        {
            _budget = budget;
        }

        [HttpGet]
        public async Task<List<BudgetDTO>> GetBudget()
        {
            var budget = await _budget.GetBudget(weddingnCode);

            return budget;
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateBadget(int id, int maxBudget)
        {
            await _budget.UpdateBudget(id, maxBudget);

            return Ok();
        }
    }
}
