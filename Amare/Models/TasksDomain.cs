using System.ComponentModel.DataAnnotations;

namespace Amare.Models
{
    public class TasksDomain
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "TaskName is required.")]
        [MaxLength(150, ErrorMessage = "TaskName cannot exceed 150 characters.")]
        public string TaskName { get; set; }

        [Required(ErrorMessage = "TaskDate is required.")]
        public DateTime TaskDate { get; set; }

        [Required(ErrorMessage = "TaskCompleted is required.")]
        public int TaskCompleted { get; set; } = 0;
    }
}
