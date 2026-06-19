using System.ComponentModel.DataAnnotations;

namespace Amare.Models
{
    public class WeddingLocationAndDateDomain
    {
        [Required(ErrorMessage = "WeddingLocation is required.")]
        [MaxLength(150, ErrorMessage = "WeddingLocation cannot exceed 150 characters.")]
        public string? WeddingLocation {  get; set; }

        [Required(ErrorMessage = "WeddingDate is required.")]
        public DateTime? WeddingDate { get; set; }
    }
}
