using Microsoft.AspNetCore.Mvc;
using Amare.Models;
using Amare.Data;
using Microsoft.Data.SqlClient;
using LogicLayer;

namespace Amare.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VendorsController : BaseController
    {
        private readonly Vendors _vendors;

        public VendorsController(Vendors vendors)
        {
            _vendors = vendors;
        }

        [HttpGet]
        public async Task<List<VendorsDTO>> GetVendors()
        {
            var vendors = await _vendors.GetVendors(weddingnCode);

            return vendors;

        }

        [HttpPost]
        public async Task<IActionResult> addVendors([FromForm] VendorsDTO vendors)
        {
            int id = await _vendors.PostVendors(vendors, weddingnCode);

            return Ok(id);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateHired(int id)
        {
            await _vendors.UpdateHired(id);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteData(int id)
        {
            await _vendors.DeleteVendors(id);

            return Ok();
        }

    }
}
