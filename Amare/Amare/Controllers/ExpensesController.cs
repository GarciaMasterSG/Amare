using Microsoft.AspNetCore.Mvc;
using Amare.Models;

namespace Amare.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExpensesController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> AddExpense([FromForm] Expenses expenses)
        {
            return Ok(expenses);
        }
    }
}
