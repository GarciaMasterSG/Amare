using Microsoft.AspNetCore.Mvc;
using Amare.Models;

namespace Amare.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChallengesController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> ChallengesPost([FromForm] Challenges challenges)
        {
            return Ok(challenges);
        }
    }
}
