using Microsoft.AspNetCore.Mvc;
using Amare.Models;
using Amare.Data;
using Microsoft.Data.SqlClient;
using LogicLayer;

namespace Amare.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TablesController : BaseController
    {
        private readonly Tables _tables;

        public TablesController(Tables tables)
        {
            _tables = tables;
        }

        [HttpPost]
        public async Task<IActionResult> PostTable([FromBody] TablesDomain table)
        {
            var noOnTable = await _tables.PostTable(table, weddingnCode);

            return Ok(noOnTable);
        }
    }
}
