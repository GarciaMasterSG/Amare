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
            string query = "SELECT * FROM Wedding WHERE WeddingCode = @WeddingCode";

            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@WeddingCode",weddingCode)
            };

            var couple = await _db.GetQueryExecuter(query, r => new Wedding {
                Groom = Convert.ToString(r["Groom"]),
                Bride = Convert.ToString(r["Bride"]),
                WeddingCode = Convert.ToString(r["WeddingCode"])
            }, parameters);

            var coupleName = couple.FirstOrDefault(w => w.WeddingCode == weddingCode);

            if (coupleName == null)
            {
                return View();
            }

            ViewBag.Groom = coupleName.Groom;
            ViewBag.Bride = coupleName.Bride;

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
