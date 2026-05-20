using Microsoft.AspNetCore.Http;

namespace Amare.Models
{
    public class LiveFeedPostDTO
    {
        public string Description { get; set; }

        public string FileName { get; set; }

        public IFormFile PhotoFeed { get; set; }
    }
}
