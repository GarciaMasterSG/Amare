using System.ComponentModel.DataAnnotations;

namespace Amare.Models
{
    public class BudgetDomain
    {
        public int Id { get; set; }

        public string WeddingCode {  get; set; }

        [Required (ErrorMessage = "This field is required")]
        public float MaxBudget { get; set; }
    }
}
