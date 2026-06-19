using Microsoft.AspNetCore.Mvc;
using Amare.Models;
using Amare.Data;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Http;
using Models.Interfaces;
using LogicLayer;

namespace Amare.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExpensesController : BaseController
    {
        private readonly Expenses _expenses;

        public ExpensesController(Expenses expenses) 
        { 
            _expenses = expenses;
        }

        [HttpGet]
        public async Task<List<ExpensesDomain>> GetExpenses()
        {
            var expenses = await _expenses.GetExpenses(weddingnCode);

            return expenses;
            
        }

        [HttpPost]
        public async Task<IActionResult> PostExpense([FromForm] ExpensesDomain expenses)
        {
            if (expenses.ExpenseName.Length > 100)
            {
                return BadRequest(new { error = "Expense name is too long" });
            }

            int id = await _expenses.PostExpenses(expenses, weddingnCode);

            return Ok(id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExpense(int id)
        {
            await _expenses.DeleteExpenses(id);

            return Ok();
        }
    }
}
