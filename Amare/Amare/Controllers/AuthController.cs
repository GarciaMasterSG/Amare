using Amare.Data;
using Amare.Models;
using Azure.Core;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace Amare.Controllers
{
    public class AuthController : Controller
    {
        private readonly DbUserProfile _db;

        public AuthController(DbUserProfile db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login([FromForm]string email, string password)
        {
            string query = "SELECT * FROM UserProfile WHERE Email = @Email";

            List<SqlParameter> parameters = new List<SqlParameter> { 
                new SqlParameter("@Email", email)
            };

            var users = _db.GetQueryExecuter<UserProfile>(query,
                    r => new UserProfile
                    {
                        Id = Convert.ToInt16(r["UserId"]),
                        Name = Convert.ToString(r["Name"]),
                        Email = Convert.ToString(r["Email"]),
                        Password = Convert.ToString(r["Password"]),
                        ProfilePhoto = Convert.ToString(r["ProfilePhoto"]),
                        WeddingCode = Convert.ToString(r["WeddingCode"]),
                        Role = Convert.ToString(r["Role"])
                    }, parameters);

            var user = users.FirstOrDefault(u => u.Password == password);

            if (user == null)
            {
                return Ok(new
                {
                    redirectUrl = Url.Action("Login", "Auth")
                });
            }
            

            return Ok(new {redirectUrl = Url.Action("Index", "Home")});
        }
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUpBG([FromBody] SignupPost request)
        {
            var queryCouple = "INSERT INTO UserProfile(Name, Email, Password, ProfilePhoto, WeddingCode, Role) VALUES (@Name, @Email, @Password, @ProfilePhoto, @WeddingCode, @Role); INSERT INTO Wedding(WeddingCode, Groom, Bride) VALUES (@WeddingCode, @Groom, @Bride)";

            List<SqlParameter> parametersCouple = new List<SqlParameter>() {
                new SqlParameter("@Name", request.userProfile.Name),
                new SqlParameter("@Email", request.userProfile.Email),
                new SqlParameter("@Password", request.userProfile.Password),
                new SqlParameter("@ProfilePhoto", request.userProfile.ProfilePhoto),
                new SqlParameter("@WeddingCode", request.userProfile.WeddingCode),
                new SqlParameter("@Role", request.userProfile.Role),
                new SqlParameter("@Groom", request.wedding.Groom),
                new SqlParameter("@Bride", request.wedding.Bride)
            };

            _db.PostQueryExecuter(queryCouple, parametersCouple);
        

            return Ok(new { redirectUrl = Url.Action("Login", "Auth") });
        }

        [HttpPost]
        public IActionResult CheckWeddingCode([FromBody] string weddingCode)
        {
            return Ok(new {WC = weddingCode});
        }
        [HttpPost]
        public IActionResult SignUpG([FromBody] UserProfile user)
        {
            var queryGuest = "INSERT INTO UserProfile(Name, Email, Password, ProfilePhoto, WeddingCode, Role) VALUES (@Name, @Email, @Password, @ProfilePhoto, @WeddingCode, @Role);";

            List<SqlParameter> parametersGuest = new List<SqlParameter>() {
                new SqlParameter("@Name", user.Name),
                new SqlParameter("@Email", user.Email),
                new SqlParameter("@Password", user.Password),
                new SqlParameter("@ProfilePhoto", user.ProfilePhoto),
                new SqlParameter("@WeddingCode", user.WeddingCode),
                new SqlParameter("@Role", user.Role),
            };

            _db.PostQueryExecuter(queryGuest, parametersGuest);

            return Ok(new { redirectUrl = Url.Action("Login", "Auth") });
        }
    }
}
