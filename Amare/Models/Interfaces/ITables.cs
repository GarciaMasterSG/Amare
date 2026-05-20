using Amare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Models.Interfaces
{
    public interface ITables
    {
        Task<List<String>> PostTable(TablesDTO table, string weddingCode);

    }
}
