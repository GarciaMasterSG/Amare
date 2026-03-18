using Microsoft.AspNetCore.Mvc;
using Amare.Models;

namespace Amare.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeddingEventController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> WeddingEventPost([FromForm] WeddingEvent weddingEvent)
        {
            return Ok(weddingEvent);
        }
    }
}
