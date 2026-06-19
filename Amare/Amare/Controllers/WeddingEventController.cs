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
        public async Task<List<WeddingEventDomain>> GetWeddingEvents()
        {
            var weddingEventOrginizer = await _weddingEvents.GetWeddingEvents(weddingnCode);

            return weddingEventOrginizer;
        }

        [HttpPost]
        public async Task<IActionResult> WeddingEventPost([FromForm] WeddingEventDomain weddingEvent)
        {
            if (weddingEvent.WeddingEventName.Length > 150)
            {
                return BadRequest("Wedding event name cannot be longer than 150 characters.");
            }

            int id = await _weddingEvents.WeddingEventPost(weddingEvent, weddingnCode);

            return Ok(id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWeddingEvent(int id) 
        {
            await _weddingEvents.DeleteWeddingEvent(id);

            return Ok();
        }
    }
}
