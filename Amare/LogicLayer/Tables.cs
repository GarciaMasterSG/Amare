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
    public class Tables
    {
        private readonly ITables _tables;

        public Tables(ITables tables)
        {
            _tables = tables;
        }
        public async Task<List<string>> PostTable(TablesDTO table, string weddingCode)
        {
            return await _tables.PostTable(table, weddingCode);
        }
    }
}
