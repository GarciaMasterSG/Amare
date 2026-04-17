using Microsoft.AspNetCore.Mvc;
using Amare.Models;
using Amare.Data;
using Microsoft.Data.SqlClient;

namespace Amare.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TablesController : BaseController
    {
        private readonly DbUserProfile _db;

        public TablesController(DbUserProfile db)
        {
            _db = db;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTable([FromBody] Tables table)
        {
            List<string> NoOnTable = new List<string>();

            table.Guests.ForEach( async guest =>
            {
                string queryGuests = "UPDATE Guest SET TableName = @TableName WHERE GuestName = @GuestName AND WeddingCode = @WeddingCode";

                List<SqlParameter> parametersGuests = new List<SqlParameter>()
                {
                    new SqlParameter("@TableName", table.Name),
                    new SqlParameter("@GuestName", guest),
                    new SqlParameter("@WeddingCode", weddingnCode)
                };
                int rows = await _db.PostQueryExecuter(queryGuests, parametersGuests);

                if (rows == 0)
                {
                    NoOnTable.Add(guest);
                }
            });

            return Ok(NoOnTable);
        }
    }
}
