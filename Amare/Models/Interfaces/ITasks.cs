using Amare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public interface ITasks
    {
        Task<List<TasksDTO>> GetTasks(string weddingCode);

        Task<int> TasksPost(TasksDTO tasks, string weddingCode);

        Task DeleteTasks(int id);

        Task UpdateTaskCompleted(int id);
    }
}
