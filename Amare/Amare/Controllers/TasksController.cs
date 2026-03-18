using Microsoft.AspNetCore.Mvc;
using Amare.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Amare.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> TasksPost([FromForm] Tasks tasks)
        {
            return Ok(tasks) ;
        }
    }
}
