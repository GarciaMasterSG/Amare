using System.ComponentModel.DataAnnotations;

namespace Amare.Models
{
    public class SignupPostDTO
    {
        [Required (ErrorMessage = "UserProfile is required.")]
        public UserProfileDomain userProfile { get; set; }

        public WeddingDomain wedding { get; set; }

        [Required(ErrorMessage = "maxBudget is required.")]
        public int maxBudget { get; set; }
    }
}
