using Microsoft.AspNetCore.Mvc;
using Amare.Models;
using Amare.Data;
using Microsoft.Data.SqlClient;

namespace Amare.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TablesController : ControllerBase
    {
        private readonly DbUserProfile _profile;

        public TablesController(DbUserProfile profile)
        {
            _profile = profile;
        }
        [HttpPost]
        public async Task<IActionResult> CreateTable([FromBody] Tables table)
        {
            return Ok(table);
        }
    }
}
