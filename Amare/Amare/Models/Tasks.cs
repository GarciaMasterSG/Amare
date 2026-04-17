namespace Amare.Models
{
    public class Tasks
    {
        public int Id { get; set; }

        public string TaskName { get; set; }

        public DateTime TaskDate { get; set; }

        public int TaskCompleted { get; set; } = 0;
    }
}
