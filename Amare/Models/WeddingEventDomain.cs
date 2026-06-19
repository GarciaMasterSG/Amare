using System.ComponentModel.DataAnnotations;

namespace Amare.Models
{
    public class WeddingEventDomain
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "WeddingEventName is required.")]
        [MaxLength(150, ErrorMessage = "WeddingEventName cannot exceed 150 characters.")]
        public string WeddingEventName { get; set; }

        [Required(ErrorMessage = "WeddingEventTime is required.")]
        public TimeSpan WeddingEventTime { get; set; }
    }
}
