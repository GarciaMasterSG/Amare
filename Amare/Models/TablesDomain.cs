using System.ComponentModel.DataAnnotations;

namespace Amare.Models
{
    public class TablesDomain
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Guests is required")]
        public List<string>? Guests { get; set; }
    }
}
