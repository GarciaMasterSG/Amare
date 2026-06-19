using Amare.Data;
using Amare.Models;
using LogicLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Diagnostics;

namespace Amare.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly Home _home;

        public HomeController(Home home)
        {
            _home = home;
        }
        public async Task<IActionResult> Index()
        {
            var weddingCode = HttpContext.Session.GetString("UserWeddingCode");

            var coupleName = await _home.GetIndex(weddingCode);

            if (coupleName == null)
            {
                return View();
            }

            string? weddingDate;

            if (coupleName.WeddingDate == null)
            {
                weddingDate = "";
            }
            else
            {
                weddingDate = coupleName.WeddingDate.Value.ToString("dd/MM/yy");
            }

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
