using Amare.Data;
using Amare.Models;
using Microsoft.Data.SqlClient;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class Tasks
    {
        private readonly ITasks _tasks;

        public Tasks(ITasks tasks)
        {
            _tasks = tasks;
        }

        public async Task<List<TasksDTO>> GetTasks(string weddingCode)
        {
            return await _tasks.GetTasks(weddingCode);
        }

        public async Task<int> TasksPost(TasksDTO tasks, string weddingCode)
        {
            return await _tasks.TasksPost(tasks, weddingCode);
        }

        public async Task DeleteTasks(int id)
        {
            await _tasks.DeleteTasks(id);
        }

        public async Task UpdateTaskCompleted(int id)
        {
            await _tasks.UpdateTaskCompleted(id);
        }
    }
}
