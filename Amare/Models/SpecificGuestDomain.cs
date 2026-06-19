using System.ComponentModel.DataAnnotations;

namespace Amare.Models
{
    public class SpecificGuest
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "GuestName is required.")]
        public string GuestName { get; set; }
    }
}
