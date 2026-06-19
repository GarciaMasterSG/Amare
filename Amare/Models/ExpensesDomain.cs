using System.ComponentModel.DataAnnotations;

namespace Amare.Models
{
    public class ExpensesDomain
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "ExpenseName is required.")]
        [MaxLength(100, ErrorMessage = "ExpenseName cannot exceed 100 characters.")]
        public string? ExpenseName { get; set; }
        [Required(ErrorMessage = "ExpensePrice is required.")]
        public float ExpensePrice { get; set; }
    }
}
