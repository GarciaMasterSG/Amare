using Amare.Data;
using Amare.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Diagnostics;

namespace Amare.Controllers
{
    public class HomeController : Controller
    {
        private readonly DbUserProfile _db;

        public HomeController(DbUserProfile db)
        {
           _db = db;
        }
        public async Task<IActionResult> Index()
        {
            var weddingCode = HttpContext.Session.GetString("UserWeddingCode");

            if (weddingCode == null)
            {
                return RedirectToAction("Login", "Auth");
            }

            string query = "SELECT * FROM Wedding WHERE WeddingCode = @WeddingCode";

            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@WeddingCode",weddingCode)
            };

            var couple = await _db.GetQueryExecuter(query, r => new WeddingDTO {
                Groom = Convert.ToString(r["Groom"]),
                Bride = Convert.ToString(r["Bride"]),
                WeddingCode = Convert.ToString(r["WeddingCode"]),
                WeddingLocation = Convert.ToString(r["WeddingLocation"]),
                WeddingDate = Convert.ToDateTime(r["WeddingDate"]) 
            }, parameters);

            var coupleName = couple.FirstOrDefault(w => w.WeddingCode == weddingCode);

            if (coupleName == null)
            {
                return View();
            }

            string weddingDate = coupleName.WeddingDate.ToString("dd/MM/yy");

            ViewBag.Groom = coupleName.Groom;
            ViewBag.Bride = coupleName.Bride;
            ViewBag.Email = HttpContext.Session.GetString("UserEmail");
            ViewBag.UserName = HttpContext.Session.GetString("UserName");
            ViewBag.Location = coupleName.WeddingLocation;
            ViewBag.Date = weddingDate;
            ViewBag.Points = HttpContext.Session.GetInt32("UserPoints");

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
