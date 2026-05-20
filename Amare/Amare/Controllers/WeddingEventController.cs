using Microsoft.AspNetCore.Mvc;
using Amare.Models;
using Amare.Data;
using Microsoft.Data.SqlClient;
using LogicLayer;

namespace Amare.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeddingEventController : BaseController
    {
        private readonly WeddingEvents _weddingEvents;

        public WeddingEventController(WeddingEvents weddingEvents)
        {
            _weddingEvents = weddingEvents;
        }

        [HttpGet]
        public async Task<List<WeddingEventDTO>> GetWeddingEvents()
        {
            var weddingEventOrginizer = await _weddingEvents.GetWeddingEvents(weddingnCode);

            return weddingEventOrginizer;
        }

        [HttpPost]
        public async Task<IActionResult> WeddingEventPost([FromForm] WeddingEventDTO weddingEvent)
        {
            int id = await _weddingEvents.WeddingEventPost(weddingEvent, weddingnCode);

            return Ok(id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteData(int id) 
        {
            await _weddingEvents.DeleteWeddingEvent(id);

            return Ok();
        }
    }
}
