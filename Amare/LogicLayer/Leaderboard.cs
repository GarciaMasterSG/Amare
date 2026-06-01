using Amare.Data;
using Amare.Models;
using Microsoft.Data.SqlClient;
using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class Leaderboard
    {
        private readonly ILeaderboard _leaderboard;

        public Leaderboard(ILeaderboard leaderboard)
        {
            _leaderboard = leaderboard;
        }

        public async Task<List<UserLeaderboardDTO>> GetLeaderboard(string weddingCode)
        {
            var userPoints = await _leaderboard.GetLeaderboard(weddingCode);
            var sortedUserPoints = userPoints.OrderByDescending(u => u.UserPoints).ToList();
            return sortedUserPoints;
        }
    }
}
