using Amare.Data;
using Amare.Models;
using Microsoft.Data.SqlClient;
using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class ChallengesRepository : IChallenges
    {
        private readonly DbUserProfile _db;

        public ChallengesRepository(DbUserProfile db)
        {
            _db = db;
        }

        public async Task<List<ChallengesDTO>> GetChallenges(string weddingCode)
        {
            string query = "SELECT Id, ChallengeName, WeddingCode, Description, Points FROM Challenge WHERE WeddingCode = @WeddingCode";

            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@WeddingCode", weddingCode)
            };

            var challenges = await _db.GetQueryExecuter(query, r => new ChallengesDTO
            {
                Id = Convert.ToInt16(r["Id"]),

                ChallengeName = Convert.ToString(r["ChallengeName"]),

                ChallengeDescription = Convert.ToString(r["Description"]),

                ChallengePoints = Convert.ToInt16(r["Points"])

            }, parameters);

            return challenges;
        }
        public async Task<List<ChallengesDTO>> GetGuestChallenges(string userEmail, string weddingCode)
        {
            string query = "SELECT UserEmail, ChallengeId FROM ChallengeCompleted WHERE UserEmail = @Email";

            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Email", userEmail)
            };

            var sqlResult = await _db.GetQueryExecuter(query, r => new ChallengeCompletedDTO
            {
                UserEmail = Convert.ToString(r["UserEmail"]),
                ChallengeId = Convert.ToInt32(r["ChallengeId"])
            }, parameters);

            List<SqlParameter> parameters2 = sqlResult.Select((x, index) => new SqlParameter($"@ids{index}", x.ChallengeId)).Append(new SqlParameter("@WeddingCode", weddingCode)).ToList();

            string parameterList = string.Join(",", parameters2.Select(x => x.ParameterName));

            string query2 = $"SELECT Id, ChallengeName, Description, Points FROM Challenge WHERE Id NOT IN ({parameterList}) AND WeddingCode = @WeddingCode";

            var challenges = await _db.GetQueryExecuter(query2, r => new ChallengesDTO
            {
                Id = Convert.ToInt32(r["Id"]),
                ChallengeName = Convert.ToString(r["ChallengeName"]),
                ChallengeDescription = Convert.ToString(r["Description"]),
                ChallengePoints = Convert.ToInt32(r["Points"])
            }, parameters2);

            return challenges;
        }
        public async Task<int> ChallengesPost(ChallengesDTO challenges, string weddingCode)
        {
            string query = "INSERT INTO Challenge(ChallengeName, WeddingCode, Description, Points) VALUES (@ChallengeName, @WeddingCode, @Description, @Points); SELECT SCOPE_IDENTITY()";
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@ChallengeName", challenges.ChallengeName),
                new SqlParameter("@WeddingCode", weddingCode),
                new SqlParameter("@Description", challenges.ChallengeDescription),
                new SqlParameter("@Points", challenges.ChallengePoints)
            };

            int id = await _db.PostQueryExecuter(query, parameters);

            return id;
        }
        public async Task DeleteChallenges(int id)
        {
            string query = "DELETE FROM Challenge WHERE Id = @Id";

            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", id)
            };

            await _db.PatchDeleteQueryExecuter(query, parameters);
        }
        public async Task PostIdChallenge(int id, int points, int userId, string userEmail)
        {

            string query = "INSERT INTO ChallengeCompleted(UserEmail, ChallengeId) VALUES (@Email, @ChallengeId)";

            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Email", userEmail),
                new SqlParameter("@ChallengeId", id)
            };

            await _db.PostQueryExecuter(query, parameters);

            string query2 = "UPDATE UserProfile SET UserPoints = UserPoints + @Points WHERE UserId = @UserId";

            List<SqlParameter> parameters2 = new List<SqlParameter>()
            {
                new SqlParameter("@Points", points),
                new SqlParameter("@UserId", userId)
            };

            await _db.PatchDeleteQueryExecuter(query2, parameters2);
        }
    }
}
