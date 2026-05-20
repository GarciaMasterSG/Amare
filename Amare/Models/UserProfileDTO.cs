namespace Amare.Models
{
    public class UserProfileDTO : UserLeaderboardDTO
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string? ProfilePhoto { get; set; }

        public string WeddingCode { get; set; }

        public string Role { get; set; }
    }
}
