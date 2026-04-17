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
        public async Task<IActionResult> Login([FromForm]string email, string password)
        {
            string query = "SELECT * FROM UserProfile WHERE Email = @Email";

            List<SqlParameter> parameters = new List<SqlParameter> { 
                new SqlParameter("@Email", email)
            };

            var users = await _db.GetQueryExecuter<UserProfile>(query,
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

            if (!users.Any())
            {
                return BadRequest(new
                {
                    redirectUrl = Url.Action("Login", "Auth"),
                    noLogin = "No email found"
                });
            }

            var user = users.FirstOrDefault(u => u.Password == password);

            if (user == null)
            {
                return BadRequest(new
                {
                    redirectUrl = Url.Action("Login", "Auth"),
                    noLogin = "Wrong Password"
                });
            }

            HttpContext.Session.SetString("UserWeddingCode", user.WeddingCode);
            HttpContext.Session.SetString("UserName", user.Name);
            HttpContext.Session.SetInt32("UserId", user.Id);

            return Ok(new {redirectUrl = Url.Action("Index", "Home")});
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUpBG([FromBody] SignupPost request)
        {
            try
            {
                var queryCouple = "INSERT INTO Wedding(WeddingCode, Groom, Bride) VALUES (@WeddingCode, @Groom, @Bride); INSERT INTO UserProfile(Name, Email, Password, ProfilePhoto, WeddingCode, Role) VALUES (@Name, @Email, @Password, @ProfilePhoto, @WeddingCode, @Role); INSERT INTO Budget(WeddingCode, MaxBudget) VALUES (@WeddingCode, @MaxBudget)";

                List<SqlParameter> parametersCouple = new List<SqlParameter>() {
                new SqlParameter("@Name", request.userProfile.Name),
                new SqlParameter("@Email", request.userProfile.Email),
                new SqlParameter("@Password", request.userProfile.Password),
                new SqlParameter("@ProfilePhoto", request.userProfile.ProfilePhoto),
                new SqlParameter("@WeddingCode", request.userProfile.WeddingCode),
                new SqlParameter("@Role", request.userProfile.Role),
                new SqlParameter("@Groom", request.wedding.Groom),
                new SqlParameter("@Bride", request.wedding.Bride),
                new SqlParameter("@MaxBudget", request.maxBudget)
                };

                await _db.PostQueryExecuter(queryCouple, parametersCouple);


                return Ok(new { redirectUrl = Url.Action("Login", "Auth") });
            }
            catch (SqlException exeption)
            {
                if (exeption.Number == 2627 || exeption.Number == 2601)
                {
                    if (exeption.Message.Contains("UQ_Email"))
                    {
                        return BadRequest(new { redirectUrl = Url.Action("SignUp", "Auth"), Error = "Email already exist" });
                    } 

                    else if (exeption.Message.Contains("UQ_WeddingCode"))
                    {
                        return BadRequest(new { redirectUrl = Url.Action("SignUp", "Auth"), Error = "WeddingCode already exist" });
                    }
                    else if (exeption.Message.Contains("UQ_Wedding"))
                    {
                        return BadRequest(new { redirectUrl = Url.Action("SignUp", "Auth"), Error = "WeddingCode already exist" });
                    }

                    return BadRequest();
                }

                else
                {
                    return BadRequest();
                }
            }
        }

        [HttpPost]
        public IActionResult CheckWeddingCode([FromBody] string weddingCode)
        {
            return Ok(new {WC = weddingCode});
        }
        [HttpPost]
        public async Task<IActionResult> SignUpG([FromBody] UserProfile user)
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

            await _db.PostQueryExecuter(queryGuest, parametersGuest);

            return Ok(new { redirectUrl = Url.Action("Login", "Auth") });
        }
    }
}
