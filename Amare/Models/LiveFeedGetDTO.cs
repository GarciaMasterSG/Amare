using System.ComponentModel.DataAnnotations;

namespace Amare.Models
{
    public class LiveFeedGetDTO : LiveFeedDomain
    {
        [Required(ErrorMessage = "PhotoFeed is required.")]
        public string PhotoFeed { get; set; }
    }
}
