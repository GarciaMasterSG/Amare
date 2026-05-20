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
    public class WeddingEventsRepository : IWeddingEvents
    {
        private readonly DbUserProfile _db;

        public WeddingEventsRepository(DbUserProfile db)
        {
            _db = db;
        }

        public async Task<List<WeddingEventDTO>> GetWeddingEvents(string weddingCode)
        {
            string query = "SELECT Id, EventAt, EventName FROM WeddingItinerary WHERE WeddingCode = @WeddingCode";

            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@WeddingCode", weddingCode)
            };

            var weddingEvents = await _db.GetQueryExecuter(query, r => new WeddingEventDTO
            {
                Id = Convert.ToInt16(r["Id"]),
                WeddingEventName = Convert.ToString(r["EventName"]),
                WeddingEventTime = (TimeSpan)r["EventAt"]
            }, parameters);

            var weddingEventOrginizer = weddingEvents.OrderBy(we => we.WeddingEventTime).ToList();

            return weddingEventOrginizer;
        }
        public async Task<int> WeddingEventPost(WeddingEventDTO weddingEvent, string weddingCode)
        {
            string query = "INSERT INTO WeddingItinerary(WeddingCode, EventAt, EventName) VALUES (@WeddingCode, @EventAt, @EventName); SELECT SCOPE_IDENTITY()";

            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@WeddingCode", weddingCode),
                new SqlParameter("@EventAt", weddingEvent.WeddingEventTime),
                new SqlParameter("@EventName", weddingEvent.WeddingEventName)
            };

            int id = await _db.PostQueryExecuter(query, parameters);

            return id;
        }
        public async Task DeleteWeddingEvent(int id)
        {
            string query = "DELETE FROM WeddingItinerary WHERE Id = @Id";

            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", id)
            };

            await _db.PatchDeleteQueryExecuter(query, parameters);

        }
    }
}
