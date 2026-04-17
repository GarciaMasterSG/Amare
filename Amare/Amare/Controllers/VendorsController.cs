using Microsoft.AspNetCore.Mvc;
using Amare.Models;
using Amare.Data;
using Microsoft.Data.SqlClient;

namespace Amare.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VendorsController : BaseController
    {
        private readonly DbUserProfile _db;

        public VendorsController(DbUserProfile db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<List<Vendors>> GetVendors()
        {
            string query = "SELECT Id, VendorName, Description, Price, Hired FROM Vendor WHERE WeddingCode = @WeddingCode";

            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@WeddingCode", weddingnCode),
            };

            var vendors = await _db.GetQueryExecuter(query, r => new Vendors
            {
                Id = Convert.ToInt16(r["Id"]),
                VendorName = Convert.ToString(r["VendorName"]),
                VendorDescription = Convert.ToString(r["Description"]),
                VendorPrice = Convert.ToInt16(r["Price"]),
                Hired = Convert.ToInt16(r["Hired"])
            }, parameters);

            return vendors;

        }

        [HttpPost]
        public async Task<IActionResult> addVendors([FromForm] Vendors vendors)
        {
            var weddingCode = HttpContext.Session.GetString("UserWeddingCode");

            int hired = 0;

            string query = "INSERT INTO Vendor(VendorName, WeddingCode, Description, Price, Hired) VALUES (@VendorName, @WeddingCode, @Description, @Price, @Hired); SELECT SCOPE_IDENTITY()";

            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@VendorName", vendors.VendorName),
                new SqlParameter("@WeddingCode", weddingCode),
                new SqlParameter("@Description", vendors.VendorDescription),
                new SqlParameter("@Price", vendors.VendorPrice),
                new SqlParameter("@Hired", hired)
            };

            int id = await _db.PostQueryExecuter(query, parameters);

            return Ok(id);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateHired(int id)
        {
            string query = "UPDATE Vendor SET Hired = 1 WHERE Id = @Id";

            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", id)
            };

            await _db.PatchDeleteQueryExecuter(query, parameters);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteData(int id)
        {
            string query = "DELETE FROM Vendor WHERE Id = @Id";

            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", id)
            };

            await _db.PatchDeleteQueryExecuter(query, parameters);

            return Ok();
        }

    }
}
