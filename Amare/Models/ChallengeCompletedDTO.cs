using System.ComponentModel.DataAnnotations;

namespace Amare.Models
{
    public class ChallengeCompletedDTO
    {
        [Required (ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        [MaxLength(200, ErrorMessage = "Email cannot exceed 200 characters.")]
        public string UserEmail { get; set; }

        [Required(ErrorMessage = "ChallengeId is required.")]
        public int ChallengeId { get; set; }
    }
}
