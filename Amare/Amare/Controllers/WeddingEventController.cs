using Microsoft.AspNetCore.Mvc;
using Amare.Models;
using Amare.Data;
using Microsoft.Data.SqlClient;

namespace Amare.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeddingEventController : BaseController
    {
        private readonly DbUserProfile _db;

        public WeddingEventController(DbUserProfile db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<List<WeddingEvent>> GetWeddingEvents()
        {
            string query = "SELECT EventAt, EventName FROM WeddingItinerary WHERE WeddingCode = @WeddingCode";

            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@WeddingCode", weddingnCode)
            };

            var weddingEvents = await _db.GetQueryExecuter(query,  r => new WeddingEvent
            {
                WeddingEventName = Convert.ToString(r["EventName"]),
                WeddingEventTime = (TimeSpan)r["EventAt"]
            }, parameters);

            return weddingEvents;
        }

        [HttpPost]
        public async Task<IActionResult> WeddingEventPost([FromForm] WeddingEvent weddingEvent)
        {
            var weddingCode = HttpContext.Session.GetString("UserWeddingCode");

            string query = "INSERT INTO WeddingItinerary(WeddingCode, EventAt, EventName) VALUES (@WeddingCode, @EventAt, @EventName); SELECT SCOPE_IDENTITY()";

            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@WeddingCode", weddingCode),
                new SqlParameter("@EventAt", weddingEvent.WeddingEventTime),
                new SqlParameter("@EventName", weddingEvent.WeddingEventName)
            };

            int id = await _db.PostQueryExecuter(query, parameters);

            return Ok(id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteData(int id) 
        {
            string query = "DELETE FROM WeddingItinerary WHERE Id = @Id";

            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", id)
            };

            await _db.PatchDeleteQueryExecuter(query, parameters);

            return Ok();
        }
    }
}
