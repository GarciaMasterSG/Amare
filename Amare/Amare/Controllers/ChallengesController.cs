using Microsoft.AspNetCore.Mvc;
using Amare.Models;
using Amare.Data;
using Microsoft.Data.SqlClient;

namespace Amare.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChallengesController : BaseController
    {
        private readonly DbUserProfile _db;

        public ChallengesController(DbUserProfile db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<List<Challenges>> GetChallenges()
        {
            string query = "SELECT Id, ChallengeName, WeddingCode, Description, Points FROM Challenge WHERE WeddingCode = @WeddingCode";

            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@WeddingCode", weddingnCode)
            };

            var challenges = await _db.GetQueryExecuter(query, r => new Challenges
            {
                Id = Convert.ToInt16(r["Id"]),

                ChallengeName = Convert.ToString(r["ChallengeName"]),

                ChallengeDescription = Convert.ToString(r["Description"]),

                ChallengePoints = Convert.ToInt16(r["Points"])

            }, parameters);

            return challenges;
        }

        [HttpPost]
        public async Task<IActionResult> ChallengesPost([FromForm] Challenges challenges)
        {
            var weddingCode = HttpContext.Session.GetString("UserWeddingCode");
            string query = "INSERT INTO Challenge(ChallengeName, WeddingCode, Description, Points) VALUES (@ChallengeName, @WeddingCode, @Description, @Points); SELECT SCOPE_IDENTITY()";
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@ChallengeName", challenges.ChallengeName),
                new SqlParameter("@WeddingCode", weddingCode),
                new SqlParameter("@Description", challenges.ChallengeDescription),
                new SqlParameter("@Points", challenges.ChallengePoints)
            };

            int id = await _db.PostQueryExecuter(query, parameters);

            return Ok(id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteData(int id)
        {
            string query = "DELETE FROM Challenge WHERE Id = @Id";

            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", id)
            };

            await _db.PatchDeleteQueryExecuter(query, parameters);

            return Ok();
        }
    }
}
