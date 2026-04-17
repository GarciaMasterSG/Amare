using Amare.Data;
using Amare.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace Amare.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AddGuestsController : BaseController
    {
        private readonly DbUserProfile _db;

        public AddGuestsController(DbUserProfile db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<GetGuests> GetGuests()
        {
            string query = "SELECT Id, GuestName, WeddingCode, TableName FROM Guest WHERE WeddingCode = @WeddingCode";

            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@WeddingCode",weddingnCode)
            };

            var guest = await _db.GetQueryExecuter(query, r => new Guests
            {
                Id = Convert.ToInt16(r["Id"]),
                GuestName = Convert.ToString(r["Guestname"]),
                TableName = Convert.ToString(r["TableName"])
            }, parameters);

            var guests = guest.Select(guest => new SpecificGuest { GuestName = guest.GuestName, Id = guest.Id }).ToList();

            var tables = guest.GroupBy(tables => tables.TableName).Select(t => new GropedTables
            {
                TableName = t.Key,
                GuestNames = t.Select(guest => guest.GuestName).ToList()
            }).ToList();

            return new GetGuests
            {
                GuestsList = guests,
                GroupedTables = tables
            };
        }

        [HttpPost]
        public async Task<IActionResult> AddGuestsPost([FromForm] string guest)
        {
            var weddingCode = HttpContext.Session.GetString("UserWeddingCode");

            string query = "INSERT INTO Guest(GuestName, WeddingCode) VALUES (@GuestName, @WeddingCode); SELECT SCOPE_IDENTITY()";

            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@GuestName", guest),
                new SqlParameter("@WeddingCode", weddingCode)
            };

            int id = await _db.PostQueryExecuter(query, parameters);

            return Ok(id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteData(int id)
        {
            string query = "DELETE FROM Guest WHERE Id = @Id";

            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", id)
            };

            await _db.PatchDeleteQueryExecuter(query, parameters);

            return Ok();
        }

        [HttpDelete("guesttable/({table})")]
        public async Task<IActionResult> DeleteTable(string tableName)
        {
            string query = "UPDATE Guest SET TableName = NULL WHERE WeddingCode = @WeddingCode AND TableName = @TableName";

            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@WeddingCode", weddingnCode),
                new SqlParameter("@TableName", tableName)
            };

            await _db.PatchDeleteQueryExecuter(query, parameters);

            return Ok();
        } 


    }
}
