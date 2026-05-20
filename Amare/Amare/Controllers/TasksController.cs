using Microsoft.AspNetCore.Mvc;
using Amare.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Amare.Data;
using Microsoft.Data.SqlClient;
using LogicLayer;

namespace Amare.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : BaseController
    {
        private readonly Tasks _tasks;

        public TasksController(Tasks tasks)
        {
            _tasks = tasks;
        }

        [HttpGet]
        public async Task<List<TasksDTO>> Gettasks()
        {
            var tasks = await _tasks.GetTasks(weddingnCode);

            return tasks;
        }

        [HttpPost]
        public async Task<IActionResult> TasksPost([FromForm] TasksDTO tasks)
        {
            int id = await _tasks.TasksPost(tasks, weddingnCode);

            return Ok(id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteData(int id)
        {
            await _tasks.DeleteTasks(id);

            return Ok();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateTaskCompleted(int id)
        {
            await _tasks.UpdateTaskCompleted(id);

            return Ok();
        }
    }
}
