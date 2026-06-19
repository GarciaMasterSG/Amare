using Amare.Data;
using Microsoft.AspNetCore.Mvc;
using Amare.Models;
using Microsoft.Data.SqlClient;
using LogicLayer;

namespace Amare.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LeaderboardController : BaseController
    {
        private readonly Leaderboard _leaderboard;

        public LeaderboardController(Leaderboard leaderboard)
        {
            _leaderboard = leaderboard;
        }

        [HttpGet]
        public async Task<List<UserLeaderboardDomain>> GetLeaderboard()
        {
            var userPoints = await _leaderboard.GetLeaderboard(weddingnCode);

            return userPoints;
        }
    }
}
