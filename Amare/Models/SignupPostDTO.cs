namespace Amare.Models
{
    public class SignupPostDTO
    {
        public UserProfileDTO userProfile { get; set; }

        public WeddingDTO wedding { get; set; }

        public int maxBudget { get; set; }
    }
}
