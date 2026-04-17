using Microsoft.AspNetCore.Mvc;
using Amare.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Amare.Data;
using Microsoft.Data.SqlClient;

namespace Amare.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : BaseController
    {
        private readonly DbUserProfile _db;

        public TasksController(DbUserProfile db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<List<Tasks>> Gettasks()
        {
            string query = "SELECT Id, TaskName, TaskDate, TaskCompleted FROM Task WHERE WeddingCode = @WeddingCode";

            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@WeddingCode", weddingnCode)
            };

            var tasks = await _db.GetQueryExecuter(query, r => new Tasks
            {
                Id = Convert.ToInt16(r["Id"]),
                TaskName = Convert.ToString(r["TaskName"]),
                TaskDate = Convert.ToDateTime(r["TaskDate"]),
                TaskCompleted = Convert.ToInt16(r["TaskCompleted"])
            }, parameters);

            return tasks;
        }

        [HttpPost]
        public async Task<IActionResult> TasksPost([FromForm] Tasks tasks)
        {
            string query = "INSERT INTO Task(TaskName, WeddingCode, TaskDate, TaskCompleted) VALUES (@TaskName, @WeddingCode, @TaskDate, @TaskCompleted); SELECT SCOPE_IDENTITY()";

            int taskCompleted = 0;

            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@TaskName", tasks.TaskName),
                new SqlParameter("@WeddingCode", weddingnCode),
                new SqlParameter("@TaskDate", tasks.TaskDate),
                new SqlParameter("@TaskCompleted", taskCompleted)
            };

            int id = await _db.PostQueryExecuter(query, parameters);

            return Ok(id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteData(int id)
        {
            string query = "DELETE FROM Task WHERE Id = @Id";

            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", id)
            };

            await _db.PatchDeleteQueryExecuter(query, parameters);

            return Ok();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateTaskCompleted(int id)
        {
            string query = "UPDATE Task SET TaskCompleted = 1 WHERE Id = @Id";

            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", id)
            };

            await _db.PatchDeleteQueryExecuter(query, parameters);

            return Ok();
        }
    }
}
