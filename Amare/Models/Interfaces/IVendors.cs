using Amare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Interfaces
{
    public interface IVendors
    {
        Task<List<VendorsDTO>> GetVendors(string weddingCode);

        Task<int> PostVendors(VendorsDTO vendors, string weddingCode);

        Task UpdateHired(int id);

        Task DeleteVendors(int id);
    }
}
