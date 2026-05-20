using Amare.Data;
using Amare.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class Vendors
    {
        private readonly IVendors _vendors;

        public Vendors(IVendors vendors)
        {
            _vendors = vendors;
        }

        public async Task<List<VendorsDTO>> GetVendors(string weddingCode)
        {
            return await _vendors.GetVendors(weddingCode);
        }

        public async Task<int> PostVendors(VendorsDTO vendors, string weddingCode)
        {
            return await _vendors.PostVendors(vendors, weddingCode);
        }

        public async Task UpdateHired(int id)
        {
            await _vendors.UpdateHired(id);
        }

        public async Task DeleteVendors(int id)
        {
            await _vendors.DeleteVendors(id);
        }
    }
}
