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
    public class Budget
    {
        private readonly IBudget _budget;

        public Budget(IBudget budget)
        {
            _budget = budget;
        }

        public async Task<List<BudgetDTO>> GetBudget(string weddingCode)
        {
            return await _budget.GetBudget(weddingCode);
        }

        public async Task UpdateBudget(int id, int maxBudget)
        {
            await _budget.UpdateBudget(id, maxBudget);
        }
    }
}
