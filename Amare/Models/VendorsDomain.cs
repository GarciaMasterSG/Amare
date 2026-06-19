using System.ComponentModel.DataAnnotations;

namespace Amare.Models
{
    public class VendorsDomain
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "VendorName is required.")]
        [MaxLength(150, ErrorMessage = "VendorName cannot exceed 150 characters.")]
        public string? VendorName { get; set; }

        [Required(ErrorMessage = "VendorDescription is required.")]
        [MaxLength(300, ErrorMessage = "VendorDescription cannot exceed 300 characters.")]
        public string? VendorDescription { get; set; }

        [Required(ErrorMessage = "VendorType is required.")]
        [MaxLength(100, ErrorMessage = "VendorType cannot exceed 100 characters.")]
        public string? VendorType { get; set; }
        
        [Required(ErrorMessage = "VendorPrice is required.")]
        public float VendorPrice { get; set; }

        public int Hired { get; set; } = 0;
    }
}
