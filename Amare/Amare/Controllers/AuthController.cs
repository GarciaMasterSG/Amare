using Amare.Data;
using Amare.Models;
using LogicLayer;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Linq.Expressions;
using System.Security.Claims;

namespace Amare.Controllers
{
    public class AuthController : Controller
    {
        private readonly Auth _auth;

        public AuthController(Auth auth)
        {
            _auth = auth;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login([FromForm]string email, string password)
        {

            try
            {
                var users = await _auth.Login(email);

                if (!users.Any())
                {
                    return BadRequest(new
                    {
                        redirectUrl = Url.Action("Login", "Auth"),
                        noLogin = "No email found"
                    });
                }

                var finalUser = users.FirstOrDefault(u => u.Email == email);

                if (users.Count >= 2)
                {
                    HttpContext.Session.SetString("UserEmail", finalUser.Email);

                    var weddingCodes = users.Select(u => u.WeddingCode).ToList();

                    return BadRequest(new { redirectUrl = Url.Action("UserWith2Weddings", "Auth"), weddingCodes = weddingCodes });
                }

                bool isPasswordValid = BCrypt.Net.BCrypt.Verify(password, finalUser.Password);

                if (!isPasswordValid)
                {
                    return BadRequest(new
                    {
                        redirectUrl = Url.Action("Login", "Auth"),
                        noLogin = "Wrong Password"
                    });
                }

                var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, finalUser.Email),
                new Claim(ClaimTypes.Role, finalUser.Role)
            };

                var identity = new ClaimsIdentity(claims, "Cookie");

                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync("Cookies", principal);

                HttpContext.Session.SetString("UserWeddingCode", finalUser.WeddingCode);
                HttpContext.Session.SetString("UserName", finalUser.Name);
                HttpContext.Session.SetInt32("UserId", finalUser.Id);
                HttpContext.Session.SetString("UserEmail", finalUser.Email);
                HttpContext.Session.SetInt32("UserPoints", finalUser.UserPoints);

                return Ok(new { redirectUrl = Url.Action("Index", "Home"), role = finalUser.Role });
            }

            catch (Exception ex)
            {
                return BadRequest(new {error = ex});
            }
        }

        [HttpGet]
        public IActionResult UserWith2Weddings()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UserWith2Weddings([FromBody] string weddingCode)
        {
            var userEmail = HttpContext.Session.GetString("UserEmail");

            var user = await _auth.UsersInWeddings(userEmail);

            var finalUser = user.FirstOrDefault(u => u.Email == userEmail);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, finalUser.Email),
                new Claim(ClaimTypes.Role, finalUser.Role)
            };

            var identity = new ClaimsIdentity(claims, "Cookie");

            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync("Cookies", principal);

            HttpContext.Session.SetString("UserWeddingCode", weddingCode);
            HttpContext.Session.SetString("UserName", finalUser.Name);
            HttpContext.Session.SetInt32("UserId", finalUser.Id);
            HttpContext.Session.SetString("UserEmail", finalUser.Email);
            HttpContext.Session.SetInt32("UserPoints", finalUser.UserPoints);

            return Ok(new { redirectUrl = Url.Action("Index", "Home"), role = finalUser.Role });

        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUpBG([FromBody] SignupPostDTO request)
        {
            try
            {
                await _auth.SignUpBG(request);

                Console.WriteLine("Paso");

                return Ok(new { redirectUrl = Url.Action("Login", "Auth") });
            }
            catch (SqlException exeption)
            {
                Console.WriteLine(exeption);

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

                    else if (exeption.Message.Contains("PK__Wedding__C4BF8FA030F2FD98"))
                    {
                        return BadRequest(new { redirectUrl = Url.Action("SignUp", "Auth"), Error = "WeddingCode already exist" });
                    }

                    return BadRequest(new {Leyo = "no"});
                }

                else
                {
                    return BadRequest(new {Leyo = "no 2"});
                }
            }
        }

        [HttpPost]
        public IActionResult CheckWeddingCode([FromBody] string weddingCode)
        {
            return Ok(new {WC = weddingCode});
        }
        [HttpPost]
        public async Task<IActionResult> SignUpG([FromBody] UserProfileDomain user)
        {
            await _auth.SignUpG(user);

            return Ok(new { redirectUrl = Url.Action("Login", "Auth") });
        }

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();

            return RedirectToAction("Login");
        }
    }
}
