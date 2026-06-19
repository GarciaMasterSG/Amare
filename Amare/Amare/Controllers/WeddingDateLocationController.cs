using Amare.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Amare.Models;
using LogicLayer;

namespace Amare.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeddingDateLocationController : BaseController
    {
        private readonly WeddingDateLoaction _weddingDateLocation;

        public WeddingDateLocationController(WeddingDateLoaction weddingDateLocation)
        {
            _weddingDateLocation = weddingDateLocation;
        }

        [HttpPost]
        public async Task<IActionResult> PostWeddingDateLocation([FromForm] WeddingLocationAndDateDomain postDateLocation)
        {
            await _weddingDateLocation.PostWeddingDateLocation(postDateLocation, weddingnCode);

            return Ok();
        } 
    }
}
