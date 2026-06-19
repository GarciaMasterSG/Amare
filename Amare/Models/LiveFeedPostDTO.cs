using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Amare.Models
{
    public class LiveFeedPostDTO
    {
        [Required(ErrorMessage = "Description is required.")]
        [MaxLength(300, ErrorMessage = "Description cannot exceed 300 characters.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "File name is required.")]
        [MaxLength(200, ErrorMessage = "File name cannot exceed 200 characters.")]
        public string FileName { get; set; }

        [Required(ErrorMessage = "PhotoFeed is required.")]
        public IFormFile PhotoFeed { get; set; }
    }
}
