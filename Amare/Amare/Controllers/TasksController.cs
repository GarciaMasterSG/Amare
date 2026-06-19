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
        public async Task<List<TasksDomain>> GetTasks()
        {
            var tasks = await _tasks.GetTasks(weddingnCode);

            return tasks;
        }

        [HttpPost]
        public async Task<IActionResult> TasksPost([FromForm] TasksDomain tasks)
        {
            if (tasks.TaskName.Length > 150)
            {
                return BadRequest("Task name cannot be longer than 150 characters.");
            }

            int id = await _tasks.TasksPost(tasks, weddingnCode);

            return Ok(id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
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
