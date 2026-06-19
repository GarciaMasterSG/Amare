using System.ComponentModel.DataAnnotations;

namespace Amare.Models
{
    public class ChallengesDomain
    {
        public int Id { get; set; }

        [Required (ErrorMessage = "Challenge name is required.")]
        [MaxLength(100, ErrorMessage = "Challenge name cannot exceed 100 characters.")]
        public string ChallengeName { get; set; }
        [Required(ErrorMessage = "Challenge description is required.")]
        [MaxLength(300, ErrorMessage = "Challenge description cannot exceed 300 characters.")]
        public string ChallengeDescription { get; set; }
        
        [Required(ErrorMessage = "Challenge points is required.")]
        public int ChallengePoints { get; set; }
    }
}
