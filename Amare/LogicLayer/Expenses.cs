using Amare.Data;
using Amare.Models;
using Microsoft.Data.SqlClient;
using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class Expenses
    {
        private readonly IExpenses _expenses;

        public Expenses(IExpenses expenses)
        {
            _expenses = expenses;
        }

        public async Task<List<ExpensesDomain>> GetExpenses(string weddingCode)
        {
            return await _expenses.GetExpenses(weddingCode);
        }

        public async Task<int> PostExpenses(ExpensesDomain expenses, string weddingCode)
        {
            return await _expenses.PostExpenses(expenses, weddingCode);
        }

        public async Task DeleteExpenses(int id)
        {
            await _expenses.DeleteExpenses(id);
        }
    }
}
