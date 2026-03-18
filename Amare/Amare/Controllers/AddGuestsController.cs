using Microsoft.AspNetCore.Mvc;

namespace Amare.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AddGuestsController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> AddGuestsPost( [FromForm] string guest)
        {
            return Ok(guest); 
        }
    }
}
