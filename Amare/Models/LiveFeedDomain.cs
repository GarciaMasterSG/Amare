using System.ComponentModel.DataAnnotations;

namespace Amare.Models
{
    public class LiveFeedDomain
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "UserName is required.")]
        [MaxLength(150, ErrorMessage = "UserName cannot exceed 150 characters.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "WeddingCode is required.")]
        public string? WeddingCode { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        [MaxLength(300, ErrorMessage = "Description cannot exceed 300 characters.")]
        public string Description { get; set; }
    }
}
