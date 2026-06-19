using Amare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Interfaces
{
    public interface IBudget
    {
        Task<List<BudgetDomain>> GetBudget(string weddingCode);

        Task UpdateBudget(int id, int maxBudget);
    }
}
