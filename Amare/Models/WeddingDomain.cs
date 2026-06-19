using System.ComponentModel.DataAnnotations;

namespace Amare.Models
{
    public class WeddingDomain : WeddingLocationAndDateDomain
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "WeddingCode is required.")]
        [MaxLength(200, ErrorMessage = "WeddingCode cannot exceed 200 characters.")]
        public string WeddingCode { get; set; }

        [Required(ErrorMessage = "Groom is required.")]
        [MaxLength(150, ErrorMessage = "Groom cannot exceed 150 characters.")]
        public string Groom {  get; set; }

        [Required(ErrorMessage = "Bride is required.")]
        [MaxLength(150, ErrorMessage = "Bride cannot exceed 150 characters.")]
        public string Bride { get; set; }
    }
}
