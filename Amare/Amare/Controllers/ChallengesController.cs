using Microsoft.AspNetCore.Mvc;
using Amare.Models;
using Amare.Data;
using Microsoft.Data.SqlClient;
using LogicLayer;

namespace Amare.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChallengesController : BaseController
    {
        private readonly Challenges _challenges;

        public ChallengesController(Challenges challenges)
        {
            _challenges = challenges;
        }

        [HttpGet]
        public async Task<List<ChallengesDTO>> GetChallenges()
        {
            var challenges = await _challenges.GetChallenges(weddingnCode);

            return challenges;
        }

        [HttpGet("GuestChallenges")]
        public async Task<List<ChallengesDTO>> GetGuestChallenges()
        {
            var userEmail = HttpContext.Session.GetString("UserEmail");

            var challenges = await _challenges.GetGuestChallenges(userEmail, weddingnCode); 

            return challenges;
        }

        [HttpPost]
        public async Task<IActionResult> ChallengesPost([FromForm] ChallengesDTO challenges)
        {
            var weddingCode = HttpContext.Session.GetString("UserWeddingCode");
            int id = await _challenges.ChallengesPost(challenges, weddingCode);
            return Ok(id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChallenges(int id)
        {
            await _challenges.DeleteChallenges(id);

            return Ok();
        }

        [HttpPost("{id}/{points}")]
        public async Task<IActionResult> PostIdChallenge(int id, int points) 
        {
            int? userId = HttpContext.Session.GetInt32("UserId");

            var userEmail = HttpContext.Session.GetString("UserEmail");

            await _challenges.PostIdChallenge(id, points, userId.Value, userEmail);

            return Ok();
        }
    }
}
