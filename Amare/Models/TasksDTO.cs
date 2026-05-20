namespace Amare.Models
{
    public class TasksDTO
    {
        public int Id { get; set; }

        public string TaskName { get; set; }

        public DateTime TaskDate { get; set; }

        public int TaskCompleted { get; set; } = 0;
    }
}
