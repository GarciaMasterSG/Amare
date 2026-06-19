using System.ComponentModel.DataAnnotations;

namespace Amare.Models
{
    public class UserLeaderboardDomain
    {
        [Required(ErrorMessage = "Name is required.")]
        [MaxLength(150, ErrorMessage = "Name cannot exceed 150 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "User points are required.")]
        public int UserPoints { get; set; }
    }
}
