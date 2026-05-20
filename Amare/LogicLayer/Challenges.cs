using Amare.Data;
using Amare.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class Challenges
    {
        private readonly IChallenges _challenges;

        public Challenges(IChallenges challenges)
        {
            _challenges = challenges;
        }

        public async Task<List<ChallengesDTO>> GetChallenges(string weddingCode)
        {
            return await _challenges.GetChallenges(weddingCode);
        }

        public async Task<List<ChallengesDTO>> GetGuestChallenges(string userEmail, string weddingCode)
        {
            return await _challenges.GetGuestChallenges(userEmail, weddingCode);
        }

        public async Task<int> ChallengesPost(ChallengesDTO challenges, string weddingCode)
        {
            return await _challenges.ChallengesPost(challenges, weddingCode);
        }

        public async Task DeleteChallenges(int id)
        {
            await _challenges.DeleteChallenges(id);
        }

        public async Task PostIdChallenge(int id, int points, int userId, string userEmail)
        {
            await _challenges.PostIdChallenge(id, points, userId, userEmail);
        }
    }
}
