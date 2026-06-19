using Amare.Data;
using Amare.Models;
using Microsoft.Data.SqlClient;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class TasksRepository : ITasks
    {
        private readonly DbUserProfile _db;

        public TasksRepository(DbUserProfile db)
        {
            _db = db;
        }

        public async Task<List<TasksDomain>> GetTasks(string weddingCode)
        {
            string query = "SELECT Id, TaskName, TaskDate, TaskCompleted FROM Task WHERE WeddingCode = @WeddingCode";

            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@WeddingCode", weddingCode)
            };

            var tasks = await _db.GetQueryExecuter(query, r => new TasksDomain
            {
                Id = Convert.ToInt16(r["Id"]),
                TaskName = Convert.ToString(r["TaskName"]),
                TaskDate = Convert.ToDateTime(r["TaskDate"]),
                TaskCompleted = Convert.ToInt16(r["TaskCompleted"])
            }, parameters);

            return tasks;
        }
        public async Task<int> TasksPost(TasksDomain tasks, string weddingCode)
        {
            string query = "INSERT INTO Task(TaskName, WeddingCode, TaskDate, TaskCompleted) VALUES (@TaskName, @WeddingCode, @TaskDate, @TaskCompleted); SELECT SCOPE_IDENTITY()";

            int taskCompleted = 0;

            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@TaskName", tasks.TaskName),
                new SqlParameter("@WeddingCode", weddingCode),
                new SqlParameter("@TaskDate", tasks.TaskDate),
                new SqlParameter("@TaskCompleted", taskCompleted)
            };

            int id = await _db.PostQueryExecuter(query, parameters);

            return id;
        }
        public async Task DeleteTasks(int id)
        {
            string query = "DELETE FROM Task WHERE Id = @Id";

            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", id)
            };

            await _db.PatchDeleteQueryExecuter(query, parameters);

        }

        public async Task UpdateTaskCompleted(int id)
        {
            string query = "UPDATE Task SET TaskCompleted = 1 WHERE Id = @Id";

            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", id)
            };

            await _db.PatchDeleteQueryExecuter(query, parameters);

        }
    }
}
