using System.ComponentModel.DataAnnotations;

namespace Amare.Models
{
    public class UserProfileDomain : UserLeaderboardDomain
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "FirstName is required.")]
        [MaxLength(150, ErrorMessage = "FirstName cannot exceed 150 characters.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [MaxLength(200, ErrorMessage = "Email cannot exceed 200 characters.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [MaxLength(200, ErrorMessage = "Password cannot exceed 100 characters.")]
        public string Password { get; set; }

        public string? ProfilePhoto { get; set; }

        [Required(ErrorMessage = "WeddingCode is required.")]
        [MaxLength(200, ErrorMessage = "WeddingCode cannot exceed 200 characters.")]
        public string WeddingCode { get; set; }

        [Required(ErrorMessage = "Role is required.")]
        [MaxLength(100, ErrorMessage = "Role cannot exceed 100 characters.")]
        public string Role { get; set; }
    }
}
