using Amare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Interfaces
{
    public interface IChallenges
    {
        Task<List<ChallengesDTO>> GetChallenges(string weddingCode);

        Task<List<ChallengesDTO>> GetGuestChallenges(string userEmail, string weddingCode);

        Task<int> ChallengesPost(ChallengesDTO challenges, string weddingCode);

        Task DeleteChallenges(int id);

        Task PostIdChallenge(int id, int points, int userId, string userEmail);
    }
}
