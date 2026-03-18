using Microsoft.AspNetCore.Mvc;
using Amare.Models;

namespace Amare.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VendorsController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> addVendors([FromForm] Vendors vendors)
        {
            return Ok(vendors);
        }
    }
}
