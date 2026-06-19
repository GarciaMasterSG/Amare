using Amare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Interfaces
{
    public interface IExpenses
    {
        Task<List<ExpensesDomain>> GetExpenses(string weddingCode);

        Task<int> PostExpenses(ExpensesDomain expenses, string weddingCode);

        Task DeleteExpenses(int id);
    }
}
