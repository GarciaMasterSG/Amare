using Amare.Data;
using Amare.Models;
using Microsoft.Data.SqlClient;
using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class VendorsRepository : IVendors
    {
        private readonly DbUserProfile _db;

        public VendorsRepository(DbUserProfile db)
        {
            _db = db;
        }

        public async Task<List<VendorsDTO>> GetVendors(string weddingCode)
        {
            string query = "SELECT Id, VendorName, Description, Price, Hired, Type FROM Vendor WHERE WeddingCode = @WeddingCode";

            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@WeddingCode", weddingCode),
            };

            var vendors = await _db.GetQueryExecuter(query, r => new VendorsDTO
            {
                Id = Convert.ToInt16(r["Id"]),
                VendorName = Convert.ToString(r["VendorName"]),
                VendorDescription = Convert.ToString(r["Description"]),
                VendorPrice = Convert.ToInt16(r["Price"]),
                Hired = Convert.ToInt16(r["Hired"]),
                VendorType = Convert.ToString(r["Type"])
            }, parameters);

            return vendors;

        }
        public async Task<int> PostVendors(VendorsDTO vendors, string weddingCode)
        {
            int hired = 0;

            string query = "INSERT INTO Vendor(VendorName, WeddingCode, Description, Price, Hired, Type) VALUES (@VendorName, @WeddingCode, @Description, @Price, @Hired, @Type); SELECT SCOPE_IDENTITY()";

            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@VendorName", vendors.VendorName),
                new SqlParameter("@WeddingCode", weddingCode),
                new SqlParameter("@Description", vendors.VendorDescription),
                new SqlParameter("@Price", vendors.VendorPrice),
                new SqlParameter("@Hired", hired),
                new SqlParameter("@Type", vendors.VendorType)
            };

            int id = await _db.PostQueryExecuter(query, parameters);

            return id;
        }
        public async Task UpdateHired(int id)
        {
            string query = "UPDATE Vendor SET Hired = 1 WHERE Id = @Id";

            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", id)
            };

            await _db.PatchDeleteQueryExecuter(query, parameters);
        }
        public async Task DeleteVendors(int id)
        {
            string query = "DELETE FROM Vendor WHERE Id = @Id";

            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", id)
            };

            await _db.PatchDeleteQueryExecuter(query, parameters);
        }
    }
}
